namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsertodonomeEstabelecimento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compra", "Estabelecimento_EstabelecimentoID", "dbo.Estabelecimento");
            DropIndex("dbo.Compra", new[] { "Estabelecimento_EstabelecimentoID" });
            RenameColumn(table: "dbo.Compra", name: "Estabelecimento_EstabelecimentoID", newName: "EstabelecimentoID");
            AlterColumn("dbo.Compra", "EstabelecimentoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Compra", "EstabelecimentoID");
            AddForeignKey("dbo.Compra", "EstabelecimentoID", "dbo.Estabelecimento", "EstabelecimentoID", cascadeDelete: true);
            DropColumn("dbo.Compra", "Estabelecimento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Compra", "Estabelecimento", c => c.Int(nullable: false));
            DropForeignKey("dbo.Compra", "EstabelecimentoID", "dbo.Estabelecimento");
            DropIndex("dbo.Compra", new[] { "EstabelecimentoID" });
            AlterColumn("dbo.Compra", "EstabelecimentoID", c => c.Int());
            RenameColumn(table: "dbo.Compra", name: "EstabelecimentoID", newName: "Estabelecimento_EstabelecimentoID");
            CreateIndex("dbo.Compra", "Estabelecimento_EstabelecimentoID");
            AddForeignKey("dbo.Compra", "Estabelecimento_EstabelecimentoID", "dbo.Estabelecimento", "EstabelecimentoID");
        }
    }
}
