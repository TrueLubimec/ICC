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

            modelBuilder.Entity<PersonalAccount>().HasData(new PersonalAccount
            {
                Id = 1,
                AccountNum = "1_2024_AB",
                EffectiveDate = new System.DateTime(2024,03,02),
                ExpirationDate = new System.DateTime(2027,03,01),
                Address = "103132, г. Москва, Ивановская площадь",
                Square = 277000,
                Residents = " "
            });

            modelBuilder.Entity<Resident>().HasData(new Resident
            {
                Id = 1,
                PersonalAccountId = 1,
                FirstName = "Ева",
                LastName = "Кернс",
                Email = "eva@gmail.com"
            });
        }

        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<Resident> Residents { get; set; }
    }
}
