using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLCuaHang.Models
{
    [Table("XuatKho_CT")]
    public class XuatKho_CT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SoPhieuX { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STT { get; set; }

        [StringLength(10)]
        public string MaHang { get; set; }

        public double? SLXuat { get; set; }

        [Column(TypeName = "money")]
        public decimal? DGXuat { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual XuatKho XuatKHo { get; set; }
    }
}