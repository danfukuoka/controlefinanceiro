using ControleFinanceiro1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.DAL
{
    public class CategoriaRepository : ICategoriaRepository, IDisposable
    {
        private FinanceiroContext context;

        public CategoriaRepository(FinanceiroContext context)
        {
            this.context = context;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return context.Categorias.ToList();
        }

        public Categoria GetCategoriaByID(int id)
        {
            return context.Categorias.Find(id);
        }

        public void InsertCategoria(Categoria Categoria)
        {
            context.Categorias.Add(Categoria);
        }

        public void DeleteCategoria(int CategoriaID)
        {
            Categoria Categoria = context.Categorias.Find(CategoriaID);
            context.Categorias.Remove(Categoria);
        }

        public void UpdateCategoria(Categoria Categoria)
        {
            context.Entry(Categoria).State = EntityState.Modified;
        }

        public void SaveCategoria()
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