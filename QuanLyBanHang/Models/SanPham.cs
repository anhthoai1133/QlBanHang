using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class SanPham
    {
        public string masp { get; set; }
        public string tensp { get; set; }
        public string donvitinh { get; set; }
        public double dongia { get; set; }

        public SanPham()
        {
            masp = "";
            tensp = "";
            donvitinh = "";
            dongia = 0;
        }
    }
}