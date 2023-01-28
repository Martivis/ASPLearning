#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/ASPLearning.Api/ASPLearning.Api.csproj", "Systems/ASPLearning.Api/"]
COPY ["Data/ASPLearning.Context.Entities/ASPLearning.Context.Entities.csproj", "Data/ASPLearning.Context.Entities/"]
COPY ["Data/ASPLearning.Context/ASPLearning.Context.csproj", "Data/ASPLearning.Context/"]
COPY ["Shared/ASPLearning.Settings/ASPLearning.Settings.csproj", "Shared/ASPLearning.Settings/"]
COPY ["Data/Migrations/ASPLearning.Context.MigrationsMSSQL/ASPLearning.Context.MigrationsMSSQL.csproj", "Data/Migrations/ASPLearning.Context.MigrationsMSSQL/"]
COPY ["Data/Migrations/ASPLearning.Context.MigrationsPostgreSQL/ASPLearning.Context.MigrationsPostgreSQL.csproj", "Data/Migrations/ASPLearning.Context.MigrationsPostgreSQL/"]
COPY ["Services/ASPLearning.Services.Texts/ASPLearning.Services.Texts.csproj", "Services/ASPLearning.Services.Texts/"]
COPY ["Shared/ASPLearning.Common/ASPLearning.Common.csproj", "Shared/ASPLearning.Common/"]
RUN dotnet restore "Systems/ASPLearning.Api/ASPLearning.Api.csproj"
COPY . .
WORKDIR "/src/Systems/ASPLearning.Api"
RUN dotnet build "ASPLearning.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ASPLearning.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASPLearning.Api.dll"]