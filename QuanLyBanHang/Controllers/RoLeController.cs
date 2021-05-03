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
    [Authorize(Roles = "NTC")]
    public class RoLeController : Controller
    {
        private QuanLyBanHangdbContext db = new QuanLyBanHangdbContext();

        // GET: RoLe
        public ActionResult Index()
        {
            return View(db.RoLes.ToList());
        }

        // GET: RoLe/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoLe roLe = db.RoLes.Find(id);
            if (roLe == null)
            {
                return HttpNotFound();
            }
            return View(roLe);
        }

        // GET: RoLe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoLe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleID,RoleName")] RoLe roLe)
        {
            if (ModelState.IsValid)
            {
                db.RoLes.Add(roLe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roLe);
        }

        // GET: RoLe/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoLe roLe = db.RoLes.Find(id);
            if (roLe == null)
            {
                return HttpNotFound();
            }
            return View(roLe);
        }

        // POST: RoLe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleID,RoleName")] RoLe roLe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roLe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roLe);
        }

        // GET: RoLe/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoLe roLe = db.RoLes.Find(id);
            if (roLe == null)
            {
                return HttpNotFound();
            }
            return View(roLe);
        }

        // POST: RoLe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RoLe roLe = db.RoLes.Find(id);
            db.RoLes.Remove(roLe);
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
