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
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            var categorias = DbFactory.Instance.CategoriaRepository.FindAll();
            return View(categorias);
        }

        public ActionResult CriarCategoria()
        {
            if(LoginUtils.Usuario != null)
            {
                if(LoginUtils.Usuario.AdminSN == true)
                    return View(new Categoria());

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditarCategoria(Guid id)
        {
            if(LoginUtils.Usuario != null)
            {
                if(LoginUtils.Usuario.AdminSN == true)
                {
                    var categoria = DbFactory.Instance.CategoriaRepository.FindById(id);
                    if (categoria != null)
                    {
                        return View("CriarCategoria", categoria);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult SalvarCategoria(Categoria categoria)
        {
            if(LoginUtils.Usuario != null)
            {
                if (LoginUtils.Usuario.AdminSN)
                {
                    DbFactory.Instance.CategoriaRepository.SaveOrUpdate(categoria);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult ApagarCategoria(Guid id)
        {
            if(LoginUtils.Usuario != null)
            {
                if(LoginUtils.Usuario.AdminSN == true)
                {
                    var categoria = DbFactory.Instance.CategoriaRepository.FindById(id);
                    if (categoria != null)
                        DbFactory.Instance.CategoriaRepository.Delete(categoria);
                }
            }
            return RedirectToAction("Index");
        }
    }
}