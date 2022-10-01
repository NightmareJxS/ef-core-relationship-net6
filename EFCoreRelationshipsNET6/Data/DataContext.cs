using EFCoreRelationshipsNET6.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsNET6.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        // Defining table for DB
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills{ get; set; }
    }
}
