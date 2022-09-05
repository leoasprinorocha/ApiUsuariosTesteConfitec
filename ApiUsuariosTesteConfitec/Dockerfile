FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .

CMD ASPNETCORE_URLS=https://*:$PORT dotnet ApiUsuariosTesteConfitec.dll