namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valor_float1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GastosMes", "Mes", c => c.Int(nullable: false));
            AddColumn("dbo.GastosMes", "Ano", c => c.Int(nullable: false));
            DropColumn("dbo.GastosMes", "DateGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GastosMes", "DateGroup", c => c.String());
            DropColumn("dbo.GastosMes", "Ano");
            DropColumn("dbo.GastosMes", "Mes");
        }
    }
}
