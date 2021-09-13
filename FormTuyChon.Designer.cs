
namespace Lab03
{
    partial class FormTuyChon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_BirthDay = new System.Windows.Forms.RadioButton();
            this.rd_Name = new System.Windows.Forms.RadioButton();
            this.rd_Id = new System.Windows.Forms.RadioButton();
            this.lbl_hint = new System.Windows.Forms.Label();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_sort = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_BirthDay);
            this.groupBox1.Controls.Add(this.rd_Name);
            this.groupBox1.Controls.Add(this.rd_Id);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn Theo";
            // 
            // rd_BirthDay
            // 
            this.rd_BirthDay.AutoSize = true;
            this.rd_BirthDay.Location = new System.Drawing.Point(203, 22);
            this.rd_BirthDay.Name = "rd_BirthDay";
            this.rd_BirthDay.Size = new System.Drawing.Size(94, 21);
            this.rd_BirthDay.TabIndex = 0;
            this.rd_BirthDay.Text = "Ngày Sinh";
            this.rd_BirthDay.UseVisualStyleBackColor = true;
            this.rd_BirthDay.CheckedChanged += new System.EventHandler(this.rd_BirthDay_CheckedChanged);
            // 
            // rd_Name
            // 
            this.rd_Name.AutoSize = true;
            this.rd_Name.Location = new System.Drawing.Point(104, 22);
            this.rd_Name.Name = "rd_Name";
            this.rd_Name.Size = new System.Drawing.Size(76, 21);
            this.rd_Name.TabIndex = 0;
            this.rd_Name.Text = "Họ Tên";
            this.rd_Name.UseVisualStyleBackColor = true;
            this.rd_Name.CheckedChanged += new System.EventHandler(this.rd_Name_CheckedChanged);
            // 
            // rd_Id
            // 
            this.rd_Id.AutoSize = true;
            this.rd_Id.Checked = true;
            this.rd_Id.Location = new System.Drawing.Point(7, 22);
            this.rd_Id.Name = "rd_Id";
            this.rd_Id.Size = new System.Drawing.Size(69, 21);
            this.rd_Id.TabIndex = 0;
            this.rd_Id.TabStop = true;
            this.rd_Id.Text = "Mã Số";
            this.rd_Id.UseVisualStyleBackColor = true;
            this.rd_Id.CheckedChanged += new System.EventHandler(this.rd_Id_CheckedChanged);
            // 
            // lbl_hint
            // 
            this.lbl_hint.AutoSize = true;
            this.lbl_hint.Location = new System.Drawing.Point(15, 33);
            this.lbl_hint.Name = "lbl_hint";
            this.lbl_hint.Size = new System.Drawing.Size(48, 17);
            this.lbl_hint.TabIndex = 1;
            this.lbl_hint.Text = "Mã Số";
            // 
            // txt_input
            // 
            this.txt_input.Location = new System.Drawing.Point(105, 30);
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(192, 22);
            this.txt_input.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_search);
            this.groupBox2.Controls.Add(this.lbl_hint);
            this.groupBox2.Controls.Add(this.txt_input);
            this.groupBox2.Location = new System.Drawing.Point(12, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 67);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm";
            // 
            // btn_search
            // 
            this.btn_search.Image = global::Lab03.Properties.Resources.icons8_search_20;
            this.btn_search.Location = new System.Drawing.Point(303, 26);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(35, 30);
            this.btn_search.TabIndex = 3;
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_sort
            // 
            this.btn_sort.Location = new System.Drawing.Point(12, 152);
            this.btn_sort.Name = "btn_sort";
            this.btn_sort.Size = new System.Drawing.Size(75, 25);
            this.btn_sort.TabIndex = 4;
            this.btn_sort.Text = "Sắp xếp";
            this.btn_sort.UseVisualStyleBackColor = true;
            this.btn_sort.Click += new System.EventHandler(this.btn_sort_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(275, 151);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 25);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // FormTuyChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 194);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_sort);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTuyChon";
            this.Text = "Tùy Chọn";
            this.Load += new System.EventHandler(this.FormTuyChon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_BirthDay;
        private System.Windows.Forms.RadioButton rd_Name;
        private System.Windows.Forms.RadioButton rd_Id;
        private System.Windows.Forms.Label lbl_hint;
        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_sort;
        private System.Windows.Forms.Button btn_exit;
    }
}