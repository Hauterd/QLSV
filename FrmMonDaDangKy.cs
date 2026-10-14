
using System;
using System.Linq;
using System.Windows.Forms;
using QLSV.Data;

namespace QLSV
{
    public partial class FrmMonDaDangKy : Form
    {
        public FrmMonDaDangKy()
        {
            InitializeComponent();
        }

        // Nạp danh sách sinh viên khi mở Form
        private void FrmMonDaDangKy_Load(object sender, EventArgs e)
        {
            LoadSinhVien();
        }

        private void LoadSinhVien()
        {
            using (var db = new AppDbContext())
            {
                var danhSach = db.SinhViens
                    .OrderBy(sv => sv.MSSV)
                    .Select(sv => new
                    {
                        sv.MSSV,
                        HienThi = sv.MSSV + " - " + sv.HoTen
                    })
                    .ToList();

                cboSinhVien.DataSource = danhSach;
                cboSinhVien.DisplayMember = "HienThi";
                cboSinhVien.ValueMember = "MSSV";
                cboSinhVien.SelectedIndex = -1;
            }

            dgvMonDaDangKy.DataSource = null;
            dgvMonDaDangKy.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonDaDangKy.ReadOnly = true;
            dgvMonDaDangKy.AllowUserToAddRows = false;
            dgvMonDaDangKy.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        // Khi chọn sinh viên, hiển thị các môn đã đăng ký
        private void cboSinhVien_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedValue == null ||
                cboSinhVien.SelectedValue is not string)
            {
                return;
            }

            string mssv = cboSinhVien.SelectedValue.ToString();

            using (var db = new AppDbContext())
            {
                var danhSach = (
                    from dk in db.DangKyMonHocs
                    join mh in db.MonHocs
                        on dk.MaMonHoc equals mh.MaMonHoc
                    where dk.MSSV == mssv
                    orderby dk.NgayDangKy descending
                    select new
                    {
                        dk.MSSV,
                        mh.MaMonHoc,
                        mh.TenMonHoc,
                        mh.SoTinChi,
                        dk.NgayDangKy
                    }
                ).ToList();

                dgvMonDaDangKy.DataSource = danhSach;

                if (dgvMonDaDangKy.Columns["MSSV"] != null)
                    dgvMonDaDangKy.Columns["MSSV"]
                        .HeaderText = "Mã sinh viên";

                if (dgvMonDaDangKy.Columns["MaMonHoc"] != null)
                    dgvMonDaDangKy.Columns["MaMonHoc"]
                        .HeaderText = "Mã môn học";

                if (dgvMonDaDangKy.Columns["TenMonHoc"] != null)
                    dgvMonDaDangKy.Columns["TenMonHoc"]
                        .HeaderText = "Tên môn học";

                if (dgvMonDaDangKy.Columns["SoTinChi"] != null)
                    dgvMonDaDangKy.Columns["SoTinChi"]
                        .HeaderText = "Số tín chỉ";

                if (dgvMonDaDangKy.Columns["NgayDangKy"] != null)
                {
                    dgvMonDaDangKy.Columns["NgayDangKy"]
                        .HeaderText = "Ngày đăng ký";

                    dgvMonDaDangKy.Columns["NgayDangKy"]
                        .DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
        }

        // Đóng Form
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
