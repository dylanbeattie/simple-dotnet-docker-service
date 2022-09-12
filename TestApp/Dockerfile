# To build the Docker image:
# from the PARENT DIRECTORY (..), run:
# docker build -f .\TestApp\Dockerfile -t testapp .

# Then run the Docker image with:
# docker run testapp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY TestApp/*.csproj ./TestApp/
RUN dotnet restore TestApp/TestApp.csproj

# copy everything else and build app
COPY TestApp/. ./TestApp/
WORKDIR /source/TestApp
RUN dotnet build -c Release
RUN dotnet publish -c release -o /published

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /published
COPY --from=build /published ./
ENTRYPOINT ["dotnet", "TestApp.dll"]