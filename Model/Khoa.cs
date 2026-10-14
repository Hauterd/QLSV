
using System.ComponentModel.DataAnnotations;

namespace QLSV.Models
{
    public class Khoa
    {
        [Key]
        public string MaKhoa { get; set; } = "";

        public string TenKhoa { get; set; } = "";
    }
}
