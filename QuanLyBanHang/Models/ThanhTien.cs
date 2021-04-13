using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class ThanhTien
    {
        [Key]
        [StringLength(10)]
        public string ThanhTienID { get; set; }
        public string MaHoaDon { get; set; }
        public DateTime NgayBan { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int TongTien { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}