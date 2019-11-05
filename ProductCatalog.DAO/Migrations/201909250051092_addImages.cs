namespace ProductCatalog.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Images", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Images");
        }
    }
}
