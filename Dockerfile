FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ecommerce.Api/Ecommerce.Api.csproj", "Ecommerce.Api/"]
COPY ["Ecommerce.WebUI/Ecommerce.WebUI.csproj", "Ecommerce.WebUI/"]

COPY ["Ecommerce.Domain/Ecommerce.Domain.csproj", "Ecommerce.Domain/"]
COPY ["Ecommerce.Application/Ecommerce.Application.csproj", "Ecommerce.Application/"]
COPY ["Ecommerce.Infrastructure/Ecommerce.Infrastructure.csproj", "Ecommerce.Infrastructure/"]

COPY ["Ecommerce.Application.UnitTests/Ecommerce.Application.UnitTests.csproj", "Ecommerce.Application.UnitTests/"]
COPY ["Ecommerce.Infrastructure.IntegrationTests/Ecommerce.Infrastructure.IntegrationTests.csproj", "Ecommerce.Infrastructure.IntegrationTests/"]
COPY ["Ecommerce.WebUI.UITests/Ecommerce.WebUI.UITests.csproj", "Ecommerce.WebUI.UITests/"]

RUN dotnet restore "Ecommerce.Api/Ecommerce.Api.csproj"
COPY . .
WORKDIR "/src/Ecommerce.Api"
RUN dotnet build "Ecommerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app`enter code here`
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.Api.dll"]