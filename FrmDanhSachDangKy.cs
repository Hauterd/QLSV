
using System;
using System.Linq;
using System.Windows.Forms;
using QLSV.Data;

namespace QLSV
{
    public partial class FrmDanhSachDangKy : Form
    {
        public FrmDanhSachDangKy()
        {
            InitializeComponent();
        }

        // =========================
        // 1. KHI MỞ FORM
        // =========================
        private void FrmDanhSachDangKy_Load(
            object sender, EventArgs e)
        {
            CauHinhDataGridView();
            LoadDanhSachDangKy();
        }

        // =========================
        // 2. CẤU HÌNH DATAGRIDVIEW
        // =========================
        private void CauHinhDataGridView()
        {
            dgvDanhSachDangKy.ReadOnly = true;
            dgvDanhSachDangKy.AllowUserToAddRows = false;
            dgvDanhSachDangKy.AllowUserToDeleteRows = false;
            dgvDanhSachDangKy.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachDangKy.MultiSelect = false;
            dgvDanhSachDangKy.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachDangKy.RowHeadersVisible = false;
        }

        // =========================
        // 3. TẢI TOÀN BỘ DANH SÁCH
        // =========================
        private void LoadDanhSachDangKy()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var danhSach = (
     from dk in db.DangKyMonHocs
     join sv in db.SinhViens
         on dk.MSSV equals sv.MSSV
     join mh in db.MonHocs
         on dk.MaMonHoc equals mh.MaMonHoc
     join hk in db.HocKys
         on mh.MaHocKy equals hk.MaHocKy into hocKyGroup
     from hk in hocKyGroup.DefaultIfEmpty()
     orderby dk.NgayDangKy descending
     select new
     {
         dk.MSSV,
         sv.HoTen,
         dk.MaMonHoc,
         mh.TenMonHoc,
         mh.SoTinChi,
         TenHocKy = hk == null
             ? "Chưa phân học kỳ"
             : hk.TenHocKy,
         NamHoc = hk == null ? "" : hk.NamHoc,
         dk.NgayDangKy
     }
 ).ToList();

                    dgvDanhSachDangKy.DataSource = danhSach;
                }

                DoiTieuDeCot();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách đăng ký!\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // 4. ĐỔI TÊN CỘT
        // =========================
        private void DoiTieuDeCot()
        {
            string[,] cot =
            {
                { "MSSV", "Mã sinh viên" },
                { "HoTen", "Họ tên" },
                { "MaMonHoc", "Mã môn học" },
                { "TenMonHoc", "Tên môn học" },
                { "SoTinChi", "Số tín chỉ" },
                { "NgayDangKy", "Ngày đăng ký" },
                { "TenHocKy", "Học kỳ" },
                { "NamHoc", "Năm học" },
            };

            for (int i = 0; i < cot.GetLength(0); i++)
            {
                if (dgvDanhSachDangKy.Columns[cot[i, 0]] != null)
                {
                    dgvDanhSachDangKy.Columns[cot[i, 0]]
                        .HeaderText = cot[i, 1];
                }
            }

            if (dgvDanhSachDangKy.Columns["NgayDangKy"] != null)
            {
                dgvDanhSachDangKy.Columns["NgayDangKy"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        // =========================
        // 5. TÌM KIẾM
        // =========================
        private void btnTimKiem_Click(
            object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            try
            {
                using (var db = new AppDbContext())
                {
                    var danhSach = (
                        from dk in db.DangKyMonHocs
                        join sv in db.SinhViens
                            on dk.MSSV equals sv.MSSV
                        join mh in db.MonHocs
                            on dk.MaMonHoc equals mh.MaMonHoc
                        select new
                        {
                            dk.MSSV,
                            sv.HoTen,
                            dk.MaMonHoc,
                            mh.TenMonHoc,
                            mh.SoTinChi,
                            dk.NgayDangKy
                        }
                    ).ToList();

                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        danhSach = danhSach
                            .Where(x =>
                                x.MSSV.IndexOf(
                                    tuKhoa,
                                    StringComparison.OrdinalIgnoreCase) >= 0
                                ||
                                x.HoTen.IndexOf(
                                    tuKhoa,
                                    StringComparison.OrdinalIgnoreCase) >= 0
                                ||
                                x.MaMonHoc.IndexOf(
                                    tuKhoa,
                                    StringComparison.OrdinalIgnoreCase) >= 0
                                ||
                                x.TenMonHoc.IndexOf(
                                    tuKhoa,
                                    StringComparison.OrdinalIgnoreCase) >= 0
                            )
                            .ToList();
                    }

                    dgvDanhSachDangKy.DataSource = danhSach;
                }

                DoiTieuDeCot();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Tìm kiếm thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // 6. ĐĂNG KÝ MÔN HỌC
        // =========================
        private void btnDangKy_Click(
            object sender, EventArgs e)
        {
            using (var frm = new FrmMonHoc())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachDangKy();
                }
            }
        }

        // =========================
        // 7. XÓA LƯỢT ĐĂNG KÝ
        // =========================
        private void btnXoa_Click(
            object sender, EventArgs e)
        {
            if (dgvDanhSachDangKy.CurrentRow == null ||
                dgvDanhSachDangKy.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Vui lòng chọn lượt đăng ký cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string mssv = Convert.ToString(
                dgvDanhSachDangKy.CurrentRow.Cells["MSSV"].Value);

            string maMonHoc = Convert.ToString(
                dgvDanhSachDangKy.CurrentRow.Cells["MaMonHoc"].Value);

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa lượt đăng ký này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                using (var db = new AppDbContext())
                {
                    var dangKy = db.DangKyMonHocs.FirstOrDefault(dk =>
                        dk.MSSV == mssv &&
                        dk.MaMonHoc == maMonHoc);

                    if (dangKy == null)
                    {
                        MessageBox.Show(
                            "Lượt đăng ký không còn tồn tại!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        LoadDanhSachDangKy();
                        return;
                    }

                    db.DangKyMonHocs.Remove(dangKy);
                    db.SaveChanges();
                }

                MessageBox.Show(
                    "Xóa lượt đăng ký thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadDanhSachDangKy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Xóa thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // 8. SỬA LƯỢT ĐĂNG KÝ
        // =========================
        private void btnSua_Click(
            object sender, EventArgs e)
        {
            if (dgvDanhSachDangKy.CurrentRow == null ||
          dgvDanhSachDangKy.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn lượt đăng ký cần sửa!");
                return;
            }

            string mssv = Convert.ToString(
                dgvDanhSachDangKy.CurrentRow.Cells["MSSV"].Value);

            string maMonHoc = Convert.ToString(
                dgvDanhSachDangKy.CurrentRow.Cells["MaMonHoc"].Value);

            using (var frm = new FrmMonHoc(mssv, maMonHoc))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachDangKy();
                }
            }
        }

        // =========================
        // 9. TẢI LẠI DANH SÁCH
        // =========================
        private void btnTaiLai_Click(
            object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDanhSachDangKy();
        }

        // =========================
        // 10. ĐÓNG FORM
        // =========================
        private void btnDong_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
