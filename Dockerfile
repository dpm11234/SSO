FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out 

# Generate run time image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 5000 5001
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "AuthSSO.dll" ]