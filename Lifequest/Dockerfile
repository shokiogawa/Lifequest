FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /lifequest
COPY Lifequest.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet dev-certs https --clean && dotnet dev-certs https -t