using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLCuaHang.Models
{
    [Table("NhapKho_CT")]
    public class NhapKho_CT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SoPhieuN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STT { get; set; }

        [StringLength(10)]
        public string MaHang { get; set; }

        public double? SLNhap { get; set; }

        [Column(TypeName = "money")]
        public decimal? DGNhap { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual NhapKho NhapKho { get; set; }
    }
}