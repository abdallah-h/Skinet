//run app
dotnet watch run

//add packages
dotnet add package Microsoft.EntityFrameworkCore --version
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version
dotnet add package Microsoft.EntityFrameworkCore.Design --version
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

// progects setup
dotnet new classlib -o Core
dotnet new classlib -o Infrastructure
dotnet sln add Core
dotnet sln add Infrastructure
dotnet add reference ../Core
dotnet add reference ../Infrastructure

// drop database
dotnet ef database drop -p Infrastructure -s API

//remove migrations
dotnet ef migrations remove -p Infrastructure -s API

// generate new migrations
dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations

// swagger
dotnet add package Swashbuckle.AspNetCore.SwaggerGen
dotnet add package Swashbuckle.AspNetCore.SwaggerUi

dotnet restore

