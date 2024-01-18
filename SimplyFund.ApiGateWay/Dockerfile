FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Copy everything
WORKDIR /src
COPY "SimplyFund.ApiGateWay/" "SimplyFund.ApiGateWay/"
RUN dotnet restore "./SimplyFund.ApiGateWay/SimplyFund.ApiGateWay.csproj"
RUN dotnet publish "SimplyFund.ApiGateWay/SimplyFund.ApiGateWay.csproj" -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /src
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "SimplyFund.ApiGateWay.dll"]