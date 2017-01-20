using ControleFinanceiro1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.DAL
{
    public class FinanceiroContext : DbContext
    {

        public FinanceiroContext() : base("FinanceiroContext")
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ControleFinanceiro1.ViewModels.GastosMes> GastosMes { get; set; }
    }
}