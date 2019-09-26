FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Blog.Server/Blog.Server.csproj", "src/Blog.Server/"]
RUN dotnet restore "src/Blog.Server/Blog.Server.csproj"
COPY . .
WORKDIR "/src/src/Blog.Server"
RUN dotnet build "Blog.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blog.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.Server.dll"]