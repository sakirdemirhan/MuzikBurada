using Entitiy.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MyContext : IdentityDbContext<Kullanici>
    {
        public static MyContext db;
        public MyContext() : base("DefaultConnection")
        {

        }

        public virtual DbSet<Tur> Turler { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Kullanici>()
            //.HasRequired(b => b.KullaniciTur)
            //.WithMany(u => u.)
            //.HasConstraint((Kullanici b, Tur t) => b.TurID == t.TurID);
        }
    }
}
