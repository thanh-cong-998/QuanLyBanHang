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
        public string Ma_PDH { get; set; }
        public DateTime NgayBan { get; set; }
        public int SoLuong { get; set; }
        public string DonGia { get; set; }
        public string TongTien { get; set; }
        public virtual PhieuDonHang PhieuDonHang { get; set; }
    }
}