using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class PhieuDonHang
    {
        [Key]
        [StringLength(10)]
        public string Ma_PDH { get; set; }
        [StringLength(10)]
        public string MaHoaDon { get; set; }
        public DateTime NgayDatHang { get; set; }
        public string SĐT { get; set; }
        public string DiaChi { get; set; }
        public virtual ICollection<ThanhTien> ThanhTiens { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}