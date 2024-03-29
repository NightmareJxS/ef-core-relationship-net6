# Welcome to EF-Core-Relationships-NET6 Repository
### This is where I test and trying to learn/implement Entity Framework in a .NET 6 web API project

#### Included relationships:
* 1-1
* 1-n
* n-n

### Required NuGet Package
![Required NuGet Package](https://github.com/NightmareJxS/ef-core-relationship-net6/blob/main/images/RequiredNugetPackage.PNG)

## Entity Framework (Summary) (Create new Database)
1. Create Data models
2. Create DataContext (remember the 2 important contructor):
    ```C#
        public YourDBContext()
        {

        }

        public YourDBContext(DbContextOptions<YourDBContext> options) : base(options) 
        {
            
        }
    ```
4. Add ConnectionString in appsetting.json
5. Edit Program.cs (AddDbContext)
6. Basic Commands (Package Manager Console):
    + cd .\{ProjectName}
    + dotnet ef migrations add {Name}
    + dotnet ef database update
7. New simplify command for (5.):
    + Add-Migration [Name]
    + Update-Database
8. For creating DB with 3 layers model (the appsetting.json is on different layer). To bypass:
    + Set up correct Default Package (In Package Manager Console) and Startup Project
    + In YourDBContext:
        + Must override OnConfiguring
            ```C#
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    if (!optionsBuilder.IsConfigured)
                    {
                        IConfiguration config = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json").Build();


                        string connectionString = config.GetConnectionString("DefaultConnection");
                        optionsBuilder.UseSqlServer(connectionString);
                    }

                    base.OnConfiguring(optionsBuilder);
                }
            ```

## Connect to existed Database
1. Scaffold-DbContext (Package Manager Console):
    ```
    Scaffold-DbContext "Server=(local);database= {Database Name};Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
    ```
2. Add ConnectionString in appsetting.json
3. Edit Program.cs (AddDbContext)
