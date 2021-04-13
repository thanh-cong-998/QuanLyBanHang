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
    public class PhieuDonHangController : Controller
    {
        private QuanLyBanHangdbContext db = new QuanLyBanHangdbContext();

        // GET: PhieuDonHang
        public ActionResult Index()
        {
            var phieuDonHangs = db.PhieuDonHangs.Include(p => p.ThanhTien);
            return View(phieuDonHangs.ToList());
        }

        // GET: PhieuDonHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDonHang phieuDonHang = db.PhieuDonHangs.Find(id);
            if (phieuDonHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuDonHang);
        }

        // GET: PhieuDonHang/Create
        public ActionResult Create()
        {
            ViewBag.ThanhTienID = new SelectList(db.ThanhTiens, "ThanhTienID", "MaHoaDon");
            return View();
        }

        // POST: PhieuDonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_PDH,ThanhTienID,NgayDatHang,SĐT,DiaChi")] PhieuDonHang phieuDonHang)
        {
            if (ModelState.IsValid)
            {
                db.PhieuDonHangs.Add(phieuDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ThanhTienID = new SelectList(db.ThanhTiens, "ThanhTienID", "MaHoaDon", phieuDonHang.ThanhTienID);
            return View(phieuDonHang);
        }

        // GET: PhieuDonHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDonHang phieuDonHang = db.PhieuDonHangs.Find(id);
            if (phieuDonHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThanhTienID = new SelectList(db.ThanhTiens, "ThanhTienID", "MaHoaDon", phieuDonHang.ThanhTienID);
            return View(phieuDonHang);
        }

        // POST: PhieuDonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_PDH,ThanhTienID,NgayDatHang,SĐT,DiaChi")] PhieuDonHang phieuDonHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThanhTienID = new SelectList(db.ThanhTiens, "ThanhTienID", "MaHoaDon", phieuDonHang.ThanhTienID);
            return View(phieuDonHang);
        }

        // GET: PhieuDonHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDonHang phieuDonHang = db.PhieuDonHangs.Find(id);
            if (phieuDonHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuDonHang);
        }

        // POST: PhieuDonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuDonHang phieuDonHang = db.PhieuDonHangs.Find(id);
            db.PhieuDonHangs.Remove(phieuDonHang);
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
