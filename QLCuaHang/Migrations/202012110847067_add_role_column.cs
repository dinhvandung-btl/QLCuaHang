namespace QLCuaHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_role_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHang", "role");
        }
    }
}
