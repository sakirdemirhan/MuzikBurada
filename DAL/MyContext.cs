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
        public virtual DbSet<Blog> Bloglar { get; set; }
        public virtual DbSet<Yorum> Yorumlar { get; set; }

    }
}
