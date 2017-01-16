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
    public class EstabelecimentoesController : Controller
    {
        private IEstabelecimentoRepository estabelecimentoRepository;

        public EstabelecimentoesController()
        {
            this.estabelecimentoRepository = new EstabelecimentoRepository(new FinanceiroContext());
        }

        // GET: Estabelecimentoes
        public ActionResult Index()
        {
            return View(estabelecimentoRepository.GetEstabelecimentos());
        }

        // GET: Estabelecimentoes/Details/5
        public ActionResult Details(int id)
        {
            Estabelecimento estabelecimento = estabelecimentoRepository.GetEstabelecimentoByID(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estabelecimentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstabelecimentoID,Nome")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {

                estabelecimentoRepository.InsertEstabelecimento(estabelecimento);
                estabelecimentoRepository.SaveEstabelecimento();

                return RedirectToAction("Index");
            }

            return View(estabelecimento);
        }

        // GET: Estabelecimentoes/Edit/5
        public ActionResult Edit(int id)
        {

            Estabelecimento estabelecimento = estabelecimentoRepository.GetEstabelecimentoByID(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // POST: Estabelecimentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstabelecimentoID,Nome")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                estabelecimentoRepository.UpdateEstabelecimento(estabelecimento);
                estabelecimentoRepository.SaveEstabelecimento();
                return RedirectToAction("Index");
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimentoes/Delete/5
        public ActionResult Delete(int id)
        {

            Estabelecimento estabelecimento = estabelecimentoRepository.GetEstabelecimentoByID(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // POST: Estabelecimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estabelecimentoRepository.DeleteEstabelecimento(id);
            estabelecimentoRepository.SaveEstabelecimento();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                estabelecimentoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
