using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyBanHang.Models
{
    public partial class QuanLyBanHangdbContext : DbContext
    {
        public QuanLyBanHangdbContext()
            : base("name=QuanLyBanHangdbContext")
        {
        }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<MatHang> MatHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<PhieuDonHang> PhieuDonHangs { get; set; }
        public virtual DbSet<ThanhTien> ThanhTiens { get; set; }
        public virtual DbSet<KhoHang> KhoHangs { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
      
        public virtual DbSet<RoLe> RoLes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength();

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHoaDon)
                .IsFixedLength();

            modelBuilder.Entity<Article>()
               .Property(e => e.ArticleID)
               .IsUnicode(false);

        }

        public System.Data.Entity.DbSet<QuanLyBanHang.Models.Account> Accounts { get; set; }

    }
}
