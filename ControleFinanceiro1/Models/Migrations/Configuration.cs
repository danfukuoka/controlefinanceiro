namespace ControleFinanceiro1.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ControleFinanceiro1.DAL.FinanceiroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ControleFinanceiro1.DAL.FinanceiroContext";
        }
        /*
        protected override void Seed(ControleFinanceiro1.DAL.FinanceiroContext context)
        {
            var categorias = new List<Categoria>
            {
                new Categoria {Nome="Mercado"},
                new Categoria {Nome="Cinema"},
                new Categoria {Nome="Outros"}
            };
            categorias.ForEach(s => context.Categorias.Add(s));
            context.SaveChanges();

            var estabelimentos = new List<Estabelecimento>
            {
                new Estabelecimento {Nome="Carrefour"},
                new Estabelecimento {Nome="Cinemark"},
                new Estabelecimento {Nome="Americanas"},
                new Estabelecimento {Nome="Outros" }
            };

            estabelimentos.ForEach(s => context.Estabelecimentos.Add(s));
            context.SaveChanges();

            var compras = new List<Compra>
            {
                new Compra{CategoriaID=1, EstabelecimentoID=1, Data=DateTime.Parse("2017-02-01"), Valor=50.54f },
                new Compra{CategoriaID=2, EstabelecimentoID=2, Data=DateTime.Parse("2017-02-01"), Valor=17.50f }
            };
            compras.ForEach(s => context.Compras.Add(s));
            context.SaveChanges();

        }

    */
    }
}
