using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.business
{
    public class businessNhanVien
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public IList<NhanVien> Index()
        {
            IList<NhanVien> nhanViens = new List<NhanVien>();
            var query = from qrs in db.NHANVIENs select qrs;
            var listdata = query.ToList();
            foreach(var data in listdata)
            {
                nhanViens.Add(new NhanVien()
                {
                    manv = data.MaNV,
                    honv = data.HoNV,
                    tennv = data.TenNV,
                    ngaysinh = data.NgaySinh,
                    gioitinh = data.Gioitinh,
                    diachi = data.DiaChi,
                    dienthoai = data.DienThoai
                });
            }
            return nhanViens;
        }
        public NHANVIEN getNV(string id)
        {
            NHANVIEN nhanvien = db.NHANVIENs.Where(n => n.MaNV == id).FirstOrDefault();
            return nhanvien;
        }
        public List<NHANVIEN> getAllNV()
        {
            List<NHANVIEN> nhanvien = db.NHANVIENs.ToList();
            return nhanvien;
        }
    }
}