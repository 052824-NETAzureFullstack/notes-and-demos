# build the image (application/environment for the app)

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/publish

# run the image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS run
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "./MusicAPI.dll"]