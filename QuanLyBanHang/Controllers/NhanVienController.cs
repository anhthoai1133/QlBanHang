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
            nhanvien = db.NHANVIENs.FirstOrDefault(n => n.MaNV == nv.manv);
            if(nhanvien!= null)
            {
                nhanvien.HoNV = nv.honv;
                nhanvien.TenNV = nv.tennv;
                nhanvien.NgaySinh =DateTime.Parse(nv.ngaysinh.ToString());
                nhanvien.Gioitinh = nv.gioitinh;
                nhanvien.DiaChi = nv.diachi;
                nhanvien.DienThoai = nv.dienthoai;
                db.SubmitChanges();
            }
            else
            {
                NHANVIEN nhanVien = new NHANVIEN();
                nhanVien.MaNV = nv.manv;
                nhanVien.HoNV = nv.honv;
                nhanVien.TenNV = nv.tennv;
                nhanVien.NgaySinh = DateTime.Parse(nv.ngaysinh.ToString());
                nhanVien.Gioitinh = nv.gioitinh;
                nhanVien.DiaChi = nv.diachi;
                nhanVien.DienThoai = nv.dienthoai;
                db.NHANVIENs.InsertOnSubmit(nhanVien);
                db.SubmitChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
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