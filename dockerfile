FROM microsoft/dotnet:2.1-sdk as build
WORKDIR /app
COPY server ./server/
RUN dotnet restore server/server.fsproj
RUN dotnet publish -c Release -o out server/server.fsproj
FROM microsoft/dotnet:2.1-runtime as runtime
WORKDIR /app
COPY --from=build /app/server/out ./
COPY client ./client/
CMD dotnet server.dll
