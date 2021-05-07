using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public string SĐT { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}