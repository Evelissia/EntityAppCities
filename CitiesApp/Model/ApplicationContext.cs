using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace CitiesApp.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<City> Cities => Set<City>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=citiesBd;Trusted_Connection=True;");
        }
    }
}
