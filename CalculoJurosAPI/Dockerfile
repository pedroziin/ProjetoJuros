FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CalculoJurosAPI/CalculoJurosAPI.csproj", "CalculoJurosAPI/"]
RUN dotnet restore "CalculoJurosAPI/CalculoJurosAPI.csproj"
COPY . .
WORKDIR "/src/CalculoJurosAPI"
RUN dotnet build "CalculoJurosAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculoJurosAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculoJurosAPI.dll"]