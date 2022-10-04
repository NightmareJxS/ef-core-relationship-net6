# Welcome to EF-Core-Relationships-NET6 Repository
### This is where I test and trying to learn/implement Entity Framework in a .NET 6 web API project

#### Included relationships:
* 1-1
* 1-n
* n-n

## Entity Framework (Summary) (Create new Database)
1. Create Data models
2. Create DataContext
3. Add ConnectionString in appsetting.json
4. Edit Program.cs (AddDbContext)
5. Basic Commands (Package Manager Console):
    + cd .\{ProjectName}
    + dotnet ef migrations add {Name}
    + dotnet ef database update

## Connect to existed Database
1. Scaffold-DbContext (Package Manager Console):
    + Scaffold-DbContext "Server=(local);database= {Database Name};Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
2. Add ConnectionString in appsetting.json
3. Edit Program.cs (AddDbContext)
