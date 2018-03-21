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
        public ActionResult GravarUsuario(Usuario usuario)
        {
            DbFactory.Instance.UsuarioRepository.SaveOrUpdate(usuario);
            return RedirectToAction("Index", "Home");
        }
    }
}