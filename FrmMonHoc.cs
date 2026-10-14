
using System;
using System.Linq;
using System.Windows.Forms;
using QLSV.Data;
using QLSV.Models;

namespace QLSV
{
    public partial class FrmMonHoc : Form
    {
        private bool dangSua = false;
        private bool dangNapDuLieu = false;

        private string mssvCu = "";
        private string maMonHocCu = "";

        public FrmMonHoc()
        {
            InitializeComponent();
        }

        // Constructor dùng khi sửa lượt đăng ký
        public FrmMonHoc(string mssv, string maMonHoc)
        {
            InitializeComponent();

            dangSua = true;
            mssvCu = mssv;
            maMonHocCu = maMonHoc;
        }

        // =========================
        // 1. KHỞI TẠO FORM
        // =========================
        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            dangNapDuLieu = true;

            try
            {
                lstSinhVien.DisplayMember = "HienThi";
                lstSinhVien.ValueMember = "MSSV";

                lstMonHoc.DisplayMember = "HienThi";
                lstMonHoc.ValueMember = "MaMonHoc";

                cboHocKy.DropDownStyle =
                    ComboBoxStyle.DropDownList;

                LoadSinhVien();
                LoadHocKy();

                if (dangSua)
                {
                    using (var db = new AppDbContext())
                    {
                        var maHocKy = db.MonHocs
                            .Where(mh => mh.MaMonHoc == maMonHocCu)
                            .Select(mh => mh.MaHocKy)
                            .FirstOrDefault();

                        if (!string.IsNullOrEmpty(maHocKy))
                        {
                            cboHocKy.SelectedValue = maHocKy;
                        }
                    }
                }
                else
                {
                    cboHocKy.SelectedIndex = -1;
                }

                LoadMonHoc();

                if (dangSua)
                {
                    ChonSinhVienCu();
                    ChonMonHocCu();

                    txtTimSinhVien.Enabled = false;
                    lstSinhVien.Enabled = false;

                    this.Text = "Sửa đăng ký môn học";
                }
            }
            finally
            {
                dangNapDuLieu = false;
            }
        }

        // =========================
        // 2. NẠP SINH VIÊN
        // =========================
        private void LoadSinhVien()
        {
            string tuKhoa = txtTimSinhVien.Text.Trim();

            using (var db = new AppDbContext())
            {
                var danhSach = db.SinhViens
                    .Where(sv =>
                        sv.MSSV.Contains(tuKhoa) ||
                        sv.HoTen.Contains(tuKhoa))
                    .OrderBy(sv => sv.MSSV)
                    .Select(sv => new
                    {
                        sv.MSSV,
                        HienThi = sv.MSSV + " - " + sv.HoTen
                    })
                    .ToList();

                lstSinhVien.DataSource = null;
                lstSinhVien.DataSource = danhSach;
                lstSinhVien.DisplayMember = "HienThi";
                lstSinhVien.ValueMember = "MSSV";
                lstSinhVien.ClearSelected();
            }
        }

        // =========================
        // 3. NẠP HỌC KỲ
        // =========================
        private void LoadHocKy()
        {
            using (var db = new AppDbContext())
            {
                var danhSach = db.HocKys
                    .OrderBy(hk => hk.NamHoc)
                    .ThenBy(hk => hk.MaHocKy)
                    .Select(hk => new
                    {
                        hk.MaHocKy,
                        HienThi = hk.TenHocKy + " - " + hk.NamHoc
                    })
                    .ToList();

                cboHocKy.DataSource = danhSach;
                cboHocKy.DisplayMember = "HienThi";
                cboHocKy.ValueMember = "MaHocKy";
                cboHocKy.SelectedIndex = -1;
            }
        }

