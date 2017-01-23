using ControleFinanceiro1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.DAL
{
    public class CompraRepository : ICompraRepository, IDisposable
    {
        private FinanceiroContext context;

        public CompraRepository(FinanceiroContext context)
        {
            this.context = context;
        }

        public IEnumerable<Compra> GetCompras()
        {
            return context.Compras.ToList();
        }

        public Compra GetCompraByID(int id)
        {
            return context.Compras.Find(id);
        }

        public void InsertCompra(Compra Compra)
        {
            context.Compras.Add(Compra);
        }

        public void DeleteCompra(int CompraID)
        {
            Compra Compra = context.Compras.Find(CompraID);
            context.Compras.Remove(Compra);
        }

        public void UpdateCompra(Compra Compra)
        {
            context.Entry(Compra).State = EntityState.Modified;
        }

        public void SaveCompra()
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