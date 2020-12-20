namespace QLCuaHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Donvitinh_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HangHoa", "Donvitinh", c => c.String());
            AddColumn("dbo.HangHoa", "Dongia", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HangHoa", "Dongia");
            DropColumn("dbo.HangHoa", "Donvitinh");
        }
    }
}
