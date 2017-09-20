using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Web;
using Web.Models.Ef;

namespace Web.Models
{
    public class EFContext : DbContext
    {


        public EFContext() : base("connectionStringMain")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EFContext>(null);
            base.OnModelCreating(modelBuilder);
            //this.Configuration.LazyLoadingEnabled = false;
            //
        

            modelBuilder.Entity<SensorLine>().ToTable("Sensors");

        }

        public DbSet<SensorLine> Sensors { get; set; }
        

    }
}
