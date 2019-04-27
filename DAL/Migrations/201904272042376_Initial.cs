namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false),
                        Icerik = c.String(),
                        Etiket = c.String(nullable: false, maxLength: 100),
                        GoruntulenmeSayisi = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Turs",
                c => new
                    {
                        TurID = c.Int(nullable: false, identity: true),
                        TurAdi = c.String(nullable: false),
                        TurAciklama = c.String(),
                    })
                .PrimaryKey(t => t.TurID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GrupAdi = c.String(nullable: false, maxLength: 100),
                        Aciklama = c.String(nullable: false),
                        WebSite = c.String(),
                        Resim = c.String(),
                        YoutubeLinki = c.String(),
                        GrupUyeleri = c.String(),
                        Begeni = c.Int(nullable: false),
                        TurID = c.Int(),
                        KurulusTarihi = c.DateTime(),
                        SiteKayitTarihi = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Turs", t => t.TurID)
                .Index(t => t.TurID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        YorumID = c.Int(nullable: false, identity: true),
                        YorumIcerik = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        YorumYapanId = c.String(maxLength: 128),
                        BlogYorumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YorumID)
                .ForeignKey("dbo.Blogs", t => t.BlogYorumID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.YorumYapanId)
                .Index(t => t.YorumYapanId)
                .Index(t => t.BlogYorumID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorums", "YorumYapanId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Yorums", "BlogYorumID", "dbo.Blogs");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "TurID", "dbo.Turs");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Yorums", new[] { "BlogYorumID" });
            DropIndex("dbo.Yorums", new[] { "YorumYapanId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "TurID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Yorums");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Turs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Blogs");
        }
    }
}
