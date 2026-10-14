using System;
using System.Collections.Generic;
using System.Text;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSV.Models
{
    [Table("MonHoc")]
    public class MonHoc
    {
        [Key]
        [StringLength(10)]
        public string MaMonHoc { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string TenMonHoc { get; set; } = "";

        [Range(1, int.MaxValue)]
        public int SoTinChi { get; set; }

        [StringLength(10)]
        public string? MaHocKy { get; set; }

    }
}

