FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as sdkimage
WORKDIR /app

COPY ./BCFM/*.csproj ./BCFM/
COPY ./Test/*.csproj ./Test/


COPY ./*.sln .
RUN dotnet restore

COPY . .

RUN dotnet publish ./BCFM/*.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=sdkimage /publish .
ENV ASPNETCORE_URLS="http://*:80"
ENTRYPOINT ["dotnet", "BCFM.dll"]
