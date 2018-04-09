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
    public class ComentarioController : Controller
    {
        // GET: Comentario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GravarComentario(FormCollection coment)
        {
            var comentario = new Comentario();
            var id = coment["Id"];


            comentario.Usuario = LoginUtils.Usuario;
            comentario.Produto = DbFactory.Instance.ProdutoRepository.FindById(Guid.Parse(id));

            if (coment["rdBom"] == "on") {
                comentario.Avaliacao = "Bom";
            } else if (coment["rdRuim"] == "on") {
                comentario.Avaliacao = "Ruim";
            } else if (coment["rdNeutro"] == "on") {
                comentario.Avaliacao = "Neutro";
            }
            comentario.Descricao = coment["txtComentario"];


            DbFactory.Instance.ComentarioRepository.Save(comentario);
            return RedirectToAction("Index", "Home");

          
        }
    }
}