namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Entitiy.Models;
    using Microsoft.AspNet.Identity;


    internal sealed class Configuration : DbMigrationsConfiguration<DAL.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.MyContext context)
        {
            #region rolleriOlustur
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole() { Name = "Admin" });
                context.Roles.Add(new IdentityRole() { Name = "BlogModerator" });
                context.SaveChanges();
            }
            #endregion

            if (!context.Users.Any())
            {
                #region kullaniciEkle
                UserStore<Kullanici> str = new UserStore<Kullanici>(new MyContext());
                UserManager<Kullanici> mng = new UserManager<Kullanici>(str);

                var admin = new Kullanici() { Email = "admin@admin.com", UserName = "Admin", GrupAdi = "Admin", Aciklama = "Yonetici" };
                var blogModerator = new Kullanici() { Email = "blogmoderator@admin.com", UserName = "Moderator", GrupAdi = "Moderator", Aciklama = "YoneticiBlog" };


                mng.Create(admin, "Asdf.123"); //2. parametre ifresi
                mng.Create(blogModerator, "Asdf.123");
                context.SaveChanges();

                #endregion

                #region kullanicilariRollereEkle
                mng.AddToRole(admin.Id, "Admin");
                mng.AddToRole(blogModerator.Id, "BlogModerator");
                context.SaveChanges();
                #endregion

            }
        }
    }
}