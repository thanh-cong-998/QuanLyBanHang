using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class MatHang
    {
        [Key]
        [StringLength(10)]
        public string MaMatHang { get; set; }
        public string TenMatHang { get; set; }
        public string LoaiMatHang { get; set; }
        public string HangSX { get; set; }
        public string NgaySX { get; set; }
        public string GiaBan { get; set; }
        public virtual ICollection<HoaDon> hoaDons { get; set; }
        public virtual ICollection<KhoHang> KhoHangs { get; set; }
    }
}