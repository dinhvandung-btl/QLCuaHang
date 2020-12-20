using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLCuaHang.Models;

namespace QLCuaHang.Areas.Admin.Controllers
{
    public class XuatKho_CTController : Controller
    {
        private QuanLyEF db = new QuanLyEF();

        // GET: Admin/XuatKho_CT
        public ActionResult Index()
        {
            var xuatKho_CTs = db.XuatKho_CTs.Include(x => x.HangHoa).Include(x => x.XuatKHo);
            return View(xuatKho_CTs.ToList());
        }

        // GET: Admin/XuatKho_CT/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XuatKho_CT xuatKho_CT = db.XuatKho_CTs.Find(id);
            if (xuatKho_CT == null)
            {
                return HttpNotFound();
            }
            return View(xuatKho_CT);
        }

        // GET: Admin/XuatKho_CT/Create
        public ActionResult Create()
        {
            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang");
            ViewBag.SoPhieuX = new SelectList(db.XuatKhos, "SoPhieuX", "MaKH");
            return View();
        }

        // POST: Admin/XuatKho_CT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuX,STT,MaHang,SLXuat,DGXuat")] XuatKho_CT xuatKho_CT)
        {
            if (ModelState.IsValid)
            {
                db.XuatKho_CTs.Add(xuatKho_CT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang", xuatKho_CT.MaHang);
            ViewBag.SoPhieuX = new SelectList(db.XuatKhos, "SoPhieuX", "MaKH", xuatKho_CT.SoPhieuX);
            return View(xuatKho_CT);
        }

        // GET: Admin/XuatKho_CT/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XuatKho_CT xuatKho_CT = db.XuatKho_CTs.Find(id);
            if (xuatKho_CT == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang", xuatKho_CT.MaHang);
            ViewBag.SoPhieuX = new SelectList(db.XuatKhos, "SoPhieuX", "MaKH", xuatKho_CT.SoPhieuX);
            return View(xuatKho_CT);
        }

        // POST: Admin/XuatKho_CT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuX,STT,MaHang,SLXuat,DGXuat")] XuatKho_CT xuatKho_CT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xuatKho_CT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang", xuatKho_CT.MaHang);
            ViewBag.SoPhieuX = new SelectList(db.XuatKhos, "SoPhieuX", "MaKH", xuatKho_CT.SoPhieuX);
            return View(xuatKho_CT);
        }

        // GET: Admin/XuatKho_CT/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XuatKho_CT xuatKho_CT = db.XuatKho_CTs.Find(id);
            if (xuatKho_CT == null)
            {
                return HttpNotFound();
            }
            return View(xuatKho_CT);
        }

        // POST: Admin/XuatKho_CT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            XuatKho_CT xuatKho_CT = db.XuatKho_CTs.Find(id);
            db.XuatKho_CTs.Remove(xuatKho_CT);
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
