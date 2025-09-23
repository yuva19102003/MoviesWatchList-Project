# Use .NET SDK because EF tools are needed
FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /app

# Copy your published migration project
COPY ./publish ./

# Install EF CLI tool
RUN dotnet tool install --global dotnet-ef --version 9.*
ENV PATH="$PATH:/root/.dotnet/tools"

# Default command: run EF Core migrations (update database)
ENTRYPOINT ["dotnet", "ef", "database", "update", "--project", "MovieWatchList.Migrations.dll"]
