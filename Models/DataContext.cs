using Microsoft.EntityFrameworkCore;

namespace ProductManagementWebAPI.Models
{
    public class DataContext: DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.;initial catalog=PMWADb;integrated security=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }



    }
}
