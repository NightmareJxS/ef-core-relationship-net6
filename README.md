# Welcome to EF-Core-Relationships-NET6 Repository
### This is where I test and trying to learn/implement Entity Framework in a .NET 6 web API project

#### Included relationships:
* 1-1
* 1-n
* n-n

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
    + In Program.cs (.NET6; You need to inject the appsetting config to DI:
        ```C#
            // Load the appsettings.json file
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            // Inject the configuration object into the DI container
            builder.Services.AddSingleton(config);
        ```
     + In YourDBContext:
        + Maybe* add a DI contructor
            ```C#
                public SchoolDBContext(IConfiguration config)
                {
                    _config = config;
                }
            ```
        + Must override OnConfiguring
            ```C#
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    if (!optionsBuilder.IsConfigured)
                    {
                        string connectionString = _config.GetConnectionString("DefaultConnection");
                        optionsBuilder.UseSqlServer(connectionString);
                    }

                    base.OnConfiguring(optionsBuilder);
                }
            ```

## Connect to existed Database
1. Scaffold-DbContext (Package Manager Console):
    + Scaffold-DbContext "Server=(local);database= {Database Name};Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
2. Add ConnectionString in appsetting.json
3. Edit Program.cs (AddDbContext)
