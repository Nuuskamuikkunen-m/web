#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Notes.Web.PL/Notes.Web.PL.csproj", "Notes.Web.PL/"]
COPY ["Notes.BLLIntefaces/Notes.BLLIntefaces.csproj", "Notes.BLLIntefaces/"]
COPY ["Notes.Entites/Notes.Entities.csproj", "Notes.Entites/"]
COPY ["Notes.BLL/Notes.BLL.csproj", "Notes.BLL/"]
COPY ["Notes.DALInterfaces/Notes.DALInterfaces.csproj", "Notes.DALInterfaces/"]
COPY ["Notes.DAL/Notes.DAL.csproj", "Notes.DAL/"]
COPY ["Notes.Dependencies/Notes.Dependencies.csproj", "Notes.Dependencies/"]
RUN dotnet restore "Notes.Web.PL/Notes.Web.PL.csproj"
COPY . .
WORKDIR "/src/Notes.Web.PL"
RUN dotnet build "Notes.Web.PL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notes.Web.PL.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notes.Web.PL.dll"]