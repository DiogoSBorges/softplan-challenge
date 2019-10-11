FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Api1/Diogo.Softplan.Challenge.Api1.Api/Diogo.Softplan.Challenge.Api1.Api.csproj src/Api1/Diogo.Softplan.Challenge.Api1.Api/
COPY src/Api1/Diogo.Softplan.Challenge.Api1.Application/Diogo.Softplan.Challenge.Api1.Application.csproj src/Api1/Diogo.Softplan.Challenge.Api1.Application/
COPY src/Api1/Diogo.Softplan.Challenge.Api1.Domain/Diogo.Softplan.Challenge.Api1.Domain.csproj src/Api1/Diogo.Softplan.Challenge.Api1.Domain/
RUN dotnet restore src/Api1/Diogo.Softplan.Challenge.Api1.Api/Diogo.Softplan.Challenge.Api1.Api.csproj
COPY . .

WORKDIR /src/src/Api1/tests/Diogo.Softplan.Challenge.Api1.Tests
RUN dotnet test

WORKDIR /src/src/Api1/tests/Diogo.Softplan.Challenge.Api1.Integration.Tests
RUN dotnet test

WORKDIR /src/src/Api1/Diogo.Softplan.Challenge.Api1.Api
RUN dotnet build Diogo.Softplan.Challenge.Api1.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Diogo.Softplan.Challenge.Api1.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Diogo.Softplan.Challenge.Api1.Api.dll"]
