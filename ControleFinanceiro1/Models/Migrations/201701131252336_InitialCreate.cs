namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        CompraID = c.Int(nullable: false, identity: true),
                        CategoriaID = c.Int(nullable: false),
                        Estabelecimento = c.Int(nullable: false),
                        Estabelecimento_EstabelecimentoID = c.Int(),
                    })
                .PrimaryKey(t => t.CompraID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Estabelecimento", t => t.Estabelecimento_EstabelecimentoID)
                .Index(t => t.CategoriaID)
                .Index(t => t.Estabelecimento_EstabelecimentoID);
            
            CreateTable(
                "dbo.Estabelecimento",
                c => new
                    {
                        EstabelecimentoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.EstabelecimentoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compra", "Estabelecimento_EstabelecimentoID", "dbo.Estabelecimento");
            DropForeignKey("dbo.Compra", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Compra", new[] { "Estabelecimento_EstabelecimentoID" });
            DropIndex("dbo.Compra", new[] { "CategoriaID" });
            DropTable("dbo.Estabelecimento");
            DropTable("dbo.Compra");
            DropTable("dbo.Categoria");
        }
    }
}
