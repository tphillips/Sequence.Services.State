FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Sequence.Services.State.csproj", "./"]
RUN dotnet restore "Sequence.Services.State.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Sequence.Services.State.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sequence.Services.State.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sequence.Services.State.dll"]
