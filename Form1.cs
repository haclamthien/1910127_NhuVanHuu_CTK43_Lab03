using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab03.Models;

namespace Lab03
{
    public partial class FrormMain : Form
    {
        QuanLySinhVien qlsv;
        public FrormMain()
        {
            InitializeComponent();
        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = mktxt_Id.Text.Substring(3).Trim();
            sv.HoTen = txt_Name.Text;
            sv.NgaySinh = dtp_BirthDay.Value;
            sv.DiaChi = txt_Address.Text;
            sv.Lop = cbb_Class.Text;
            sv.Hinh = txt_Path.Text;
            sv.GioiTinh = (rd_Male.Checked == true ? true : false);
            for(int i =0; i<cklb_ChuyenNganh.Items.Count; i++)
            {
                if (cklb_ChuyenNganh.GetItemChecked(i))
                    sv.ChuyenNganh.Add(cklb_ChuyenNganh.Items[i].ToString());
            }
            return sv;
        }
        private SinhVien GetSinhVienFromLvItem(ListViewItem lvItem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvItem.SubItems[0].Text;
            sv.HoTen = lvItem.SubItems[1].Text;
            sv.NgaySinh = DateTime.Parse(lvItem.SubItems[2].Text);
            sv.DiaChi = lvItem.SubItems[3].Text;
            sv.Lop = lvItem.SubItems[4].Text;
            sv.GioiTinh = lvItem.SubItems[5].Text.CompareTo("Nam") == 0 ? true : false;
            String[] cns = lvItem.SubItems[6].Text.Split(',');
            foreach(var cn in cns)
            {
                sv.ChuyenNganh.Add(cn);
            }
            sv.Hinh = lvItem.SubItems[7].Text;
            
            return sv;
        }
        private void resetCkblChuyenNganh()
        {
            for(int i = 0; i<cklb_ChuyenNganh.Items.Count; i++)
            {
                cklb_ChuyenNganh.SetItemChecked(i, false);
            }
        }
        private void LoadSVToControlls(SinhVien sv)
        {
            resetCkblChuyenNganh();
            this.mktxt_Id.Text = sv.MaSo;
            this.txt_Name.Text = sv.HoTen;
            this.dtp_BirthDay.Value = sv.NgaySinh;
            this.txt_Address.Text = sv.DiaChi;
            this.cbb_Class.Text = sv.Lop;
            this.txt_Path.Text = sv.Hinh;
            if (sv.GioiTinh == true)
                this.rd_Male.Checked = true;
            else this.rd_FeMale.Checked = true;
            foreach(var cn in sv.ChuyenNganh)
            {
                for(int i =0; i<cklb_ChuyenNganh.Items.Count; i++)
                {
                    if(cn == cklb_ChuyenNganh.Items[i].ToString())
                    {
                        cklb_ChuyenNganh.SetItemChecked(i, true);
                    }
                }
            }
            if (sv.Hinh != null)
            {
                this.pb_Avatar.ImageLocation = sv.Hinh;
            }
        }
        private void ThemSVToLV(SinhVien sv)
        {
            ListViewItem lvItem = new ListViewItem(sv.MaSo);
            lvItem.SubItems.Add(sv.HoTen);
            lvItem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvItem.SubItems.Add(sv.DiaChi);
            lvItem.SubItems.Add(sv.Lop);
            lvItem.SubItems.Add(sv.GioiTinh==true?"Nam":"Nữ");
            if (sv.ChuyenNganh.Count > 0)
            {
                string cns = "";
                foreach (var cn in sv.ChuyenNganh)
                {
                    cns += cn + ',';
                }
                cns = cns.Substring(0, cns.Length - 1);
                lvItem.SubItems.Add(cns);
            }
            else
                lvItem.SubItems.Add("");


            lvItem.SubItems.Add(sv.Hinh);
            lv_Students.Items.Add(lvItem);

        }
        private void SetStatuStrip()
        {
            int sum = qlsv.DanhSachSV.Count;
            toolStripStatusLabel1.Text = "Tổng số sinh viên: " + sum;
        }
        private void LoadDsSVToLv()
        {
            this.lv_Students.Items.Clear();
            foreach(var sv in qlsv.DanhSachSV)
            {
                ThemSVToLV(sv);
            }
            SetStatuStrip();
        }

        private void FrormMain_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            LoadDsSVToLv();
        }

