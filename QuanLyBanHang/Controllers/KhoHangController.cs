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
    public class KhoHangController : Controller
    {
        private QuanLyBanHangdbContext db = new QuanLyBanHangdbContext();

        // GET: KhoHang
        public ActionResult Index()
        {
            var khoHangs = db.KhoHangs.Include(k => k.MatHangs);
            return View(khoHangs.ToList());
        }

        // GET: KhoHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoHang khoHang = db.KhoHangs.Find(id);
            if (khoHang == null)
            {
                return HttpNotFound();
            }
            return View(khoHang);
        }

        // GET: KhoHang/Create
        public ActionResult Create()
        {
            ViewBag.MaMatHang = new SelectList(db.MatHangs, "MaMatHang", "TenMatHang");
            return View();
        }

        // POST: KhoHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoHang,NgayNhapKho,MaMatHang,SoLuongTonKho,NhaCC")] KhoHang khoHang)
        {
            if (ModelState.IsValid)
            {
                db.KhoHangs.Add(khoHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMatHang = new SelectList(db.MatHangs, "MaMatHang", "TenMatHang", khoHang.MaMatHang);
            return View(khoHang);
        }

        // GET: KhoHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoHang khoHang = db.KhoHangs.Find(id);
            if (khoHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMatHang = new SelectList(db.MatHangs, "MaMatHang", "TenMatHang", khoHang.MaMatHang);
            return View(khoHang);
        }

        // POST: KhoHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoHang,NgayNhapKho,MaMatHang,SoLuongTonKho,NhaCC")] KhoHang khoHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMatHang = new SelectList(db.MatHangs, "MaMatHang", "TenMatHang", khoHang.MaMatHang);
            return View(khoHang);
        }

        // GET: KhoHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoHang khoHang = db.KhoHangs.Find(id);
            if (khoHang == null)
            {
                return HttpNotFound();
            }
            return View(khoHang);
        }

        // POST: KhoHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhoHang khoHang = db.KhoHangs.Find(id);
            db.KhoHangs.Remove(khoHang);
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
