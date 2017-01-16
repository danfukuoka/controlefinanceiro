using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleFinanceiro1.DAL;
using ControleFinanceiro1.Models;

namespace ControleFinanceiro1.Controllers
{
    public class ComprasController : Controller
    {
        private ICompraRepository compraRepository;
        private ICategoriaRepository categoriaRepository;
        private IEstabelecimentoRepository estabelecimentoRepository;

        public ComprasController()
        {
            this.compraRepository = new CompraRepository(new FinanceiroContext());
            this.categoriaRepository = new CategoriaRepository(new FinanceiroContext());
            this.estabelecimentoRepository = new EstabelecimentoRepository(new FinanceiroContext());
        }

        // GET: Compras
        public ActionResult Index()
        {
            //var compras = db.Compras.Include(c => c.Categoria).Include(c => c.Estabelecimento);

            return View(compraRepository.GetCompras());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int id)
        {

            Compra compra = compraRepository.GetCompraByID(id);

            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(categoriaRepository.GetCategorias(), "CategoriaID", "Nome");
            ViewBag.EstabelecimentoID = new SelectList(estabelecimentoRepository.GetEstabelecimentos(), "EstabelecimentoID", "Nome");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompraID,CategoriaID,EstabelecimentoID,Data,Valor")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                compraRepository.InsertCompra(compra);
                compraRepository.SaveCompra();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(categoriaRepository.GetCategorias(), "CategoriaID", "Nome", compra.CategoriaID);
            ViewBag.EstabelecimentoID = new SelectList(estabelecimentoRepository.GetEstabelecimentos(), "EstabelecimentoID", "Nome", compra.EstabelecimentoID);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int id)
        {
            Compra compra = compraRepository.GetCompraByID(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(categoriaRepository.GetCategorias(), "CategoriaID", "Nome", compra.CategoriaID);
            ViewBag.EstabelecimentoID = new SelectList(estabelecimentoRepository.GetEstabelecimentos(), "EstabelecimentoID", "Nome", compra.EstabelecimentoID);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompraID,CategoriaID,EstabelecimentoID,Data,Valor")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                compraRepository.UpdateCompra(compra);
                compraRepository.SaveCompra();

                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(categoriaRepository.GetCategorias(), "CategoriaID", "Nome", compra.CategoriaID);
            ViewBag.EstabelecimentoID = new SelectList(estabelecimentoRepository.GetEstabelecimentos(), "EstabelecimentoID", "Nome", compra.EstabelecimentoID);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int id)
        {
            Compra compra = compraRepository.GetCompraByID(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            compraRepository.DeleteCompra(id);
            compraRepository.SaveCompra();
            return RedirectToAction("Index");
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
