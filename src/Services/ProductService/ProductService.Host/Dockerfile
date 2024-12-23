#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# ���� ���� ������������ ��� ������� �� VS � ������� ������ (�� ��������� ��� ������������ �������)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# ���� ���� ������������ ��� ������ ������� ������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductService/ProductService.Host/ProductService.Host.csproj", "ProductService/ProductService.Host/"]
COPY ["ProductService/DataAccess/ProductService.EntityFramework/ProductService.EntityFramework.csproj", "ProductService/DataAccess/ProductService.EntityFramework/"]
COPY ["ProductService/ProductService.Core/ProductService.Core.csproj", "ProductService/ProductService.Core/"]
COPY ["ProductService/DataAccess/Repositories.Implementations/ProductService.Repositories.Implementstions.csproj", "ProductService/DataAccess/Repositories.Implementations/"]
COPY ["ProductService/Services/Repositories.Abstractions/ProductService.Repositories.Abstractions.csproj", "ProductService/Services/Repositories.Abstractions/"]
COPY ["ProductService/Services/ProductService/ProductService.ProductService.csproj", "ProductService/Services/ProductService/"]
COPY ["ProductService/Services/Contracts/ProductService.Contracts.csproj", "ProductService/Services/Contracts/"]
COPY ["ProductService/Services/Service.Abstractions/ProductService.Services.Abstractions.csproj", "ProductService/Services/Service.Abstractions/"]
RUN dotnet restore "./ProductService/ProductService.Host/ProductService.Host.csproj"
COPY . .
WORKDIR "/src/ProductService/ProductService.Host"
RUN dotnet build "./ProductService.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ���� ���� ������������ ��� ���������� ������� ������, ������� ����� ���������� �� ��������� ����
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductService.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ���� ���� ������������ � ������� ����� ��� ��� ������� �� VS � ������� ������ (�� ���������, ����� ������������ ������� �� ������������)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.Host.dll"]