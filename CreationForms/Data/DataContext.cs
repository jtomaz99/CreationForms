global using Microsoft.EntityFrameworkCore;
using CreationForms.Data.Map;

namespace CreationForms.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=FYLD2021004;Initial Catalog=Heroes;Integrated Security=True;Trust Server Certificate=True");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SuperHeroMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}