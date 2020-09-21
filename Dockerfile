FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
# RUN dotnet dev-certs https -ep ./https/aspnetapp.pfx -p phuquy123
# RUN dotnet user-secrets -p AuthSSO.csproj set "Kestrel:Certificates:Development:Password" "phuquy123"
RUN dotnet publish -c Release -o out 

# Generate run time image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "AuthSSO.dll" ]