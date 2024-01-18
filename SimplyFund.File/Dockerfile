FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Copy everything
WORKDIR /src
COPY "SimplyFund.File/" "SimplyFund.File/"
COPY "Simplyfund.Bll/" "Simplyfund.Bll/"
COPY "Simplyfund.Dal/" "Simplyfund.Dal/"
COPY "SimplyFund.Domain/" "SimplyFund.Domain/"
COPY "Simplyfund.Library/" "Simplyfund.Library/"
COPY "Simplyfund.GeneralConfiguration/" "Simplyfund.GeneralConfiguration/"
RUN dotnet restore "./SimplyFund.File/SimplyFund.File.csproj"
RUN dotnet publish "SimplyFund.File/SimplyFund.File.csproj" -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /src
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "SimplyFund.File.dll"]