using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class FormTuyChon : Form
    {
        public string result { get; private set; }
        private int check;
        public FormTuyChon(int check =0)
        {
            this.check = check;
            InitializeComponent();
        }

        private void rd_Id_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Id.Checked == true) lbl_hint.Text = "Mã Số";
        }

        private void rd_Name_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Name.Checked == true) lbl_hint.Text = "Họ Tên";
        }

        private void rd_BirthDay_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_BirthDay.Checked == true) lbl_hint.Text = "Ngày Sinh";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_input.Text == "") MessageBox.Show("Bạn phải nhập thông tin tìm kiếm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (rd_Id.Checked == true)
                {
                    result = "Mã Số;" + txt_input.Text;
                }
                if (rd_BirthDay.Checked == true)
                {
                    result = "Ngày Sinh;" + txt_input.Text;
                }
                if (rd_Name.Checked == true)
                {
                    result = "Họ Tên;" + txt_input.Text;
                }
                this.Close();
            }
           
        }

        private void FormTuyChon_Load(object sender, EventArgs e)
        {
            if (check == 0)
            {
                groupBox2.Enabled = true;
                btn_sort.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = false;
                btn_sort.Enabled = true;
            }

            
        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            if (rd_Id.Checked == true) result = "Mã Số";
            else if (rd_Name.Checked == true) result = "Họ Tên";
            else result = "Ngày Sinh";
            this.Close();
        }
    }
}
