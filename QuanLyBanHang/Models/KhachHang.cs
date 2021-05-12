using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class KhachHang
    {
        [Key]
        [StringLength(10)]
        public string MaKhachHang { get; set; }
        public string HoVaTen { get; set; }
        public string DiaChi { get; set; }
        public string SĐT { get; set; }
        public ICollection<HoaDon> HoaDons  { get; set; }
    }
}