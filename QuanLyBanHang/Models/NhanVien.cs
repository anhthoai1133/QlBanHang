using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class NhanVien
    {
        public string manv { get; set; }
        public string honv { get; set; }
        public string tennv { get; set; }
        public Nullable<DateTime> ngaysinh { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        public string diachi { get; set; }
        public Nullable<int> dienthoai { get; set; }

        public NhanVien()
        {
            manv = "";
            honv = "";
            tennv = "";
            ngaysinh = null;
            gioitinh = false;
            diachi = "";
            dienthoai = 0;
        }
    }
}