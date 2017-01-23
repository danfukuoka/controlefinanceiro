using ControleFinanceiro1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.DAL
{
    public interface ICategoriaRepository : IDisposable
    {
        IEnumerable<Categoria> GetCategorias();
        Categoria GetCategoriaByID(int CategoriaID);
        void InsertCategoria(Categoria categoria);
        void DeleteCategoria(int CategoriaID);
        void UpdateCategoria(Categoria categoria);
        void SaveCategoria();
    }
}