        // =========================
        // 4. NẠP MÔN THEO HỌC KỲ
        // =========================
        private void LoadMonHoc()
        {
            string maHocKy = null;
            string tuKhoa = txtTimMonHoc.Text.Trim();

            if (cboHocKy.SelectedValue != null &&
                cboHocKy.SelectedValue is string)
            {
                maHocKy = cboHocKy.SelectedValue.ToString();
            }

            using (var db = new AppDbContext())
            {
                var query = db.MonHocs.AsQueryable();

                // Chưa chọn học kỳ thì không hiển thị môn
                if (string.IsNullOrEmpty(maHocKy))
                {
                    query = query.Where(mh =>
                        mh.MaHocKy == "__KHONG_CO_HOC_KY__");
                }
                else
                {
                    query = query.Where(mh =>
                        mh.MaHocKy == maHocKy);
                }

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(mh =>
                        mh.MaMonHoc.Contains(tuKhoa) ||
                        mh.TenMonHoc.Contains(tuKhoa));
                }

                var danhSach = query
                    .OrderBy(mh => mh.MaMonHoc)
                    .Select(mh => new
                    {
                        mh.MaMonHoc,
                        HienThi = mh.MaMonHoc + " - " +
                                  mh.TenMonHoc + " (" +
                                  mh.SoTinChi + " tín chỉ)"
                    })
                    .ToList();

                lstMonHoc.DataSource = null;
                lstMonHoc.DataSource = danhSach;
                lstMonHoc.DisplayMember = "HienThi";
                lstMonHoc.ValueMember = "MaMonHoc";
                lstMonHoc.ClearSelected();
            }
        }

        // =========================
        // 5. TÌM SINH VIÊN
        // =========================
        private void txtTimSinhVien_TextChanged(
            object sender, EventArgs e)
        {
            if (dangNapDuLieu)
                return;

            LoadSinhVien();
        }

        // =========================
        // 6. TÌM MÔN HỌC
        // =========================
        private void txtTimMonHoc_TextChanged(
            object sender, EventArgs e)
        {
            if (dangNapDuLieu)
                return;

            LoadMonHoc();
        }

        // =========================
        // 7. ĐỔI HỌC KỲ
        // =========================
        private void cboHocKy_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (dangNapDuLieu)
                return;

            LoadMonHoc();
        }

        // =========================
        // 8. CHỌN DỮ LIỆU CŨ KHI SỬA
        // =========================
        private void ChonSinhVienCu()
        {
            for (int i = 0; i < lstSinhVien.Items.Count; i++)
            {
                dynamic item = lstSinhVien.Items[i];

                if (item.MSSV.ToString() == mssvCu)
                {
                    lstSinhVien.SelectedIndex = i;
                    break;
                }
            }
        }

        private void ChonMonHocCu()
        {
            for (int i = 0; i < lstMonHoc.Items.Count; i++)
            {
                dynamic item = lstMonHoc.Items[i];

                if (item.MaMonHoc.ToString() == maMonHocCu)
                {
                    lstMonHoc.SelectedIndex = i;
                    break;
                }
            }
        }

        // =========================
        // 9. LƯU / CẬP NHẬT
        // =========================

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (lstSinhVien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!");
                return;
            }

            if (cboHocKy.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn học kỳ!");
                return;
            }

            if (lstMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!");
                return;
            }

            string mssv = lstSinhVien.SelectedValue.ToString();
            string maMonHoc = lstMonHoc.SelectedValue.ToString();

            try
            {
                using (var db = new AppDbContext())
                {
                    if (dangSua)
                    {
                        var dangKy = db.DangKyMonHocs.FirstOrDefault(dk =>
                            dk.MSSV == mssvCu &&
                            dk.MaMonHoc == maMonHocCu);

                        if (dangKy == null)
                        {
                            MessageBox.Show("Lượt đăng ký không còn tồn tại!");
                            return;
                        }

                        if (maMonHoc == maMonHocCu)
                        {
                            MessageBox.Show("Em chưa thay đổi môn học.");
                            return;
                        }

                        bool biTrung = db.DangKyMonHocs.Any(dk =>
                            dk.MSSV == mssvCu &&
                            dk.MaMonHoc == maMonHoc);

                        if (biTrung)
                        {
                            MessageBox.Show(
                                "Sinh viên đã đăng ký môn học này!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        using (var transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                db.DangKyMonHocs.Remove(dangKy);
                                db.SaveChanges();

                                db.DangKyMonHocs.Add(new DangKyMonHoc
                                {
                                    MSSV = mssvCu,
                                    MaMonHoc = maMonHoc,
                                    NgayDangKy = DateTime.Now
                                });

                                db.SaveChanges();
                                transaction.Commit();
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    else
                    {
                        bool daDangKy = db.DangKyMonHocs.Any(dk =>
                            dk.MSSV == mssv &&
                            dk.MaMonHoc == maMonHoc);

                        if (daDangKy)
                        {
                            MessageBox.Show(
                                "Sinh viên đã đăng ký môn học này!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        db.DangKyMonHocs.Add(new DangKyMonHoc
                        {
                            MSSV = mssv,
                            MaMonHoc = maMonHoc,
                            NgayDangKy = DateTime.Now
                        });

                        db.SaveChanges();
                    }
                }

                MessageBox.Show(
                    dangSua
                        ? "Cập nhật đăng ký thành công!"
                        : "Đăng ký môn học thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lưu dữ liệu!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        // =========================
        // 10. HỦY
        // =========================
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
