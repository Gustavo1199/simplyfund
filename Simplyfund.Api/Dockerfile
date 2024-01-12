

# FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2019 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019 AS build
# ARG BUILD_CONFIGURATION=Release
# WORKDIR /src
# COPY ["Simplyfund.Api/Simplyfund.Api.csproj", "Simplyfund.Api/"]
# COPY ["Simplyfund.Bll/Simplyfund.Bll.csproj", "Simplyfund.Bll/"]
# COPY ["Simplyfund.Dal/Simplyfund.Dal.csproj", "Simplyfund.Dal/"]
# COPY ["SimplyFund.Domain/SimplyFund.Domain.csproj", "SimplyFund.Domain/"]
# COPY ["Simplyfund.Library/Simplyfund.Library.csproj", "Simplyfund.Library/"]
# COPY ["Simplyfund.GeneralConfiguration/Simplyfund.GeneralConfiguration.csproj", "Simplyfund.GeneralConfiguration/"]
# RUN dotnet restore "./Simplyfund.Api/./Simplyfund.Api.csproj"
# COPY . .
# WORKDIR "/src/Simplyfund.Api"
# RUN dotnet build "./Simplyfund.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# FROM build AS publish
# ARG BUILD_CONFIGURATION=Release
# RUN dotnet publish "./Simplyfund.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Simplyfund.Api.dll"]

# Add `RUN chmod -R 777 /app` to grant full permissions to the `/app` directory
# RUN chmod -R 777 /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Copy everything
WORKDIR /src
COPY "Simplyfund.Api/" "Simplyfund.Api/"
COPY "Simplyfund.Bll/" "Simplyfund.Bll/"
COPY "Simplyfund.Dal/" "Simplyfund.Dal/"
COPY "SimplyFund.Domain/" "SimplyFund.Domain/"
COPY "Simplyfund.Library/" "Simplyfund.Library/"
COPY "Simplyfund.GeneralConfiguration/" "Simplyfund.GeneralConfiguration/"
RUN dotnet restore "./Simplyfund.Api/Simplyfund.Api.csproj"
# RUN dotnet restore
# Build and publish a release
# RUN dotnet publish -c Release -o out
RUN dotnet publish "Simplyfund.Api/Simplyfund.Api.csproj" -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /src
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "Simplyfund.Api.dll"]