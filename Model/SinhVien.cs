
using System.ComponentModel.DataAnnotations;

namespace QLSV.Models
{
    public class SinhVien
    {
        [Key]
        public string MSSV { get; set; } = "";

        public string HoTen { get; set; } = "";

        public string MaKhoa { get; set; } = "";
    }
}
