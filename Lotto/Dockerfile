FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY Lotto/Lotto.csproj Lotto/
RUN dotnet restore Lotto/Lotto.csproj
COPY . .
WORKDIR /src/Lotto
RUN dotnet build Lotto.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Lotto.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Lotto.dll"]
