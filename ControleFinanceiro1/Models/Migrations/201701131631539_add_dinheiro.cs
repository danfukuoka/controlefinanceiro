namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_dinheiro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Compra", "Valor", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Compra", "Valor", c => c.Double(nullable: false));
        }
    }
}
