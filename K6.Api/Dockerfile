#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["K6.Api/K6.Api.csproj", "K6.Api/"]
RUN dotnet restore "K6.Api/K6.Api.csproj"
COPY . .
WORKDIR "/src/K6.Api"
RUN dotnet build "K6.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "K6.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "K6.Api.dll"]