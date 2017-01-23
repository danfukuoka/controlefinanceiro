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

using PagedList;
using System.Data.SqlClient;

namespace ControleFinanceiro1.Controllers
{
    public class ComprasController : Controller
    {
        private ICompraRepository compraRepository;
        private ICategoriaRepository categoriaRepository;
        private IEstabelecimentoRepository estabelecimentoRepository;
        private FinanceiroContext context;

        public ComprasController()
        {
            context = new FinanceiroContext();
            this.compraRepository = new CompraRepository(context);
            this.categoriaRepository = new CategoriaRepository(context);
            this.estabelecimentoRepository = new EstabelecimentoRepository(context);
        }

        // GET: Compras
        public ActionResult Index(string sortOrder, string searchString, string page)
        {


            int itens_por_pagina = 10;
            int num_pages = 0;
        
            var compras = compraRepository.GetCompras();

            //Filtro
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                compras = compras.Where(s => s.Categoria.Nome.Contains(searchString)
                                       || s.Estabelecimento.Nome.Contains(searchString));
            }

            //Paginação
            if (String.IsNullOrEmpty(page))
            {
                page = "1";
            }

            num_pages = compras.Count() / itens_por_pagina;
            if ((compras.Count() % itens_por_pagina) != 0)
            {
                num_pages = num_pages + 1;
            }

            ViewBag.num_pages = num_pages;
            ViewBag.page = Int32.Parse(page);

            compras = compras.Skip((Int32.Parse(page) - 1) * itens_por_pagina).Take(itens_por_pagina);

            //Ordenação
            ViewBag.SortParm = sortOrder;

            if (String.IsNullOrEmpty(sortOrder))
            {
                ViewBag.CategoriaSortParm = "categoria_name";
                ViewBag.EstabelicimentoSortParm = "estabelicimento_name";
                ViewBag.ValorSortParm = "valor";
                ViewBag.DateSortParm = "date";
            }

            switch (sortOrder)
            {
                case "categoria_name":
                    compras = compras.OrderBy(s => s.Categoria.Nome);
                    ViewBag.CategoriaSortParm = "categoria_name_desc";
                    ViewBag.EstabelicimentoSortParm = "estabelicimento_name";
                    ViewBag.ValorSortParm = "valor";
                    ViewBag.DateSortParm = "date";
                    break;
                case "categoria_name_desc":
                    compras = compras.OrderByDescending(s => s.Categoria.Nome);
                    ViewBag.CategoriaSortParm = "categoria_name";
                    ViewBag.EstabelicimentoSortParm = "estabelicimento_name";
                    ViewBag.ValorSortParm = "valor";
                    ViewBag.DateSortParm = "date";
                    break;
                case "estabelicimento_name":
                    compras = compras.OrderBy(s => s.Estabelecimento.Nome);
                    ViewBag.EstabelicimentoSortParm = "estabelicimento_name_desc";
                    ViewBag.CategoriaSortParm = "categoria_name";
                    ViewBag.ValorSortParm = "valor";
                    ViewBag.DateSortParm = "date";
                    break;
                case "estabelicimento_name_desc":
                    compras = compras.OrderByDescending(s => s.Estabelecimento.Nome);
                    ViewBag.EstabelicimentoSortParm = "estabelicimento_name";
                    ViewBag.CategoriaSortParm = "categoria_name";
                    ViewBag.ValorSortParm = "valor";
                    ViewBag.DateSortParm = "date";
                    break;
                case "valor":
                    compras = compras.OrderBy(s => s.Valor);
                    ViewBag.ValorSortParm = "valor_desc";
                    ViewBag.CategoriaSortParm = "categoria_name";
                    ViewBag.EstabelicimentoSortParm = "estabelicimento_name";
                    ViewBag.DateSortParm = "date";
                    break;
                case "valor_desc":
                    compras = compras.OrderByDescending(s => s.Valor);
                    ViewBag.ValorSortParm = "valor";
                    ViewBag.CategoriaSortParm = "categoria_name";
                    ViewBag.EstabelicimentoSortParm = "estabelicimento_name";
                    ViewBag.DateSortParm = "date";
                    break;
                case "date":
                    compras = compras.OrderBy(s => s.Data);
                    ViewBag.DateSortParm = "date_desc";
                    ViewBag.CategoriaSortParm = "categoria_name";
                    ViewBag.EstabelicimentoSortParm = "estabelicimento_name";
                    ViewBag.ValorSortParm = "valor";

                    break;
                case "date_desc":
                    compras = compras.OrderByDescending(s => s.Data);
                    ViewBag.DateSortParm = "date";
                    ViewBag.CategoriaSortParm = "categoria_name";
                    ViewBag.EstabelicimentoSortParm = "estabelicimento_name";
                    ViewBag.ValorSortParm = "valor";
                    break;
                default:
                    compras = compras.OrderBy(s => s.CompraID);
                    break;
            }

            return View(compras);

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

                LogOp(String.Format("Compra (ID: {0})", compra.CompraID), String.Format("Adição: {0} - R$ {1:N}", estabelecimentoRepository.GetEstabelecimentoByID(compraRepository.GetCompraByID(compra.CompraID).EstabelecimentoID).Nome, compra.Valor));

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

                LogOp(String.Format("Compra (ID: {0})", compra.CompraID), String.Format("Edição: Alterou Valor para R$ {0:N}", compra.Valor));

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

            LogOp(String.Format("Compra (ID: {0})", id), String.Format("Apagada."));

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

        //STORED PROCEDURE
        protected int LogOp(string Operacao, string Identificacao)
        {
            context.Database.ExecuteSqlCommand(
                "exec LogOperacao @Operacao, @Identificacao",
                new SqlParameter("@Operacao", Operacao),
                new SqlParameter("@Identificacao", Identificacao)
            );

            context.SaveChanges();
            return 1;
        }
    }
}
