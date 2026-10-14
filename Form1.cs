
using System;
using System.Linq;
using System.Windows.Forms;
using QLSV.Data;
using QLSV.Models;

namespace QLSV
{
    public partial class Form1 : Form
    {
        private readonly string _mssvSua;
        private readonly bool _laSua;

        // Mở Form1 để thêm sinh viên
        public Form1()
        {
            InitializeComponent();
            _laSua = false;
        }

        // Mở Form1 để sửa sinh viên
        public Form1(string mssv) : this()
        {
            _mssvSua = mssv;
            _laSua = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadKhoa();

            if (_laSua)
            {
                LoadThongTinSinhVien();
                txtMSSV.ReadOnly = true;
                Text = "Sửa thông tin sinh viên";
            }
            else
            {
                Text = "Thêm sinh viên";
            }
        }


        private void LoadKhoa()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var danhSachKhoa = db.Khoas
                        .OrderBy(k => k.TenKhoa)
                        .ToList();

                    if (danhSachKhoa.Count == 0)
                    {
                        MessageBox.Show("Bảng Khoa chưa có dữ liệu!");
                        cboKhoa.DataSource = null;
                        return;
                    }

                    cboKhoa.DataSource = null;
                    cboKhoa.DisplayMember = "TenKhoa";
                    cboKhoa.ValueMember = "MaKhoa";
                    cboKhoa.DataSource = danhSachKhoa;
                    cboKhoa.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Lỗi tải danh sách khoa");
            }
        }


        private void LoadThongTinSinhVien()
        {
            using (var db = new AppDbContext())
            {
                var sv = db.SinhViens
                    .FirstOrDefault(x => x.MSSV == _mssvSua);

                if (sv == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên!");
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtMSSV.Text = sv.MSSV;
                txtHoTen.Text = sv.HoTen;
                cboKhoa.SelectedValue = sv.MaKhoa;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mssv = txtMSSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrWhiteSpace(mssv) ||
                string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập MSSV và họ tên!");
                return;
            }

            if (cboKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khoa!");
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    SinhVien sv;

                    if (_laSua)
                    {
                        sv = db.SinhViens
                            .FirstOrDefault(x => x.MSSV == _mssvSua);

                        if (sv == null)
                        {
                            MessageBox.Show("Sinh viên không tồn tại!");
                            return;
                        }
                    }
                    else
                    {
                        bool daTonTai = db.SinhViens
                            .Any(x => x.MSSV == mssv);

                        if (daTonTai)
                        {
                            MessageBox.Show("MSSV đã tồn tại!");
                            return;
                        }

                        sv = new SinhVien();
                        sv.MSSV = mssv;
                        db.SinhViens.Add(sv);
                    }

                    sv.HoTen = hoTen;
                    sv.MaKhoa = cboKhoa.SelectedValue.ToString();

                    db.SaveChanges();
                }

                MessageBox.Show(_laSua
                    ? "Cập nhật sinh viên thành công!"
                    : "Thêm sinh viên thành công!");

                // Báo cho Form2 biết dữ liệu đã được lưu
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu:\n" + ex.Message);
            }
        }
    }
}
