namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        GoruntulenmeSayisi = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        YorumID = c.Int(nullable: false, identity: true),
                        YorumIcerik = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        YorumYapanId = c.String(maxLength: 128),
                        Blog_BlogID = c.Int(),
                    })
                .PrimaryKey(t => t.YorumID)
                .ForeignKey("dbo.AspNetUsers", t => t.YorumYapanId)
                .ForeignKey("dbo.Blogs", t => t.Blog_BlogID)
                .Index(t => t.YorumYapanId)
                .Index(t => t.Blog_BlogID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorums", "Blog_BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Yorums", "YorumYapanId", "dbo.AspNetUsers");
            DropIndex("dbo.Yorums", new[] { "Blog_BlogID" });
            DropIndex("dbo.Yorums", new[] { "YorumYapanId" });
            DropTable("dbo.Yorums");
            DropTable("dbo.Blogs");
        }
    }
}
