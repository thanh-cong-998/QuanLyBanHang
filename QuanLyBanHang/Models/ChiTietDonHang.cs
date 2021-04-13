using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class ChiTietDonHang
    {
        [Key]
        [StringLength(10)]
        public string CTDH_ID { get; set; }
        public string Ma_PDH { get; set; }
        public string TenMatHang { get; set; }
        public int SoLuong { get; set; }
        public int TongTien { get; set; }
        public DateTime NgayMuaHang { get; set; }
        public virtual PhieuDonHang PhieuDonHang { get; set; }
    }
}