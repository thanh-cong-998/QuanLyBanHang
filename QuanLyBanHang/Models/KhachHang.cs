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
        public string MaHoaDon { get; set; }
        public int DiaChi { get; set; }
        public int SĐT { get; set; }
        public ICollection<HoaDon> HoaDons  { get; set; }
    }
}