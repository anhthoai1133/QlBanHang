using QuanLyBanHang.business;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        DataClasses1DataContext db = new DataClasses1DataContext();
        businessSanPham sanphambusiness = new businessSanPham();
        public ActionResult Index()
        {
            return View(sanphambusiness.Index());
        }
        public JsonResult getAllSP()
        {
            return Json(sanphambusiness.getAllSP(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveSP(SanPham sp)
        {
            SANPHAM sanpham = new SANPHAM();
            sanpham = db.SANPHAMs.FirstOrDefault(n => n.MaSP == sp.masp);
            if(sanpham!= null)
            {
                sanpham.TenSP = sp.tensp;
                sanpham.DonViTinh = sp.donvitinh;
                sanpham.DonGia = sp.dongia;
                db.SubmitChanges();
            }
            else
            {
                SANPHAM sanPham = new SANPHAM();
                sanPham.MaSP = sp.masp;
                sanPham.TenSP = sp.tensp;
                sanPham.DonViTinh = sp.donvitinh;
                sanPham.DonGia = sp.dongia;
                db.SANPHAMs.InsertOnSubmit(sanPham);
                db.SubmitChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}