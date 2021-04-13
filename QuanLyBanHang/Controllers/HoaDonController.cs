using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class HoaDonController : Controller
    {
        private QuanLyBanHangdbContext db = new QuanLyBanHangdbContext();

        // GET: HoaDon
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.KhachHang).Include(h => h.MatHang).Include(h => h.NhanVien);
            return View(hoaDons.ToList());
        }

        // GET: HoaDon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "HoVaTen");
            ViewBag.MaMatHang = new SelectList(db.MatHangs, "MaMatHang", "TenMatHang");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,MaKhachHang,MaNhanVien,SoLuong,DonGia,MaMatHang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "HoVaTen", hoaDon.MaKhachHang);
            ViewBag.MaMatHang = new SelectList(db.MatHangs, "MaMatHang", "TenMatHang", hoaDon.MaMatHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", hoaDon.MaNhanVien);
            return View(hoaDon);
        }

        // GET: HoaDon/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "HoVaTen", hoaDon.MaKhachHang);
            ViewBag.MaMatHang = new SelectList(db.MatHangs, "MaMatHang", "TenMatHang", hoaDon.MaMatHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", hoaDon.MaNhanVien);
            return View(hoaDon);
        }

        // POST: HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaKhachHang,MaNhanVien,SoLuong,DonGia,MaMatHang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "HoVaTen", hoaDon.MaKhachHang);
            ViewBag.MaMatHang = new SelectList(db.MatHangs, "MaMatHang", "TenMatHang", hoaDon.MaMatHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", hoaDon.MaNhanVien);
            return View(hoaDon);
        }

        // GET: HoaDon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
