using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class RoLe
    {
        [Key]
        public string RoleID { get; set; }
        public string RoleName { get; set; }
    }
}