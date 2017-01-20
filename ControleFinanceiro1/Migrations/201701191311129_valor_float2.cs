namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valor_float2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GastosMes", "Dia", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GastosMes", "Dia");
        }
    }
}
