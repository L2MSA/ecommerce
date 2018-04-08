using AulaModelo.Modelo.DB;
using AulaModelo.Modelo.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaModelo.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InserirProduto()
        {
            ViewBag.IdCategoria = new SelectList(
                DbFactory.Instance.CategoriaRepository.FindAll(),
                "Id",
                "Nome"
            );

            return View("EditarProduto", new Produto());
        }

        public ActionResult EditarProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);

            ViewBag.IdCategoria = new SelectList(
                DbFactory.Instance.CategoriaRepository.FindAll(),
                "Id",
                "Nome"
            );

            if (produto != null)
                return View(produto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GravarProduto(Produto produto, Guid IdCategoria)
        {

            ViewBag.IdCategoria = new SelectList(
                DbFactory.Instance.CategoriaRepository.FindAll(),
                "Id",
                "Nome",
                IdCategoria
            );

            var categoria = DbFactory.Instance.CategoriaRepository.FindById(IdCategoria);
            produto.Categoria = categoria;
            DbFactory.Instance.ProdutoRepository.SaveOrUpdate(produto);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ApagarProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            if (produto != null)
                DbFactory.Instance.ProdutoRepository.Delete(produto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ExibirProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            return View("ExibirProduto", produto);
        }

        public static double descontoAvista(double valor)
        {
            return valor = valor - (valor / 100) * 15;
        }

        public ActionResult GerenciarProduto()
        {
            var produtos = DbFactory.Instance.ProdutoRepository.FindAll().ToList();

            return View(produtos);
        }

        public ActionResult Buscar(String edtBusca)
        {

            DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);

            if (String.IsNullOrEmpty(edtBusca))
            {
                return RedirectToAction("Index");
            }
            var pessoas = DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);

            return View("Index", pessoas);
        }

        

        public ActionResult DetalharProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            if (produto != null)
                return View(produto);

            return RedirectToAction("Index");
        }
    }
}