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
    public class ThanhTienController : Controller
    {
        private QuanLyBanHangdbContext db = new QuanLyBanHangdbContext();

        // GET: ThanhTien
        public ActionResult Index()
        {
            var thanhTiens = db.ThanhTiens.Include(t => t.PhieuDonHang);
            return View(thanhTiens.ToList());
        }

        // GET: ThanhTien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhTien thanhTien = db.ThanhTiens.Find(id);
            if (thanhTien == null)
            {
                return HttpNotFound();
            }
            return View(thanhTien);
        }

        // GET: ThanhTien/Create
        public ActionResult Create()
        {
            ViewBag.Ma_PDH = new SelectList(db.PhieuDonHangs, "Ma_PDH", "DiaChi");
            return View();
        }

        // POST: ThanhTien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThanhTienID,Ma_PDH,NgayBan,SoLuong,DonGia,TongTien")] ThanhTien thanhTien)
        {
            if (ModelState.IsValid)
            {
                db.ThanhTiens.Add(thanhTien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_PDH = new SelectList(db.PhieuDonHangs, "Ma_PDH", "DiaChi", thanhTien.Ma_PDH);
            return View(thanhTien);
        }

        // GET: ThanhTien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhTien thanhTien = db.ThanhTiens.Find(id);
            if (thanhTien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_PDH = new SelectList(db.PhieuDonHangs, "Ma_PDH", "DiaChi", thanhTien.Ma_PDH);
            return View(thanhTien);
        }

        // POST: ThanhTien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThanhTienID,Ma_PDH,NgayBan,SoLuong,DonGia,TongTien")] ThanhTien thanhTien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhTien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_PDH = new SelectList(db.PhieuDonHangs, "Ma_PDH", "DiaChi", thanhTien.Ma_PDH);
            return View(thanhTien);
        }

        // GET: ThanhTien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhTien thanhTien = db.ThanhTiens.Find(id);
            if (thanhTien == null)
            {
                return HttpNotFound();
            }
            return View(thanhTien);
        }

        // POST: ThanhTien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThanhTien thanhTien = db.ThanhTiens.Find(id);
            db.ThanhTiens.Remove(thanhTien);
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
