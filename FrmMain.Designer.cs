namespace QLSV
{
    partial class FrmMain
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
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            trangChủToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            sinhViênToolStripMenuItem = new ToolStripMenuItem();
            mnuDangKyMonHoc = new ToolStripMenuItem();
            mnuDanhSachDangKy = new ToolStripMenuItem();
            mônĐãĐăngKýToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, quảnLýToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { trangChủToolStripMenuItem, thoátToolStripMenuItem });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(88, 24);
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // trangChủToolStripMenuItem
            // 
            trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            trangChủToolStripMenuItem.Size = new Size(158, 26);
            trangChủToolStripMenuItem.Text = "Trang Chủ";
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(158, 26);
            thoátToolStripMenuItem.Text = "Thoát";
            thoátToolStripMenuItem.Click += mnuThoat_Click;
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sinhViênToolStripMenuItem, mnuDangKyMonHoc, mnuDanhSachDangKy, mônĐãĐăngKýToolStripMenuItem });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(75, 24);
            quảnLýToolStripMenuItem.Text = "Quản Lý";
            // 
            // sinhViênToolStripMenuItem
            // 
            sinhViênToolStripMenuItem.Name = "sinhViênToolStripMenuItem";
            sinhViênToolStripMenuItem.Size = new Size(224, 26);
            sinhViênToolStripMenuItem.Text = "Sinh Viên";
            sinhViênToolStripMenuItem.Click += mnuSinhVien_Click;
            // 
            // mnuDangKyMonHoc
            // 
            mnuDangKyMonHoc.Name = "mnuDangKyMonHoc";
            mnuDangKyMonHoc.Size = new Size(224, 26);
            mnuDangKyMonHoc.Text = "Đăng Ký Môn Học";
            mnuDangKyMonHoc.Click += mnuDangKyMonHoc_Click;
            // 
            // mnuDanhSachDangKy
            // 
            mnuDanhSachDangKy.Name = "mnuDanhSachDangKy";
            mnuDanhSachDangKy.Size = new Size(224, 26);
            mnuDanhSachDangKy.Text = "DSDK";
            mnuDanhSachDangKy.Click += mnuDanhSachDangKy_Click;
            // 
            // mônĐãĐăngKýToolStripMenuItem
            // 
            mônĐãĐăngKýToolStripMenuItem.Name = "mônĐãĐăngKýToolStripMenuItem";
            mônĐãĐăngKýToolStripMenuItem.Size = new Size(224, 26);
            mônĐãĐăngKýToolStripMenuItem.Text = "Môn Đã Đăng Ký";
            mônĐãĐăngKýToolStripMenuItem.Click += mônĐãĐăngKýToolStripMenuItem_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Text = "HỆ THỐNG QUẢN LÝ SINH VIÊN";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem trangChủToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem sinhViênToolStripMenuItem;
        private ToolStripMenuItem mnuDangKyMonHoc;
        private ToolStripMenuItem mnuDanhSachDangKy;
        private ToolStripMenuItem mônĐãĐăngKýToolStripMenuItem;
    }
}