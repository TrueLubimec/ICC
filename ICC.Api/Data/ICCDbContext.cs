using ICC.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICC.Api.Data
{
    public class ICCDbContext : DbContext
    {
        public ICCDbContext(DbContextOptions<ICCDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<Resident> Residents { get; set; }
    }
}
