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
    public class XuatKhoesController : Controller
    {
        private QuanLyEF db = new QuanLyEF();

        // GET: XuatKhoes
        public ActionResult Index()
        {
            var xuatKhos = db.XuatKhos.Include(x => x.KhachHang);
            return View(xuatKhos.ToList());
        }

        // GET: XuatKhoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XuatKho xuatKho = db.XuatKhos.Find(id);
            if (xuatKho == null)
            {
                return HttpNotFound();
            }
            return View(xuatKho);
        }

        // GET: XuatKhoes/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            return View();
        }

        // POST: XuatKhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuX,NgayXuat,MaKH,LyDoXuat")] XuatKho xuatKho)
        {
            if (ModelState.IsValid)
            {
                db.XuatKhos.Add(xuatKho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", xuatKho.MaKH);
            return View(xuatKho);
        }

        // GET: XuatKhoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XuatKho xuatKho = db.XuatKhos.Find(id);
            if (xuatKho == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", xuatKho.MaKH);
            return View(xuatKho);
        }

        // POST: XuatKhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuX,NgayXuat,MaKH,LyDoXuat")] XuatKho xuatKho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xuatKho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", xuatKho.MaKH);
            return View(xuatKho);
        }

        // GET: XuatKhoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XuatKho xuatKho = db.XuatKhos.Find(id);
            if (xuatKho == null)
            {
                return HttpNotFound();
            }
            return View(xuatKho);
        }

        // POST: XuatKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            XuatKho xuatKho = db.XuatKhos.Find(id);
            db.XuatKhos.Remove(xuatKho);
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
