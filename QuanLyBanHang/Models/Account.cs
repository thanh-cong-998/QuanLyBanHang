using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        //validation with Model
        //User ko dc để trống
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        //password ko dc để trống
        [Required(ErrorMessage = "Password is required.")]
        //định nghĩa datatype
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string RoleID { get; set; }
    }
}