using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.business
{
    public class businessKhachHang
    {
        public DataClasses1DataContext db = new DataClasses1DataContext();
        public IList<KhachHang> Index()
        {
            IList<KhachHang> khachHangs = new List<KhachHang>();
            var query = from qrs in db.KHACHHANGs select qrs;
            var listdata = query.ToList();
            foreach (var data in listdata)
            {
                khachHangs.Add(new KhachHang()
                {
                    makh = data.MaKH,
                    hotenkh = data.HoTenKH,
                    diachi = data.DiaChi,
                    dienthoai = data.DienThoai

                });
            }
            return khachHangs;
        }
        public KHACHHANG getKH(string id)
        {
            KHACHHANG kHACHHANG = db.KHACHHANGs.Where(n => n.MaKH == id).FirstOrDefault();
            return kHACHHANG;
        }
        public List<KHACHHANG> getAllKH()
        {
            List<KHACHHANG> kHACHHANG = db.KHACHHANGs.ToList();
            return kHACHHANG;
        }
    }
}