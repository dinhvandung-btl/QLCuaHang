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
    public class NhapKho_CTController : Controller
    {
        private QuanLyEF db = new QuanLyEF();

        // GET: Admin/NhapKho_CT
        public ActionResult Index()
        {
            var nhapKho_CTs = db.NhapKho_CTs.Include(n => n.HangHoa).Include(n => n.NhapKho);
            return View(nhapKho_CTs.ToList());
        }

        // GET: Admin/NhapKho_CT/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho_CT nhapKho_CT = db.NhapKho_CTs.Find(id);
            if (nhapKho_CT == null)
            {
                return HttpNotFound();
            }
            return View(nhapKho_CT);
        }

        // GET: Admin/NhapKho_CT/Create
        public ActionResult Create()
        {
            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang");
            ViewBag.SoPhieuN = new SelectList(db.NhapKhos, "SoPhieuN", "NguoiNhap");
            return View();
        }

        // POST: Admin/NhapKho_CT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuN,STT,MaHang,SLNhap,DGNhap")] NhapKho_CT nhapKho_CT)
        {
            if (ModelState.IsValid)
            {
                db.NhapKho_CTs.Add(nhapKho_CT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang", nhapKho_CT.MaHang);
            ViewBag.SoPhieuN = new SelectList(db.NhapKhos, "SoPhieuN", "NguoiNhap", nhapKho_CT.SoPhieuN);
            return View(nhapKho_CT);
        }

        // GET: Admin/NhapKho_CT/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho_CT nhapKho_CT = db.NhapKho_CTs.Find(id);
            if (nhapKho_CT == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang", nhapKho_CT.MaHang);
            ViewBag.SoPhieuN = new SelectList(db.NhapKhos, "SoPhieuN", "NguoiNhap", nhapKho_CT.SoPhieuN);
            return View(nhapKho_CT);
        }

        // POST: Admin/NhapKho_CT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuN,STT,MaHang,SLNhap,DGNhap")] NhapKho_CT nhapKho_CT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhapKho_CT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang", nhapKho_CT.MaHang);
            ViewBag.SoPhieuN = new SelectList(db.NhapKhos, "SoPhieuN", "NguoiNhap", nhapKho_CT.SoPhieuN);
            return View(nhapKho_CT);
        }

        // GET: Admin/NhapKho_CT/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho_CT nhapKho_CT = db.NhapKho_CTs.Find(id);
            if (nhapKho_CT == null)
            {
                return HttpNotFound();
            }
            return View(nhapKho_CT);
        }

        // POST: Admin/NhapKho_CT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhapKho_CT nhapKho_CT = db.NhapKho_CTs.Find(id);
            db.NhapKho_CTs.Remove(nhapKho_CT);
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
