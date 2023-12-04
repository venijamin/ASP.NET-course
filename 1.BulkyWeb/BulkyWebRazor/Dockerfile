FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BulkyWebRazor/BulkyWebRazor.csproj", "BulkyWebRazor/"]
RUN dotnet restore "BulkyWebRazor/BulkyWebRazor.csproj"
COPY . .
WORKDIR "/src/BulkyWebRazor"
RUN dotnet build "BulkyWebRazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BulkyWebRazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BulkyWebRazor.dll"]
