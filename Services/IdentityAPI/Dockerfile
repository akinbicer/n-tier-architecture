FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/IdentityAPI/IdentityAPI.csproj", "Services/IdentityAPI/"]
COPY ["Libraries/Business/Business.csproj", "Libraries/Business/"]
COPY ["Libraries/Core/Core.csproj", "Libraries/Core/"]
COPY ["Libraries/DataAccess/DataAccess.csproj", "Libraries/DataAccess/"]
COPY ["Libraries/Entities/Entities.csproj", "Libraries/Entities/"]
RUN dotnet restore "Services/IdentityAPI/IdentityAPI.csproj"
COPY . .
WORKDIR "/src/Services/IdentityAPI"
RUN dotnet build "IdentityAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityAPI.dll"]