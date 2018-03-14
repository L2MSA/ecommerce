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
        public ActionResult Logar(string usuario, string senha)
        {
            LoginUtils.Logar(usuario, senha);

            if (LoginUtils.Usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("EntrarUsuario");
            }

        }
    }
}