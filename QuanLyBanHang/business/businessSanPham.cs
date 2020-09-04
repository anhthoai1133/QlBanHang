using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.business
{
    public class businessSanPham
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public IList<SanPham> Index()
        {
            IList<SanPham> sanPhams = new List<SanPham>();
            var query = from qrs in db.SANPHAMs select qrs;
            var listData = query.ToList();
            foreach(var data in listData)
            {
                sanPhams.Add(new SanPham()
                {
                    masp = data.MaSP,
                    tensp = data.TenSP,
                    donvitinh = data.DonViTinh,
                    dongia = double.Parse(data.DonGia.ToString()),
                });
            }
            return sanPhams;
        }
        public SANPHAM getSP(string id)
        {
            SANPHAM sanpham = db.SANPHAMs.Where(n => n.MaSP == id).FirstOrDefault();
            return sanpham;
        }
        public List<SANPHAM> getAllSP()
        {
            List<SANPHAM> sanpham = db.SANPHAMs.ToList();
            return sanpham;
        }
    }
}