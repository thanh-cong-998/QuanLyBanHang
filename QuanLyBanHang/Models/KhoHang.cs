using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class KhoHang
    {
        [Key]
        [StringLength(10)]
        public string MaKhoHang { get; set; }
        public DateTime NgayNhapKho { get; set; }
        public string MaMatHang { get; set; }
        public int SoLuongTonKho { get; set; }
        public string NhaCC { get; set; }
        public virtual MatHang MatHangs { get; set; }
    }
}