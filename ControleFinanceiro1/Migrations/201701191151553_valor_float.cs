namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valor_float : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GastosMes", "Valor", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GastosMes", "Valor", c => c.Int(nullable: false));
        }
    }
}
