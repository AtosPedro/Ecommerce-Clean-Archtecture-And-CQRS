using AutoMapper;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Exceptions;
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

        public UserService(
            IUserRepository userRepository,
            IHashids hashId,
            IMapper mapper,
            ITokenService tokenService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _hashId = hashId;
            _mapper = mapper;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
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
            string username,
            string password,
            CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.Search(u => u.UserName == username && u.Password == password, cancellationToken);
                if (user == null)
                    throw new NotFoundException("Usuário não cadastrado");

                var token = _tokenService.GenerateToken(user?.FirstOrDefault());
                var autenticatedUserDto = _mapper.Map<AutenticatedUserDto>(user?.FirstOrDefault());
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
                await _userRepository.Add(user, cancellationToken);
                await _unitOfWork.Commit();
                user.Guid = _hashId.Encode(user.Id);

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
