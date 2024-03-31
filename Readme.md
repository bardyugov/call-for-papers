# CallForPapers

# Start
    dotnet tool install --global dotnet-ef
    cd Docker
    docker-compose up
    cd ..
    dotnet ef database update --project CallForPapers.Infrastructure --startup-project CallForPapers.Core
    cd CallForPapers.Core
    dotnet run

# Swagger 
    http://localhost:5126/swagger/index.html