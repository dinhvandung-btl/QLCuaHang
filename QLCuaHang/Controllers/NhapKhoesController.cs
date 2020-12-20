using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLCuaHang.Models;

namespace QLCuaHang.Controllers
{
    public class NhapKhoesController : Controller
    {
        private QuanLyEF db = new QuanLyEF();

        // GET: NhapKhoes
        public ActionResult Index()
        {
            return View(db.NhapKhos.ToList());
        }

        // GET: NhapKhoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho nhapKho = db.NhapKhos.Find(id);
            if (nhapKho == null)
            {
                return HttpNotFound();
            }
            return View(nhapKho);
        }

        // GET: NhapKhoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhapKhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuN,NgayNhap,NguoiNhap,LyDoNhap")] NhapKho nhapKho)
        {
            if (ModelState.IsValid)
            {
                db.NhapKhos.Add(nhapKho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhapKho);
        }

        // GET: NhapKhoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho nhapKho = db.NhapKhos.Find(id);
            if (nhapKho == null)
            {
                return HttpNotFound();
            }
            return View(nhapKho);
        }

        // POST: NhapKhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuN,NgayNhap,NguoiNhap,LyDoNhap")] NhapKho nhapKho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhapKho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhapKho);
        }

        // GET: NhapKhoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho nhapKho = db.NhapKhos.Find(id);
            if (nhapKho == null)
            {
                return HttpNotFound();
            }
            return View(nhapKho);
        }

        // POST: NhapKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhapKho nhapKho = db.NhapKhos.Find(id);
            db.NhapKhos.Remove(nhapKho);
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
