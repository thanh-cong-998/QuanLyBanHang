namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoLes",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Accounts", "RoleID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "RoleID");
            DropTable("dbo.RoLes");
        }
    }
}
