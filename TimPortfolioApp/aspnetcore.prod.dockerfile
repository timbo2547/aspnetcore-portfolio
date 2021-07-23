FROM mcr.microsoft.com/dotnet/core/sdk AS build
RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
ENV PATH="$PATH:/root/.dotnet/tools"
WORKDIR /var/www/aspnetcoreapp

RUN libman restore

# copy csproj and restore as distinct layers
COPY ./*.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY ./ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /var/www/aspnetcoreapp
COPY --from=build /var/www/aspnetcoreapp/out ./
ENTRYPOINT ["dotnet", "TimPortfolioApp.dll"]



