# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
# For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2019 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Simplyfund.Api/Simplyfund.Api.csproj", "Simplyfund.Api/"]
COPY ["Simplyfund.Bll/Simplyfund.Bll.csproj", "Simplyfund.Bll/"]
COPY ["Simplyfund.Dal/Simplyfund.Dal.csproj", "Simplyfund.Dal/"]
COPY ["SimplyFund.Domain/SimplyFund.Domain.csproj", "SimplyFund.Domain/"]
COPY ["Simplyfund.Library/Simplyfund.Library.csproj", "Simplyfund.Library/"]
COPY ["Simplyfund.GeneralConfiguration/Simplyfund.GeneralConfiguration.csproj", "Simplyfund.GeneralConfiguration/"]
RUN dotnet restore "./Simplyfund.Api/./Simplyfund.Api.csproj"
COPY . .
WORKDIR "/src/Simplyfund.Api"
RUN dotnet build "./Simplyfund.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Simplyfund.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simplyfund.Api.dll"]

# Add `RUN chmod -R 777 /app` to grant full permissions to the `/app` directory
RUN chmod -R 777 /app
