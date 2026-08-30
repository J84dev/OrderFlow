FROM mcr.microsoft.com/dotnet/sdk:10.0

# CLI do EF Core, útil pra migrations dentro do container
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"