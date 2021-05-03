using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class AccountController : Controller
    {
        QuanLyBanHangdbContext db = new QuanLyBanHangdbContext();
        [AllowAnonymous]
        //Action Login(HttpGet), mặc định là get
        public ViewResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        //nhận dữ liệu từ client gửi lên
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account acc, string returnUrl)
        {
            // Nếu vượt qua được validation ở accounmodel
            if (ModelState.IsValid)
            {
                var model = db.Accounts.Where(m => m.Username == acc.Username && m.Password == acc.Password).ToList().Count();
                //kiểm tra thông tin đăng nhập
                if (model == 1)
                {
                    //set cookie
                    FormsAuthentication.SetAuthCookie(acc.Username, true);
                    return RedirectToLocal(returnUrl);
                }
            }
            return View(acc);
        }
        //hàm đăng xuất khỏi chương trình
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //Kiểm tra xem returUrl có thuộc hệ thống hay không
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}