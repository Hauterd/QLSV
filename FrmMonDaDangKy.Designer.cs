namespace QLSV
{
    partial class FrmMonDaDangKy
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
            cboSinhVien = new ComboBox();
            lblSinhVien = new Label();
            dgvMonDaDangKy = new DataGridView();
            btnDong = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMonDaDangKy).BeginInit();
            SuspendLayout();
            // 
            // cboSinhVien
            // 
            cboSinhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSinhVien.FormattingEnabled = true;
            cboSinhVien.Location = new Point(23, 89);
            cboSinhVien.Name = "cboSinhVien";
            cboSinhVien.Size = new Size(260, 28);
            cboSinhVien.TabIndex = 9;
            cboSinhVien.SelectedIndexChanged += cboSinhVien_SelectedIndexChanged;
            // 
            // lblSinhVien
            // 
            lblSinhVien.AutoSize = true;
            lblSinhVien.Location = new Point(24, 47);
            lblSinhVien.Name = "lblSinhVien";
            lblSinhVien.Size = new Size(104, 20);
            lblSinhVien.TabIndex = 8;
            lblSinhVien.Text = "Chọn sinh viên";
            // 
            // dgvMonDaDangKy
            // 
            dgvMonDaDangKy.AllowUserToAddRows = false;
            dgvMonDaDangKy.AllowUserToDeleteRows = false;
            dgvMonDaDangKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonDaDangKy.Location = new Point(1, 143);
            dgvMonDaDangKy.Name = "dgvMonDaDangKy";
            dgvMonDaDangKy.ReadOnly = true;
            dgvMonDaDangKy.RowHeadersWidth = 51;
            dgvMonDaDangKy.Size = new Size(798, 188);
            dgvMonDaDangKy.TabIndex = 10;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(656, 397);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(94, 29);
            btnDong.TabIndex = 11;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // FrmMonDaDangKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDong);
            Controls.Add(dgvMonDaDangKy);
            Controls.Add(cboSinhVien);
            Controls.Add(lblSinhVien);
            Name = "FrmMonDaDangKy";
            Text = "FrmMonDaDangKy";
            Load += FrmMonDaDangKy_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMonDaDangKy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboSinhVien;
        private Label lblSinhVien;
        private DataGridView dgvMonDaDangKy;
        private Button btnDong;
    }
}