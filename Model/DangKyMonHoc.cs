using System;
using System.Collections.Generic;
using System.Text;


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSV.Models
{
    [Table("DangKyMonHoc")]
    public class DangKyMonHoc
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string MSSV { get; set; } = "";

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaMonHoc { get; set; } = "";

        public DateTime NgayDangKy { get; set; } = DateTime.Now;
    }
}

