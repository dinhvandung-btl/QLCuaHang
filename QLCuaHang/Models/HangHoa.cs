using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLCuaHang.Models
{
    [Table("HangHoa")]
    public class HangHoa
    {
        public HangHoa()
        {
            NhapKho_CT = new HashSet<NhapKho_CT>();
            XuatKho_CT = new HashSet<XuatKho_CT>();
        }
        [Key]
        [StringLength(10)]
        public string MaHang { get; set; }

        [StringLength(50)]
        public string TenHang { get; set; }

        [StringLength(50)]
        public string NhaCC { get; set; }

        [StringLength(10)]
        public string DVT { get; set; }

        [StringLength(5)]
        public string MaLoai { get; set; }
        public string Donvitinh { get; set; }
        public double? Dongia { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        public virtual LoaiHang LoaiHang { get; set; }

        public virtual ICollection<NhapKho_CT> NhapKho_CT { get; set; }
        public virtual ICollection<XuatKho_CT> XuatKho_CT { get; set; }
    }

}
