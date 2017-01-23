namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log_teste2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Estabelecimento", "date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estabelecimento", "date", c => c.String());
        }
    }
}
