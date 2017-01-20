using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleFinanceiro1.Models;
using ControleFinanceiro1.DAL;
using ControleFinanceiro1.ViewModels;

namespace ControleFinanceiro1.Controllers
{
    public class GastosMesController : Controller
    {
        private ICompraRepository compraRepository;

        // GET: GastosMes

        public GastosMesController()
        {
            this.compraRepository = new CompraRepository(new FinanceiroContext());
        }

        public ActionResult Index()
        {

            var data = (from compra in compraRepository.GetCompras()
                        group compra by new { month = compra.Data.Month, year = compra.Data.Year } into d
                        select new GastosMes()
                        {
                            Mes = d.Key.month,
                            Ano = d.Key.year,
                            Valor = d.Sum(x => x.Valor)
                        }).OrderByDescending(g => g.Ano);

            return View(data.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                compraRepository.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
