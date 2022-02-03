FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app

COPY . .

RUN dotnet restore "./BCFM/BCFN.csproj"

RUN dotnet publish BCFM.csproj -c Release -o /app

WORKDIR /app

ENV ASPNETCORE_URLS="http://*:80"

ENTRYPOINT ["dotnet", "BCFM.dll"]
