FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Api1/Diogo.Softplan.Challenge.Api1.Api/Diogo.Softplan.Challenge.Api1.Api.csproj", "src/Api1/Diogo.Softplan.Challenge.Api1.Api/"]
RUN dotnet restore "src/Api1/Diogo.Softplan.Challenge.Api1.Api/Diogo.Softplan.Challenge.Api1.Api.csproj"
COPY . .
WORKDIR "/src/src/Api1/Diogo.Softplan.Challenge.Api1.Api"
RUN dotnet build "Diogo.Softplan.Challenge.Api1.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diogo.Softplan.Challenge.Api1.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diogo.Softplan.Challenge.Api1.Api.dll"]