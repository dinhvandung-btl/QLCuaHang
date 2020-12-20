using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLCuaHang.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        public KhachHang()
        {
            XuatKhos = new HashSet<XuatKho>();

        }
        [Key]
        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(12)]
        public string DienThoai { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public string role { get; set; }
        [Required]
        public string password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string confirm_password { get; set; }


        public virtual ICollection<XuatKho> XuatKhos { get; set; }
    }
}