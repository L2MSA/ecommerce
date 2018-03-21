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
    }
}