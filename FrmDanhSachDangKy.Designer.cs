namespace QLSV
{
    partial class FrmDanhSachDangKy
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
            pnlTimKiem = new Panel();
            btnTaiLai = new Button();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            dgvDanhSachDangKy = new DataGridView();
            btnDong = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnDangKy = new Button();
            pnlTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachDangKy).BeginInit();
            SuspendLayout();
            // 
            // pnlTimKiem
            // 
            pnlTimKiem.Controls.Add(btnTaiLai);
            pnlTimKiem.Controls.Add(btnTimKiem);
            pnlTimKiem.Controls.Add(txtTimKiem);
            pnlTimKiem.Controls.Add(lblTimKiem);
            pnlTimKiem.Dock = DockStyle.Top;
            pnlTimKiem.Location = new Point(0, 0);
            pnlTimKiem.Name = "pnlTimKiem";
            pnlTimKiem.Size = new Size(804, 85);
            pnlTimKiem.TabIndex = 9;
            // 
            // btnTaiLai
            // 
            btnTaiLai.BackColor = Color.Transparent;
            btnTaiLai.Location = new Point(628, 42);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(142, 29);
            btnTaiLai.TabIndex = 16;
            btnTaiLai.Text = "Tải lại danh sách";
            btnTaiLai.UseVisualStyleBackColor = false;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(521, 42);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(101, 29);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(12, 43);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập MSSV hoặc họ tên...";
            txtTimKiem.Size = new Size(503, 27);
            txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(12, 20);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(131, 20);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm sinh viên";
            // 
            // dgvDanhSachDangKy
            // 
            dgvDanhSachDangKy.AllowUserToAddRows = false;
            dgvDanhSachDangKy.AllowUserToDeleteRows = false;
            dgvDanhSachDangKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachDangKy.Dock = DockStyle.Top;
            dgvDanhSachDangKy.Location = new Point(0, 85);
            dgvDanhSachDangKy.Name = "dgvDanhSachDangKy";
            dgvDanhSachDangKy.ReadOnly = true;
            dgvDanhSachDangKy.RowHeadersWidth = 51;
            dgvDanhSachDangKy.Size = new Size(804, 188);
            dgvDanhSachDangKy.TabIndex = 10;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(710, 342);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(94, 29);
            btnDong.TabIndex = 11;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(610, 342);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(510, 342);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(410, 342);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(94, 29);
            btnDangKy.TabIndex = 15;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // FrmDanhSachDangKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 450);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnDangKy);
            Controls.Add(btnDong);
            Controls.Add(dgvDanhSachDangKy);
            Controls.Add(pnlTimKiem);
            Name = "FrmDanhSachDangKy";
            Text = "FrmDanhSachDangKy";
            Load += FrmDanhSachDangKy_Load;
            pnlTimKiem.ResumeLayout(false);
            pnlTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachDangKy).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTimKiem;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
        private Button btnTaiLai;
        private DataGridView dgvDanhSachDangKy;
        private Button btnDong;
        private Button btnXoa;
        private Button btnSua;
        private Button btnDangKy;
    }
}