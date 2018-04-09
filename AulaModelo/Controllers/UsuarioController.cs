using AulaModelo.Modelo.DB;
using AulaModelo.Modelo.DB.Model;
using AulaModelo.Modelo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaModelo.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult CadastrarUsuario()
        {
            ViewBag.IdCategoria = new SelectList(
                DbFactory.Instance.CategoriaRepository.FindAll(),
                "Id",
                "Nome"
            );

            return View();
        }
        public ActionResult EntrarUsuario()
        {
            return View();
        }
        public ActionResult Logar(string email, string senha)
        {
            LoginUtils.Logar(email, senha);

            if (LoginUtils.Usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult Deslogar()
        {
            LoginUtils.Deslogar();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult GravarUsuario(Usuario usuario, Guid IdCategoria)
        {
            ViewBag.IdCategoria = new SelectList(
                DbFactory.Instance.CategoriaRepository.FindAll(),
                "Id",
                "Nome",
                IdCategoria
            );

            var interesse = DbFactory.Instance.CategoriaRepository.FindById(IdCategoria);
            usuario.Interesse = interesse;
            DbFactory.Instance.UsuarioRepository.SaveOrUpdate(usuario);
            return RedirectToAction("Index", "Home");
        }
        //public ActionResult Buscar(String edtBusca)
        //{


        //    Historico h = new Historico();
        //    h.Pesquisa = edtBusca;
        //    if (Session["Usuario"] != null)
        //    {
        //        h.IdUsuario = (Guid)Session["UsuarioID"];
        //    }


        //    DbFactory.Instance.HistoricoRepository.SalvandoHistorico(h);
        //    DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);

        //    if (String.IsNullOrEmpty(edtBusca))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    var pessoas = DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);

        //    return View("Home/Index", pessoas);
        //}
        public ActionResult historicoBusca()
        {
            Guid IdUsuario = new Guid();
            if (Session["Usuario"] != null)
            {
                IdUsuario = (Guid)Session["UsuarioID"];
            }

            var historico = DbFactory.Instance.HistoricoRepository.findAllById(IdUsuario);
            return View(historico);
        }
    }
}