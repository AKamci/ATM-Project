
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using Entities;

namespace DataAccess
{
    public class SifreDbContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            base.OnConfiguring(optionsBuilder);



            optionsBuilder.UseSqlServer("Server = DESKTOP-KSMHQBN ; Database = DigerBankaDB2; uid = sa ; pwd = 1234;TrustServerCertificate=True;");

        }


       

        public DbSet<MusteriSifre> TabloSifre { get; set; }

        public DbSet<Loglar> Loglar { get; set; }




    }
}
