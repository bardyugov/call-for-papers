# CallForPapers

# Start
    dotnet tool install --global dotnet-ef
    cd Docker
    docker-compose up
    cd ..
    dotnet ef database update --project CallForPapers.Migrations --startup-project CallForPapers.Api
    cd CallForPapers.Api
    dotnet run

# Swagger 
    http://localhost:5121/swagger/index.html
