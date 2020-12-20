using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLCuaHang.Models
{
    [Table("XuatKho")]
    public class XuatKho
    {
        public XuatKho()
        {
            XuatKho_CT = new HashSet<XuatKho_CT>();
        }
        [Key]
        [StringLength(10)]
        public string SoPhieuX { get; set; }

        public DateTime? NgayXuat { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(200)]
        public string LyDoXuat { get; set; }

        public virtual KhachHang KhachHang { get; set; }


        public virtual ICollection<XuatKho_CT> XuatKho_CT { get; set; }
    }
}