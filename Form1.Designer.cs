namespace QLSV
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHoTen = new Label();
            hblKhoa = new Label();
            lblMSSV = new Label();
            txtHoTen = new TextBox();
            txtMSSV = new TextBox();
            cboKhoa = new ComboBox();
            btnLuu = new Button();
            SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(129, 82);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 20);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên";
            // 
            // hblKhoa
            // 
            hblKhoa.AutoSize = true;
            hblKhoa.Location = new Point(129, 187);
            hblKhoa.Name = "hblKhoa";
            hblKhoa.Size = new Size(43, 20);
            hblKhoa.TabIndex = 1;
            hblKhoa.Text = "Khoa";
            // 
            // lblMSSV
            // 
            lblMSSV.AutoSize = true;
            lblMSSV.Location = new Point(129, 133);
            lblMSSV.Name = "lblMSSV";
            lblMSSV.Size = new Size(47, 20);
            lblMSSV.TabIndex = 2;
            lblMSSV.Text = "MSSV";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(198, 79);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(125, 27);
            txtHoTen.TabIndex = 3;
            // 
            // txtMSSV
            // 
            txtMSSV.Location = new Point(198, 130);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(125, 27);
            txtMSSV.TabIndex = 4;
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(198, 179);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(151, 28);
            cboKhoa.TabIndex = 5;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(318, 267);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(97, 42);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLuu);
            Controls.Add(cboKhoa);
            Controls.Add(txtMSSV);
            Controls.Add(txtHoTen);
            Controls.Add(lblMSSV);
            Controls.Add(hblKhoa);
            Controls.Add(lblHoTen);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHoTen;
        private Label hblKhoa;
        private Label lblMSSV;
        private TextBox txtHoTen;
        private TextBox txtMSSV;
        private ComboBox cboKhoa;
        private Button btnLuu;
    }
}
