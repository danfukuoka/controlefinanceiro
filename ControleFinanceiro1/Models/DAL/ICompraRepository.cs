using ControleFinanceiro1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.DAL
{
    public interface ICompraRepository : IDisposable
    {
        IEnumerable<Compra> GetCompras();
        Compra GetCompraByID(int CompraID);
        void InsertCompra(Compra compra);
        void DeleteCompra(int CompraID);
        void UpdateCompra(Compra compra);
        void SaveCompra();
    }
}