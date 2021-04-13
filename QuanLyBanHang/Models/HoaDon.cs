using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class HoaDon
    {
        [Key]
        [StringLength(10)]
        public string MaHoaDon { get; set; }
        [StringLength(10)]
        public string MaKhachHang { get; set; }
        [StringLength(10)]
        public string MaNhanVien { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public string MaMatHang { get; set; }
        public virtual MatHang MatHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual ICollection<ThanhTien> ThanhTiens { get; set; }
    }
}