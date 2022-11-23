using AutoMapper;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.ValueObjects;
using HashidsNet;

namespace Ecommerce.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IHashids _hashId;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _mailService;

        public UserService(
            IUserRepository userRepository,
            IHashids hashId,
            IMapper mapper,
            ITokenService tokenService,
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IEmailService mailService)
        {
            _userRepository = userRepository;
            _hashId = hashId;
            _mapper = mapper;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _mailService = mailService;
        }

        #region Queries
        public async Task<ReadUserDto> GetById(string hashId, CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(hashId);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var user = await _userRepository.GetById(id[0], cancellationToken);

                if (user != null)
                    user.Guid = hashId;
                else
                    throw new NotFoundException();

                var readUserDto = _mapper.Map<ReadUserDto>(user);
                return readUserDto;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ReadUserDto>> GetAll(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll(cancellationToken);
            foreach (var user in users)
            {
                user.Guid = _hashId.Encode(user.Id);
            }
            var readUserDto = _mapper.Map<IEnumerable<ReadUserDto>>(users);
            return readUserDto;
        }

        #endregion

        #region Commands

        public async Task<AutenticatedUserDto> AutenticateUser(
            AutenticatedUserDto authUser,
            CancellationToken cancellationToken)
        {
            try
            {
                var user = (await _userRepository.Search(u => u.UserName == authUser.UserName, cancellationToken))?.FirstOrDefault();
                if (user == null)
                    throw new NotFoundException("Usuário não cadastrado");

                var passwordHash = _passwordHasher.ComputeHash(
                    authUser.Password, 
                    user.PasswordSalt, 
                    _passwordHasher.GetPepper(),
                    _passwordHasher.GetIterations());

                if (user.Password != passwordHash)
                    throw new Exception("Senha incorreta");

                var token = _tokenService.GenerateToken(user);
                var autenticatedUserDto = _mapper.Map<AutenticatedUserDto>(user);
                autenticatedUserDto.Token = token;

                return autenticatedUserDto;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ReadUserDto> Create(
            CreateUserDto userDto,
            CancellationToken cancellationToken)
        {
            try
            {
                var userRegistred = await _userRepository.Search(
                    u => u.UserName == userDto.UserName
                    && u.Email == userDto.Email,
                    cancellationToken);

                if (userRegistred.Any())
                    throw new ValidationException("Usuário já cadastrado.");

                var user = _mapper.Map<User>(userDto);
                user.PasswordSalt = _passwordHasher.GenerateSalt();
                user.Password = _passwordHasher.ComputeHash(
                    user.Password,
                    user.PasswordSalt,
                    _passwordHasher.GetPepper(),
                    _passwordHasher.GetIterations());

                await _userRepository.Add(user, cancellationToken);
                await _unitOfWork.Commit();
                user.Guid = _hashId.Encode(user.Id);

                var mail = new Mail
                {
                    To = user.Email,
                    Subject = "Seu registro foi completado",
                    Body = "<h1>Seu registro de usuário foi completado com sucesso!</h1>",
                };

                await _mailService.SendMail(mail, cancellationToken);

                var readUserDto = _mapper.Map<ReadUserDto>(user);
                return readUserDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<ReadUserDto> Update(
            UpdateUserDto userDto, 
            CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(userDto.Guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var user = await _userRepository.GetById(id[0], cancellationToken);
                if (user == null)
                    throw new NotFoundException();

                _mapper.Map(userDto, user);
                await _userRepository.Update(user);
                await _unitOfWork.Commit();

                var readUser = _mapper.Map<ReadUserDto>(user);
                return readUser;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<ReadUserDto> Delete(string Guid, CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(Guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var user = await _userRepository.GetById(id[0], cancellationToken);
                if (user == null)
                    throw new NotFoundException();

                var result = await _userRepository.Remove(user);
                await _unitOfWork.Commit();

                var readUser = _mapper.Map<ReadUserDto>(result);
                return readUser;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        #endregion
    }
}
