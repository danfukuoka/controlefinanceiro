namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gastosmes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GastosMes", "DateGroup", c => c.DateTime());
            DropColumn("dbo.GastosMes", "Mes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GastosMes", "Mes", c => c.Int(nullable: false));
            DropColumn("dbo.GastosMes", "DateGroup");
        }
    }
}
