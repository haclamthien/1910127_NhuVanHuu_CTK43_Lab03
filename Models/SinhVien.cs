using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03.Models
{
    public class SinhVien
    {
        public String MaSo { get; set; }
        public String HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public String DiaChi { get; set; }
        public String Lop { get; set; }
        public String Hinh { get; set; }
        public bool GioiTinh { get; set; }
        public List<String> ChuyenNganh { get; set; }

        public SinhVien()
        {
            this.ChuyenNganh = new List<string>();
        }

        public SinhVien(string maSo, string hoTen, DateTime ngaySinh, string diaChi, string lop, string hinh, bool gioiTinh, List<string> chuyenNganh)
        {
            MaSo = maSo;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            Lop = lop;
            Hinh = hinh;
            GioiTinh = gioiTinh;
            ChuyenNganh = chuyenNganh;
        }
    }
}
