#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/ASPLearning.Identity/ASPLearning.Identity.csproj", "Systems/ASPLearning.Identity/"]
COPY ["Data/ASPLearning.Context.Entities/ASPLearning.Context.Entities.csproj", "Data/ASPLearning.Context.Entities/"]
COPY ["Data/ASPLearning.Context/ASPLearning.Context.csproj", "Data/ASPLearning.Context/"]
COPY ["Shared/ASPLearning.Settings/ASPLearning.Settings.csproj", "Shared/ASPLearning.Settings/"]
COPY ["Shared/ASPLearning.Common/ASPLearning.Common.csproj", "Shared/ASPLearning.Common/"]
RUN dotnet restore "Systems/ASPLearning.Identity/ASPLearning.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/ASPLearning.Identity"
RUN dotnet build "ASPLearning.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ASPLearning.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASPLearning.Identity.dll"]