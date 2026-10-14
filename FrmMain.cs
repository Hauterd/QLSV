using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLSV
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }



        private void mnuSinhVien_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is Form2)
                {
                    form.Activate();
                    return;
                }
            }

            Form2 frm = new Form2();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }


        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDangKyMonHoc_Click(object sender, EventArgs e)
        {

            using (var frm = new FrmMonHoc())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Đã lưu đăng ký thành công


                }
            }
        }

        private void mônĐãĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmMonDaDangKy();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDanhSachDangKy_Click(object sender, EventArgs e)
        {
            var frm = new FrmDanhSachDangKy();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}