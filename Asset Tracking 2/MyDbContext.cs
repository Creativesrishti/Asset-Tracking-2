using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFLex1
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }

        string connectionString = "Data Source=DESKTOP-5O4KFQG;Initial Catalog=AssetTracking;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
