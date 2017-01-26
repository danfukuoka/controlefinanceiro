namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required_campos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categoria", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Estabelecimento", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estabelecimento", "Nome", c => c.String());
            AlterColumn("dbo.Categoria", "Nome", c => c.String());
        }
    }
}
