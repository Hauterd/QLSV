namespace QLSV
{
    partial class FrmMonHoc
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
            btnLuu = new Button();
            btnHuy = new Button();
            grbThongtin = new GroupBox();
            lstSinhVien = new ListBox();
            txtTimSinhVien = new TextBox();
            lblTimSV = new Label();
            lblTD = new Label();
            groupBox1 = new GroupBox();
            lblHK = new Label();
            cboHocKy = new ComboBox();
            lstMonHoc = new ListBox();
            txtTimMonHoc = new TextBox();
            label1 = new Label();
            grbThongtin.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(588, 562);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(688, 562);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 11;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // grbThongtin
            // 
            grbThongtin.Controls.Add(lstSinhVien);
            grbThongtin.Controls.Add(txtTimSinhVien);
            grbThongtin.Controls.Add(lblTimSV);
            grbThongtin.Location = new Point(12, 43);
            grbThongtin.Name = "grbThongtin";
            grbThongtin.Size = new Size(776, 220);
            grbThongtin.TabIndex = 12;
            grbThongtin.TabStop = false;
            grbThongtin.Text = "Thông tin cần đăng ký";
            // 
            // lstSinhVien
            // 
            lstSinhVien.FormattingEnabled = true;
            lstSinhVien.Items.AddRange(new object[] { "Danh sách sinh viên" });
            lstSinhVien.Location = new Point(6, 86);
            lstSinhVien.Name = "lstSinhVien";
            lstSinhVien.Size = new Size(764, 104);
            lstSinhVien.TabIndex = 12;
            lstSinhVien.Tag = "";
            // 
            // txtTimSinhVien
            // 
            txtTimSinhVien.Location = new Point(6, 47);
            txtTimSinhVien.Name = "txtTimSinhVien";
            txtTimSinhVien.Size = new Size(222, 27);
            txtTimSinhVien.TabIndex = 11;
            txtTimSinhVien.TextChanged += txtTimSinhVien_TextChanged;
            // 
            // lblTimSV
            // 
            lblTimSV.AutoSize = true;
            lblTimSV.Location = new Point(6, 23);
            lblTimSV.Name = "lblTimSV";
            lblTimSV.Size = new Size(131, 20);
            lblTimSV.TabIndex = 10;
            lblTimSV.Text = "Tìm kiếm sinh viên";
            // 
            // lblTD
            // 
            lblTD.AutoSize = true;
            lblTD.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTD.Location = new Point(12, 9);
            lblTD.Name = "lblTD";
            lblTD.Size = new Size(192, 31);
            lblTD.TabIndex = 13;
            lblTD.Text = "Đăng ký môn học";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblHK);
            groupBox1.Controls.Add(cboHocKy);
            groupBox1.Controls.Add(lstMonHoc);
            groupBox1.Controls.Add(txtTimMonHoc);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 282);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(782, 268);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Môn học";
            // 
            // lblHK
            // 
            lblHK.AutoSize = true;
            lblHK.Location = new Point(6, 23);
            lblHK.Name = "lblHK";
            lblHK.Size = new Size(93, 20);
            lblHK.TabIndex = 13;
            lblHK.Text = "Chọn Học Kỳ";
            // 
            // cboHocKy
            // 
            cboHocKy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHocKy.FormattingEnabled = true;
            cboHocKy.Location = new Point(6, 46);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(260, 28);
            cboHocKy.TabIndex = 14;
            cboHocKy.SelectedIndexChanged += cboHocKy_SelectedIndexChanged;
            // 
            // lstMonHoc
            // 
            lstMonHoc.FormattingEnabled = true;
            lstMonHoc.Items.AddRange(new object[] { "Danh sách môn học" });
            lstMonHoc.Location = new Point(6, 140);
            lstMonHoc.Name = "lstMonHoc";
            lstMonHoc.Size = new Size(770, 104);
            lstMonHoc.TabIndex = 12;
            lstMonHoc.Tag = "";
            // 
            // txtTimMonHoc
            // 
            txtTimMonHoc.Location = new Point(6, 101);
            txtTimMonHoc.Name = "txtTimMonHoc";
            txtTimMonHoc.Size = new Size(260, 27);
            txtTimMonHoc.TabIndex = 11;
            txtTimMonHoc.TextChanged += txtTimMonHoc_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 77);
            label1.Name = "label1";
            label1.Size = new Size(132, 20);
            label1.TabIndex = 10;
            label1.Text = "Tìm kiếm môn học";
            // 
            // FrmMonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 603);
            Controls.Add(groupBox1);
            Controls.Add(lblTD);
            Controls.Add(grbThongtin);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Name = "FrmMonHoc";
            Text = "Chọn SV và Môn học";
            Load += FrmMonHoc_Load;
            grbThongtin.ResumeLayout(false);
            grbThongtin.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLuu;
        private Button btnHuy;
        private GroupBox grbThongtin;
        private Label lblTD;
        private TextBox txtTimSinhVien;
        private Label lblTimSV;
        private ListBox lstSinhVien;
        private GroupBox groupBox1;
        private Label lblHK;
        private ComboBox cboHocKy;
        private ListBox lstMonHoc;
        private TextBox txtTimMonHoc;
        private Label label1;
    }
}