namespace QLCuaHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KhachHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HangHoa",
                c => new
                    {
                        MaHang = c.String(nullable: false, maxLength: 10),
                        TenHang = c.String(maxLength: 50),
                        NhaCC = c.String(maxLength: 50),
                        DVT = c.String(maxLength: 10),
                        MaLoai = c.String(maxLength: 5),
                        HinhAnh = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaHang)
                .ForeignKey("dbo.LoaiHang", t => t.MaLoai, cascadeDelete: true)
                .Index(t => t.MaLoai);
            
            CreateTable(
                "dbo.LoaiHang",
                c => new
                    {
                        MaLoai = c.String(nullable: false, maxLength: 5),
                        TenLoai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoai);
            
            CreateTable(
                "dbo.NhapKho_CT",
                c => new
                    {
                        SoPhieuN = c.String(nullable: false, maxLength: 10),
                        STT = c.Int(nullable: false),
                        MaHang = c.String(maxLength: 10),
                        SLNhap = c.Double(),
                        DGNhap = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => new { t.SoPhieuN, t.STT })
                .ForeignKey("dbo.HangHoa", t => t.MaHang)
                .ForeignKey("dbo.NhapKho", t => t.SoPhieuN, cascadeDelete: true)
                .Index(t => t.SoPhieuN)
                .Index(t => t.MaHang);
            
            CreateTable(
                "dbo.NhapKho",
                c => new
                    {
                        SoPhieuN = c.String(nullable: false, maxLength: 10),
                        NgayNhap = c.DateTime(),
                        NguoiNhap = c.String(maxLength: 50),
                        LyDoNhap = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.SoPhieuN);
            
            CreateTable(
                "dbo.XuatKho_CT",
                c => new
                    {
                        SoPhieuX = c.String(nullable: false, maxLength: 10),
                        STT = c.Int(nullable: false),
                        MaHang = c.String(maxLength: 10),
                        SLXuat = c.Double(),
                        DGXuat = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => new { t.SoPhieuX, t.STT })
                .ForeignKey("dbo.HangHoa", t => t.MaHang)
                .ForeignKey("dbo.XuatKho", t => t.SoPhieuX, cascadeDelete: true)
                .Index(t => t.SoPhieuX)
                .Index(t => t.MaHang);
            
            CreateTable(
                "dbo.XuatKho",
                c => new
                    {
                        SoPhieuX = c.String(nullable: false, maxLength: 10),
                        NgayXuat = c.DateTime(),
                        MaKH = c.String(maxLength: 10),
                        LyDoXuat = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.SoPhieuX)
                .ForeignKey("dbo.KhachHang", t => t.MaKH)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 10),
                        TenKH = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 100),
                        DienThoai = c.String(maxLength: 12),
                        Email = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.XuatKho_CT", "SoPhieuX", "dbo.XuatKho");
            DropForeignKey("dbo.XuatKho", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.XuatKho_CT", "MaHang", "dbo.HangHoa");
            DropForeignKey("dbo.NhapKho_CT", "SoPhieuN", "dbo.NhapKho");
            DropForeignKey("dbo.NhapKho_CT", "MaHang", "dbo.HangHoa");
            DropForeignKey("dbo.HangHoa", "MaLoai", "dbo.LoaiHang");
            DropIndex("dbo.XuatKho", new[] { "MaKH" });
            DropIndex("dbo.XuatKho_CT", new[] { "MaHang" });
            DropIndex("dbo.XuatKho_CT", new[] { "SoPhieuX" });
            DropIndex("dbo.NhapKho_CT", new[] { "MaHang" });
            DropIndex("dbo.NhapKho_CT", new[] { "SoPhieuN" });
            DropIndex("dbo.HangHoa", new[] { "MaLoai" });
            DropTable("dbo.KhachHang");
            DropTable("dbo.XuatKho");
            DropTable("dbo.XuatKho_CT");
            DropTable("dbo.NhapKho");
            DropTable("dbo.NhapKho_CT");
            DropTable("dbo.LoaiHang");
            DropTable("dbo.HangHoa");
        }
    }
}
