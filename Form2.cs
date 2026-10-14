
using System;
using System.Linq;
using System.Windows.Forms;
using QLSV.Data;
using QLSV.Models;
namespace QLSV
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadSinhVien();
        }

        // Hiển thị danh sách sinh viên và tên khoa


        private void LoadSinhVien()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    // Kiểm tra số lượng dữ liệu
                    int soSinhVien = db.SinhViens.Count();
                    int soKhoa = db.Khoas.Count();

                    MessageBox.Show(
                        $"Số sinh viên: {soSinhVien}\nSố khoa: {soKhoa}");

                    var danhSach =
                        (from sv in db.SinhViens
                         join k in db.Khoas
                             on sv.MaKhoa equals k.MaKhoa
                         select new
                         {
                             sv.MSSV,
                             sv.HoTen,
                             k.TenKhoa,
                             sv.MaKhoa
                         }).ToList();

                    dgvSV.DataSource = null;
                    dgvSV.AutoGenerateColumns = true;
                    dgvSV.DataSource = danhSach;

                    if (dgvSV.Columns.Contains("MSSV"))
                        dgvSV.Columns["MSSV"].HeaderText = "Mã sinh viên";

                    if (dgvSV.Columns.Contains("HoTen"))
                        dgvSV.Columns["HoTen"].HeaderText = "Họ tên";

                    if (dgvSV.Columns.Contains("TenKhoa"))
                        dgvSV.Columns["TenKhoa"].HeaderText = "Khoa";

                    if (dgvSV.Columns.Contains("MaKhoa"))
                        dgvSV.Columns["MaKhoa"].Visible = false;

                    dgvSV.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;

                    dgvSV.ReadOnly = true;
                    dgvSV.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;
                    dgvSV.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi tải sinh viên");
            }
        }



        // Lấy MSSV từ dòng đang chọn
        private string LayMSSVDangChon()
        {
            if (dgvSV.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên!");
                return null;
            }

            return dgvSV.CurrentRow.Cells["MSSV"]
                .Value?.ToString();
        }

        // Nút Thêm: mở Form1 ở chế độ thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (Form1 frm = new Form1())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadSinhVien();
                }
            }
        }

        // Nút Sửa: mở Form1 và nạp thông tin đã chọn
        private void btnSua_Click(object sender, EventArgs e)
        {
            string mssv = LayMSSVDangChon();

            if (string.IsNullOrEmpty(mssv))
                return;

            using (Form1 frm = new Form1(mssv))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadSinhVien();
                }
            }
        }

        // Nút Xóa: xóa trực tiếp trong Form2
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mssv = LayMSSVDangChon();

            if (string.IsNullOrEmpty(mssv))
                return;

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên " + mssv + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                using (var db = new AppDbContext())
                {
                    var sv = db.SinhViens
                        .FirstOrDefault(x => x.MSSV == mssv);

                    if (sv == null)
                    {
                        MessageBox.Show("Sinh viên không tồn tại!");
                        LoadSinhVien();
                        return;
                    }

                    db.SinhViens.Remove(sv);
                    db.SaveChanges();
                }

                MessageBox.Show("Xóa thành công!");
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu:\n" + ex.Message);
            }
        }

        private void dgvSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            dgvSV.ClearSelection();
            dgvSV.Rows[e.RowIndex].Selected = true;
            dgvSV.CurrentCell = dgvSV.Rows[e.RowIndex].Cells["MSSV"];
        }
    }
}
