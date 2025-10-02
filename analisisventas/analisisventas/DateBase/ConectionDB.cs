using analisisventas.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace analisisventas.DateBase
{
    
        public class ConectionDB: DbContext
        {
            public DbSet<products> Productos { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.UseSqlServer(
                "Server=YADIANNA;Database=SalesAnalytics;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
            );
        }
    }
    
}
