FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Api2/Diogo.Softplan.Challenge.Api2.Api/Diogo.Softplan.Challenge.Api2.Api.csproj src/Api2/Diogo.Softplan.Challenge.Api2.Api/
COPY src/Api2/Diogo.Softplan.Challenge.Api2.Domain/Diogo.Softplan.Challenge.Api2.Domain.csproj src/Api2/Diogo.Softplan.Challenge.Api2.Domain/
COPY src/Api2/Diogo.Softplan.Challenge.Api2.Infrastructure.Http/Diogo.Softplan.Challenge.Api2.Infrastructure.Http.csproj src/Api2/Diogo.Softplan.Challenge.Api2.Infrastructure.Http/
RUN dotnet restore src/Api2/Diogo.Softplan.Challenge.Api2.Api/Diogo.Softplan.Challenge.Api2.Api.csproj
COPY . .

WORKDIR /src/src/Api2/tests/Diogo.Softplan.Challenge.Api2.Tests
RUN dotnet test

WORKDIR /src/src/Api2/tests/Diogo.Softplan.Challenge.Api2.Integration.Tests
RUN dotnet test

WORKDIR /src/src/Api2/Diogo.Softplan.Challenge.Api2.Api
RUN dotnet build Diogo.Softplan.Challenge.Api2.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Diogo.Softplan.Challenge.Api2.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Diogo.Softplan.Challenge.Api2.Api.dll"]
