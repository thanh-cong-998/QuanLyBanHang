namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Article : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.String(nullable: false, maxLength: 128, unicode: false),
                        Author = c.String(),
                        ArticleContent = c.String(),
                    })
                .PrimaryKey(t => t.ArticleID);
            
            DropTable("dbo.TinTucs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        TinID = c.Int(nullable: false, identity: true),
                        TacGia = c.String(),
                        NoiDung = c.String(),
                    })
                .PrimaryKey(t => t.TinID);
            
            DropTable("dbo.Articles");
        }
    }
}
