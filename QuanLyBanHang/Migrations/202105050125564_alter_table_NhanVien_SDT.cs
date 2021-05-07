namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_table_NhanVien_SDT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanViens", "SĐT", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanViens", "SĐT", c => c.Int(nullable: false));
        }
    }
}
