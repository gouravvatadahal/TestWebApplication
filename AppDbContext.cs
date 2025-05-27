using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define a DbSet for your table (replace 'YourTable' with the actual table name)
        public DbSet<ClientFeatures> ClientFeatures { get; set; }
    }

    // Define the entity class for your table
    public class ClientFeatures
    {
        public int ID { get; set; } // Replace with your table's primary key column
        public string Name { get; set; } // Replace with your table's columns
        public string Abbreviation { get; set; } // Add other properties as needed
    }
}
