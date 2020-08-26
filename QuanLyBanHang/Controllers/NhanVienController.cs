using QuanLyBanHang.business;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        DataClasses1DataContext db = new DataClasses1DataContext();
        businessNhanVien nvbusiness = new businessNhanVien();
        public ActionResult Index()
        {
            return View(nvbusiness.Index());
        }
        public JsonResult getAllNV()
        {
            return Json(nvbusiness.getAllNV(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveNV(NhanVien nv)
        {
            NHANVIEN nhanvien = new NHANVIEN();
            bool status;
            try
            {
                nhanvien.MaNV = nv.manv;
                nhanvien.HoNV = nv.tennv;
                nhanvien.TenNV = nv.tennv;
                nhanvien.NgaySinh = DateTime.Parse(nv.ngaysinh.ToString());
                nhanvien.Gioitinh = nv.gioitinh;
                nhanvien.DiaChi = nv.diachi;
                nhanvien.DienThoai = nv.dienthoai;
                db.NHANVIENs.InsertOnSubmit(nhanvien);
                db.SubmitChanges();
                status = true;
            }
            catch(Exception)
            {
                status = false;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            bool status;
            try
            {
                NHANVIEN nv = nvbusiness.getNV(id);
                db.NHANVIENs.DeleteAllOnSubmit(db.NHANVIENs.Where(n => n.MaNV == id));
                db.SubmitChanges();
                status = true;
            }
            catch(Exception)
            {
                status = false;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}