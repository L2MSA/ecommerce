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

        
        public ActionResult Buscar(String edtBusca)
        {
            Historico h = new Historico();
            h.Pesquisa = edtBusca;
            if (Session["Usuario"] != null)
            {
                h.IdUsuario = (Guid)Session["UsuarioID"];
            }

            DbFactory.Instance.HistoricoRepository.SalvandoHistorico(h);
            DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);
            
            if(String.IsNullOrEmpty(edtBusca))
                return RedirectToAction("Index");

            var produtos = DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);
            return View("Index", produtos);
        }
    }
}