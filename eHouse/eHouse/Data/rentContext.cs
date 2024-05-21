using Microsoft.EntityFrameworkCore;

namespace eHouse.Data
{
    public class rentContext: DbContext
    {
        public rentContext(DbContextOptions<rentContext>options) :base(options)
        {

        }
        public DbSet<rent> rent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=rent;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
