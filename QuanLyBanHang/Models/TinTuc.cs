using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class TinTuc
    {
        [Key]
        public int TinID { get; set; }
        public string TacGia { get; set; }
        public string NoiDung { get; set; }
    }
}