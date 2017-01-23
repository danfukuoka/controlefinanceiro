namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log_teste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estabelecimento", "date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estabelecimento", "date");
        }
    }
}
