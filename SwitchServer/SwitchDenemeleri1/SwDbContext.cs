using Microsoft.EntityFrameworkCore;

namespace SwitchDenemeleri1
{
    public class SwDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            base.OnConfiguring(optionsBuilder);



            optionsBuilder.UseSqlServer("Server = DESKTOP-KSMHQBN ; Database = DigerBankaDB2; uid = sa ; pwd = 1234;TrustServerCertificate=True;");

        }




       

        public DbSet<Loglar> Loglar { get; set; }

    }
}
