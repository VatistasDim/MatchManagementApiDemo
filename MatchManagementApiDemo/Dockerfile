#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MatchManagementApiDemo/MatchManagementApiDemo.csproj", "MatchManagementApiDemo/"]
RUN dotnet restore "MatchManagementApiDemo/MatchManagementApiDemo.csproj"
COPY . .
WORKDIR "/src/MatchManagementApiDemo"
RUN dotnet build "MatchManagementApiDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MatchManagementApiDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatchManagementApiDemo.dll"]