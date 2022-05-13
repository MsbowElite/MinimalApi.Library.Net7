#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MinimalApi.Library.Net7/MinimalApi.Library.Net7.csproj", "MinimalApi.Library.Net7/"]
RUN dotnet restore "MinimalApi.Library.Net7/MinimalApi.Library.Net7.csproj"
COPY . .
WORKDIR "/src/MinimalApi.Library.Net7"
RUN dotnet build "MinimalApi.Library.Net7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinimalApi.Library.Net7.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinimalApi.Library.Net7.dll"]