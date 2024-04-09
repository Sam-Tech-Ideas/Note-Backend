FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5110

ENV ASPNETCORE_URLS=http://+:5110

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Note.API/Note.API.csproj", "Note.API/"]
RUN dotnet restore "Note.API/Note.API.csproj"
COPY . .
WORKDIR "/src/Note.API"
RUN dotnet build "Note.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Note.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Note.API.dll"]