        private void lv_Students_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lv_Students.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvItem = this.lv_Students.SelectedItems[0];
                SinhVien sv = GetSinhVienFromLvItem(lvItem);
                LoadSVToControlls(sv);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
           // sv.MaSo = sv.MaSo.Substring(3);
            SinhVien kq = qlsv.Tim(sv.MaSo, SoSanhTheoMa);
            if (kq != null)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                qlsv.ThemSV(sv);
               qlsv.SaveChange();
                LoadDsSVToLv();
            }
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MaSo.CompareTo(obj1);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ListViewItem lvitem;
            for(int i = lv_Students.Items.Count - 1; i>=0; i--)
            {
                lvitem = this.lv_Students.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            
            this.LoadDsSVToLv();
            btn_Default.PerformClick();
        }

        private void btn_Default_Click(object sender, EventArgs e)
        {
            resetCkblChuyenNganh();
            this.mktxt_Id.Text = "";
            this.txt_Name.Text = "";
            this.dtp_BirthDay.Value = DateTime.Now;
            this.txt_Address.Text = "";
            this.cbb_Class.Text = "";
            this.txt_Path.Text = "";
            this.rd_Male.Checked = true;
            this.pb_Avatar.ImageLocation = "";
        }

        private void btn_Fix_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kq;
            kq = qlsv.Sua(sv, sv.MaSo, SoSanhTheoMa);
            if (kq == true) this.LoadDsSVToLv();
        }

        private void btn_AddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Picture";
            dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
                        + "*.jpg;*.jpeg;*.gif;*.bmp;"
                        + "*.tif;*.tiff;*.png|"
                        + "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
                        + "GIF files (*.gif)|*.gif|"
                        + "BMP files (*.bmp)|*.bmp|"
                        + "TIFF files (*.tif;*.tiff)|*.tif;*.tiff|"
                        + "PNG files (*.png)|*.png|"
                        + "All files (*.*)|*.*";
            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filename = dlg.FileName;
                txt_Path.Text = filename;
                pb_Avatar.Load(filename);
            }
        }

        private void tsmi_file_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contextMenu_Sort_Click(object sender, EventArgs e)
        {
            FormTuyChon frm = new FormTuyChon(1);
            frm.ShowDialog();
            if (frm.result == "Mã Số")
            {
                qlsv.DanhSachSV.Sort((x, y) => x.MaSo.CompareTo(y.MaSo));
                LoadTTSVToLV(qlsv.DanhSachSV);
                qlsv.SaveChange();
            }
            else if(frm.result == "Họ Tên")
            {
                
                qlsv.DanhSachSV.Sort((x, y) => x.HoTen.Trim().CompareTo(y.HoTen.Trim()));
                qlsv.SaveChange();
                LoadTTSVToLV(qlsv.DanhSachSV);
            }
            else
            {
                qlsv.DanhSachSV.Sort((x, y) => x.NgaySinh.CompareTo(y.NgaySinh));
                LoadTTSVToLV(qlsv.DanhSachSV);
                qlsv.SaveChange();
            }
        }
        private void LoadTTSVToLV(List<SinhVien> dsSv)
        {
            this.lv_Students.Items.Clear();
            foreach (var sv in dsSv)
            {
                ThemSVToLV(sv);
            }
            SetStatuStrip();
        }
        private void contextMenu_Search_Click(object sender, EventArgs e)
        {
            FormTuyChon frm = new FormTuyChon(0);
            frm.ShowDialog();
            if (frm.result != null)
            {
                String[] result = frm.result.Split(';');

                if (result[0] == "Mã Số")
                {
                    SinhVien sv = new SinhVien();
                    sv = qlsv.Tim(result[1], SoSanhTheoMa);
                    if (sv != null)
                    {
                        lv_Students.Items.Clear();
                        ThemSVToLV(sv);
                        DialogResult dr = MessageBox.Show("Có 1 sinh viên có mã: " + result[1] + " trong danh sách", "Thông báo");
                        if (dr == DialogResult.OK)
                            LoadDsSVToLv();
                    }
                    else
                    {
                        MessageBox.Show("Không có sinh viên có mã: " + result[1] + " trong danh sách", "Thông báo");
                    }
                }
                else if (result[0] == "Họ Tên")
                {
                    List<SinhVien> dssv = new List<SinhVien>();
                    dssv = qlsv.DanhSachSV.FindAll(p => p.HoTen == result[1]);
                    
                    if (dssv.Count > 0)
                    {
                        LoadTTSVToLV(dssv);
                        DialogResult dr = MessageBox.Show("Có " + dssv.Count + " sinh viên có họ tên: " + result[1] + " trong danh sách", "Thông báo");
                        if (dr == DialogResult.OK)
                            LoadDsSVToLv();
                    }
                    else
                    {
                        MessageBox.Show("Không có sinh viên có họ tên: " + result[1] + " trong danh sách", "Thông báo"); ;
                    }
                }
                else
                {
                    List<SinhVien> dssv = new List<SinhVien>();
                    dssv = qlsv.DanhSachSV.FindAll(p => p.NgaySinh.Day == (DateTime.Parse(result[1].ToString())).Day && 
                    p.NgaySinh.Month == (DateTime.Parse(result[1].ToString())).Month && p.NgaySinh.Year == (DateTime.Parse(result[1].ToString())).Year);
                    if (dssv.Count >=0)
                    {
                        LoadTTSVToLV(dssv);
                        DialogResult dr = MessageBox.Show("Có " + dssv.Count + " sinh viên có ngày sinh: " + result[1] + " trong danh sách", "Thông báo");
                        if (dr == DialogResult.OK)
                            LoadDsSVToLv();
                    }
                    else
                    {
                        MessageBox.Show("Không có sinh viên có ngày sinh: " + result[1] + " trong danh sách", "Thông báo");
                    }
                }
            }
        }

        private void tsmi_edit_add_Click(object sender, EventArgs e)
        {
            btn_Add.PerformClick();
        }

        private void tsmi_edit_remove_Click(object sender, EventArgs e)
        {
            btn_Delete.PerformClick();
        }

        private void tsmi_edit_fix_Click(object sender, EventArgs e)
        {
            btn_Fix.PerformClick();
        }

        private void tsmi_edit_sort_Click(object sender, EventArgs e)
        {
            contextMenu_Sort_Click(sender, e);
        }

        private void tsmi_edit_search_Click(object sender, EventArgs e)
        {
            contextMenu_Search_Click(sender, e);
        }
    }
}
