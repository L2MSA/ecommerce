using AulaModelo.Modelo.DB;
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
        public ActionResult confiraProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            return View(produto);
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

        public ActionResult DetalharProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            return View(produto);
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
    }
}