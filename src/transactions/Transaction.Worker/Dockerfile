#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/transactions/Transaction.Worker/Transaction.Worker.csproj", "src/transactions/Transaction.Worker/"]
RUN dotnet restore "src/transactions/Transaction.Worker/Transaction.Worker.csproj"
COPY . .
WORKDIR "/src/src/transactions/Transaction.Worker"
RUN dotnet build "Transaction.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transaction.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transaction.Worker.dll"]