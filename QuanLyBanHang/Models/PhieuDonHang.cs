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
        public string ThanhTienID { get; set; }
        public DateTime NgayDatHang { get; set; }
        public int SĐT { get; set; }
        public string DiaChi { get; set; }
        public virtual ThanhTien ThanhTien { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}