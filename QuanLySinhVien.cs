using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab03.Models;

namespace Lab03
{
    public delegate int SoSanh(object obj1, object obj2);
    public class QuanLySinhVien
    {
        public List<SinhVien> DanhSachSV;

        public QuanLySinhVien()
        {
            DanhSachSV = new List<SinhVien>();
        }
        public void ThemSV(SinhVien sv)
        {
            DanhSachSV.Add(sv);
        }
        public SinhVien this[int index]
        {
            get { return DanhSachSV[index]; }
            set { DanhSachSV[index] = value; }
        }
        public void Xoa(object obj1, SoSanh ss)
        {
            int i = DanhSachSV.Count - 1;
            for (; i >= 0; i--)
            {
                if (ss(obj1, this[i]) == 0)
                    this.DanhSachSV.RemoveAt(i);
            }
            SaveChange();
        }
        public void SapXep()
        {
            SinhVien temp = new SinhVien();
            for(int i=0; i<DanhSachSV.Count; i++)
            {
                for(int y = i+1; y<DanhSachSV.Count -1; y++)
                {
                    if(this[i].HoTen.Substring(this[i].HoTen.LastIndexOf(' ')).CompareTo(this[i].HoTen.Substring(this[y].HoTen.LastIndexOf(' '))) > 0)
                    {
                        temp = this[i];
                        this[i] = this[y];
                        this[y] = temp;
                    }
                }
            }
        }
        public SinhVien Tim(object obj1, SoSanh ss)
        {
            SinhVien sv = null;
            foreach(var s in DanhSachSV)
                if(ss(obj1, s) == 0)
                {
                    sv = s;
                    break;
                }
            return sv;
        }
        public bool Sua(SinhVien svsua, object obj1, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = DanhSachSV.Count - 1;
            for(i =0; i<=count; i++)
            {
                if(ss(obj1, this[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            }
            SaveChange();
            return kq;
        }
        public void DocTuFile()
        {
            String filename = "data\\data.txt", line;
            string[] strs;
            SinhVien sv;
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                            break;
                        strs = line.Split('*');
                        sv = new SinhVien();
                            sv.MaSo = strs[0].Trim();
                            sv.HoTen = strs[1].Trim();
                            sv.NgaySinh = DateTime.Parse(strs[2].Trim());
                            sv.DiaChi = strs[3].Trim();
                            sv.Lop = strs[4].Trim();
                            sv.Hinh = strs[5].Trim();
                            sv.GioiTinh = (strs[6].Trim().CompareTo("0") == 0 ? false : true);
                        String[] cns;
                        if (strs[7].Trim() != "")
                        {
                            cns = strs[7].Trim().Split(',');
                            foreach (var cn in cns)
                            {
                                sv.ChuyenNganh.Add(cn.Trim());
                            }
                        }
                        this.ThemSV(sv);
                    }
                }
            }
        }
        public void SaveChange()
        {
            int count = 0;
            String filename = "data\\data.txt", line;
            using (var stream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
            {
                using (var write = new StreamWriter(stream))
                {
                    foreach (var sv in DanhSachSV)
                    {
                        string gt = "0";
                        if (sv.GioiTinh == true) gt = "1";
                        write.Write(sv.MaSo + "*" + sv.HoTen + "*" + sv.NgaySinh + "*" + sv.DiaChi + "*" + sv.Lop + "*" + sv.Hinh + "*" + gt + "*");
                        for(int i =0; i<sv.ChuyenNganh.Count; i++)
                        {
                            if (i == sv.ChuyenNganh.Count - 1)
                                write.Write(sv.ChuyenNganh[i]);
                            else
                                write.Write(sv.ChuyenNganh[i] + ",");
                        }
                        count++;
                        if (count < DanhSachSV.Count) write.Write("\n");
                    }
                }
            }
        }
    }
}
