using ControleFinanceiro1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.DAL
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository, IDisposable
    {
        private FinanceiroContext context;

        public EstabelecimentoRepository(FinanceiroContext context)
        {
            this.context = context;
        }

        public IEnumerable<Models.Estabelecimento> GetEstabelecimentos()
        {
            return context.Estabelecimentos.ToList();
        }

        public Estabelecimento GetEstabelecimentoByID(int id)
        {
            return context.Estabelecimentos.Find(id);
        }

        public void InsertEstabelecimento(Estabelecimento Estabelecimento)
        {
            context.Estabelecimentos.Add(Estabelecimento);
        }

        public void DeleteEstabelecimento(int EstabelecimentoID)
        {
            Estabelecimento Estabelecimento = context.Estabelecimentos.Find(EstabelecimentoID);
            context.Estabelecimentos.Remove(Estabelecimento);
        }

        public void UpdateEstabelecimento(Estabelecimento Estabelecimento)
        {
            context.Entry(Estabelecimento).State = EntityState.Modified;
        }

        public void SaveEstabelecimento()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}