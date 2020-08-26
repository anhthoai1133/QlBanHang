using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class KhachHang
    {
        public string makh { get; set; }
        public string hotenkh { get; set; }
        public string diachi { get; set; }
        public Nullable<int> dienthoai { get; set; }

        public KhachHang()
        {
            makh = "";
            hotenkh = "";
            diachi = "";
            dienthoai = 0;
        }
    }
}