FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ConsoleSort.csproj", "./"]
RUN dotnet restore "ConsoleSort.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ConsoleSort.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleSort.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleSort.dll"]
