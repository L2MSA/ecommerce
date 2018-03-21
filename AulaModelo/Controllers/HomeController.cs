using AulaModelo.Modelo.DB;
using AulaModelo.Modelo.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaModelo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var produtos = DbFactory.Instance.ProdutoRepository.FindAll();

            return View(produtos);
        }

        public ActionResult inserirProduto()
        {
            return View("EditarProduto", new Produto());
        }

        public ActionResult GravarProduto(Produto pessoa)
        {
            DbFactory.Instance.ProdutoRepository.SaveOrUpdate(pessoa);
            return RedirectToAction("Index");
        }

        public ActionResult ApagarPessoa(Guid id)
        {
            var pessoa = DbFactory.Instance.ProdutoRepository.FindById(id);
            if(pessoa != null)
            {
                DbFactory.Instance.ProdutoRepository.Delete(pessoa);
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult DetalharProduto(Guid id)
        {
            return View();
        }
        public ActionResult Buscar(String edtBusca)
        {

            DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);
            
            if(String.IsNullOrEmpty(edtBusca))
            {
                return RedirectToAction("Index");
            }
            var pessoas = DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);

            return View("Index", pessoas);
        }

        public ActionResult EditarProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            if (produto != null)
            {
                return View(produto);
            }
            else
            {
                return RedirectToAction("Index");
            }

            
        }

    }
}