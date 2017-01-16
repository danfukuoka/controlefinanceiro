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
    public class CategoriasController : Controller
    {
        private ICategoriaRepository categoriaRepository;

        public CategoriasController()
        {
            this.categoriaRepository = new CategoriaRepository(new FinanceiroContext());
        }

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaRepository.GetCategorias());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int id)
        {
            Categoria categoria = categoriaRepository.GetCategoriaByID(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaID,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaRepository.InsertCategoria(categoria);
                categoriaRepository.SaveCategoria();

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {

            Categoria categoria = categoriaRepository.GetCategoriaByID(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaID,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {

                categoriaRepository.UpdateCategoria(categoria);
                categoriaRepository.SaveCategoria();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            Categoria categoria = categoriaRepository.GetCategoriaByID(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoriaRepository.DeleteCategoria(id);
            categoriaRepository.SaveCategoria();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                categoriaRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
