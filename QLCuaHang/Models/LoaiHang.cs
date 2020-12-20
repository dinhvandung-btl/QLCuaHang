using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLCuaHang.Models
{
    [Table("LoaiHang")]
    public class LoaiHang
    {
        public LoaiHang()
        {
            HangHoas = new HashSet<HangHoa>();
        }

        [Key]
        [StringLength(5)]
        public string MaLoai { get; set; }

        [StringLength(50)]
        public string TenLoai { get; set; }

        public virtual ICollection<HangHoa> HangHoas { get; set; }

    }
}