using QuanLyBanHang.business;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        DataClasses1DataContext db = new DataClasses1DataContext();
        businessKhachHang khachhangbusiness = new businessKhachHang();
        public ActionResult Index()
        {
            return View(khachhangbusiness.Index());
        }
        public JsonResult getAllKH()
        {
            return Json(khachhangbusiness.getAllKH(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddKH(FormCollection formCollection, KHACHHANG kh)
        {
            var makh = formCollection["MaKH"];
            var hotenkh = formCollection["HoTenKH"];
            var diachi = formCollection["DiaChi"];
            var dienthoai = formCollection["DienThoai"];
            if (string.IsNullOrEmpty(makh))
            {
                ViewData["Loi1"] = "Mã Khách hàng không được để trống";
            }
            if (string.IsNullOrEmpty(hotenkh))
            {
                ViewData["Loi2"] = "Họ tên khách hàng không được để trống";
            }
            if (string.IsNullOrEmpty(diachi))
            {
                ViewData["Loi3"] = "Địa chỉ khách hàng không được để trống";
            }
            if (string.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi4"] = "Điện thoại khách hàng không được để trống";
            }
            else
            {
                KHACHHANG kHACHHANG = new KHACHHANG();
                kHACHHANG = db.KHACHHANGs.FirstOrDefault(n => n.MaKH == makh);
                if (kHACHHANG != null)
                {
                    kHACHHANG.HoTenKH = hotenkh;
                    kHACHHANG.DiaChi = diachi;
                    kHACHHANG.DienThoai = Int32.Parse(dienthoai);
                    db.SubmitChanges();
                }
                else
                {
                    kh.MaKH = makh;
                    kh.HoTenKH = hotenkh;
                    kh.DiaChi = diachi;
                    kh.DienThoai = Int32.Parse(dienthoai);
                    db.KHACHHANGs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    return View("Index", khachhangbusiness.Index());
                }
            }
            return View("Index", khachhangbusiness.Index());
        }
        public JsonResult Delete(string id)
        {
            KHACHHANG khachhang = khachhangbusiness.getKH(id);
            db.KHACHHANGs.DeleteAllOnSubmit(db.KHACHHANGs.Where(n => n.MaKH == id));
            db.SubmitChanges();
            return Json(khachhangbusiness.getAllKH(),JsonRequestBehavior.AllowGet);
        }
    }
}