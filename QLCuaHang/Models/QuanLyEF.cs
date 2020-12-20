using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLCuaHang.Models
{
    public partial class QuanLyEF : DbContext
    {
        public QuanLyEF()
            : base("name=QuanLyEF")
        {
        }
        public virtual DbSet <HangHoa>HangHoas { get; set; }
        public virtual DbSet <KhachHang>KhachHangs { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<NhapKho> NhapKhos { get; set; }
        public virtual DbSet<NhapKho_CT> NhapKho_CTs { get; set; }
        public virtual DbSet<XuatKho> XuatKhos { get; set; }
        public virtual DbSet<XuatKho_CT> XuatKho_CTs { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.HangHoas)
                .WithOptional(e => e.LoaiHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhapKho_CT>()
                .Property(e => e.DGNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XuatKho_CT>()
                .Property(e => e.DGXuat)
                .HasPrecision(19, 4);
        }
    }
}
