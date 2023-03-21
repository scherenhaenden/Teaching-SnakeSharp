FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SnakeSharpBlazor/Client/SnakeSharpBlazor.Client.csproj", "SnakeSharpBlazor/Client/"]
COPY ["SnakeSharpBlazor/Shared/SnakeSharpBlazor.Shared.csproj", "SnakeSharpBlazor/Shared/"]
RUN dotnet restore "SnakeSharpBlazor/Client/SnakeSharpBlazor.Client.csproj"
COPY . .
WORKDIR "/src/SnakeSharpBlazor/Client"
RUN dotnet build "SnakeSharpBlazor.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnakeSharpBlazor.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnakeSharpBlazor.Client.dll"]
