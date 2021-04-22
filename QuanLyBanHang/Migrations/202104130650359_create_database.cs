namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDonHangs",
                c => new
                    {
                        CTDH_ID = c.String(nullable: false, maxLength: 10),
                        Ma_PDH = c.String(maxLength: 10),
                        TenMatHang = c.String(),
                        SoLuong = c.Int(nullable: false),
                        TongTien = c.Int(nullable: false),
                        NgayMuaHang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CTDH_ID)
                .ForeignKey("dbo.PhieuDonHangs", t => t.Ma_PDH)
                .Index(t => t.Ma_PDH);
            
            CreateTable(
                "dbo.PhieuDonHangs",
                c => new
                    {
                        Ma_PDH = c.String(nullable: false, maxLength: 10),
                        ThanhTienID = c.String(maxLength: 10),
                        NgayDatHang = c.DateTime(nullable: false),
                        SĐT = c.Int(nullable: false),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.Ma_PDH)
                .ForeignKey("dbo.ThanhTiens", t => t.ThanhTienID)
                .Index(t => t.ThanhTienID);
            
            CreateTable(
                "dbo.ThanhTiens",
                c => new
                    {
                        ThanhTienID = c.String(nullable: false, maxLength: 10),
                        MaHoaDon = c.String(maxLength: 10, fixedLength: true),
                        NgayBan = c.DateTime(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        TongTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThanhTienID)
                .ForeignKey("dbo.HoaDons", t => t.MaHoaDon)
                .Index(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        MaKhachHang = c.String(maxLength: 10, unicode: false),
                        MaNhanVien = c.String(maxLength: 10, fixedLength: true),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        MaMatHang = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhachHang)
                .ForeignKey("dbo.MatHangs", t => t.MaMatHang)
                .ForeignKey("dbo.NhanViens", t => t.MaNhanVien)
                .Index(t => t.MaKhachHang)
                .Index(t => t.MaNhanVien)
                .Index(t => t.MaMatHang);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKhachHang = c.String(nullable: false, maxLength: 10, unicode: false),
                        HoVaTen = c.String(),
                        MaHoaDon = c.String(),
                        DiaChi = c.Int(nullable: false),
                        SĐT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.MatHangs",
                c => new
                    {
                        MaMatHang = c.String(nullable: false, maxLength: 10),
                        TenMatHang = c.String(),
                        LoaiMatHang = c.String(),
                        HangSX = c.String(),
                        NgaySX = c.DateTime(nullable: false),
                        GiaBan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaMatHang);
            
            CreateTable(
                "dbo.KhoHangs",
                c => new
                    {
                        MaKhoHang = c.String(nullable: false, maxLength: 10),
                        NgayNhapKho = c.DateTime(nullable: false),
                        MaMatHang = c.String(maxLength: 10),
                        SoLuongTonKho = c.Int(nullable: false),
                        NhaCC = c.String(),
                    })
                .PrimaryKey(t => t.MaKhoHang)
                .ForeignKey("dbo.MatHangs", t => t.MaMatHang)
                .Index(t => t.MaMatHang);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNhanVien = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        TenNhanVien = c.String(),
                        GioiTinh = c.String(),
                        SĐT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        TinID = c.Int(nullable: false, identity: true),
                        TacGia = c.String(),
                        NoiDung = c.String(),
                    })
                .PrimaryKey(t => t.TinID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuDonHangs", "ThanhTienID", "dbo.ThanhTiens");
            DropForeignKey("dbo.ThanhTiens", "MaHoaDon", "dbo.HoaDons");
            DropForeignKey("dbo.HoaDons", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.KhoHangs", "MaMatHang", "dbo.MatHangs");
            DropForeignKey("dbo.HoaDons", "MaMatHang", "dbo.MatHangs");
            DropForeignKey("dbo.HoaDons", "MaKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.ChiTietDonHangs", "Ma_PDH", "dbo.PhieuDonHangs");
            DropIndex("dbo.KhoHangs", new[] { "MaMatHang" });
            DropIndex("dbo.HoaDons", new[] { "MaMatHang" });
            DropIndex("dbo.HoaDons", new[] { "MaNhanVien" });
            DropIndex("dbo.HoaDons", new[] { "MaKhachHang" });
            DropIndex("dbo.ThanhTiens", new[] { "MaHoaDon" });
            DropIndex("dbo.PhieuDonHangs", new[] { "ThanhTienID" });
            DropIndex("dbo.ChiTietDonHangs", new[] { "Ma_PDH" });
            DropTable("dbo.TinTucs");
            DropTable("dbo.NhanViens");
            DropTable("dbo.KhoHangs");
            DropTable("dbo.MatHangs");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.ThanhTiens");
            DropTable("dbo.PhieuDonHangs");
            DropTable("dbo.ChiTietDonHangs");
        }
    }
}
