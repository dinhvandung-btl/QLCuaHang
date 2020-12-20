using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLCuaHang.Models
{
    [Table("NhapKho")]
    public class NhapKho
    {
        public NhapKho()
        {
            NhapKho_CT = new HashSet<NhapKho_CT>();
        }
        [Key]
        [StringLength(10)]
        public string SoPhieuN { get; set; }

        public DateTime? NgayNhap { get; set; }

        [StringLength(50)]
        public string NguoiNhap { get; set; }

        [StringLength(200)]
        public string LyDoNhap { get; set; }

        public virtual ICollection<NhapKho_CT> NhapKho_CT { get; set; }

    }
}