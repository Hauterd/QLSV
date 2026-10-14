using System;
using System.Collections.Generic;
using System.Text;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSV.Models
{
    [Table("HocKy")]
    public class HocKy
    {
        [Key]
        [StringLength(10)]
        public string MaHocKy { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string TenHocKy { get; set; } = "";

        [Required]
        [StringLength(9)]
        public string NamHoc { get; set; } = "";
    }
}
