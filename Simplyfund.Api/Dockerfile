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