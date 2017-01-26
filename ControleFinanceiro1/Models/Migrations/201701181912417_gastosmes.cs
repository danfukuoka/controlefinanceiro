namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gastosmes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GastosMes",
                c => new
                    {
                        GastosMesID = c.Int(nullable: false, identity: true),
                        Mes = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GastosMesID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GastosMes");
        }
    }
}
