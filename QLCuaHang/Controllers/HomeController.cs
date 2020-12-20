using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using QLCuaHang.Models;
using System.Security.Cryptography;
using System.Text;

namespace QLCuaHang.Controllers
{
    public class HomeController : Controller
    {
        QuanLyEF db = new QuanLyEF();
        public ActionResult Index()
        {
            var hangHoas = db.HangHoas.Include(S => S.LoaiHang);
            return View(hangHoas.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string password)
        {

            if (ModelState.IsValid)//kiểm tra người dùng nhập vào có hợp lệ hay không
            {
                var mat_khau_ma_hoa = GETMD5(password);
                var kiem_tra_tai_khoan = db.KhachHangs.Where(s => s.Email.Equals(Email) && s.password.Equals(mat_khau_ma_hoa)).ToList();
                if (kiem_tra_tai_khoan != null)//so sánh xem Email và password nhập vào có trong database hay không
                {
                    Session["MaKhachHang"] = kiem_tra_tai_khoan.FirstOrDefault().MaKH;
                    Session["TenKH"] = kiem_tra_tai_khoan.FirstOrDefault().TenKH;
                    var checkAdmin = kiem_tra_tai_khoan.FirstOrDefault().role;
                    if (checkAdmin == "admin")
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    ViewBag.LoginError = "Đăng nhập không thành công";
                    return RedirectToAction("Login");
                }
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");

        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.KhachHangs.FirstOrDefault(m => m.Email == kh.Email);//kiểm tra trong database đã có email chưa
                if (checkEmail == null)//nếu không lấy email ở trong database thì sẽ lấy dữ liệu người dùng nhập vào
                {
                    kh.password = GETMD5(kh.password);
                    db.Configuration.ValidateOnSaveEnabled = false;//check điều kiện
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("Login");//trả về trang Login
                }
                else
                {
                    ViewBag.EmailError = "Email đã tồn tại";
                    return RedirectToAction("Register");
                }
            }
            return View();
        }
        public static string GETMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(pass);
            byte[] targetData = md5.ComputeHash(fromData);
            string mat_khau_ma_hoa = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                mat_khau_ma_hoa += targetData[i].ToString("x2");

            }
            return mat_khau_ma_hoa;
        }

    }
}