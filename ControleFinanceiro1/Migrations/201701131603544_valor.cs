namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compra", "Data", c => c.DateTime(nullable: false));
            AddColumn("dbo.Compra", "Valor", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compra", "Valor");
            DropColumn("dbo.Compra", "Data");
        }
    }
}
