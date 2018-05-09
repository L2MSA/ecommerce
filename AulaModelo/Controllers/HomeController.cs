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
            var users = DbFactory.Instance.UsuarioRepository.FindAll();
            if (users.Count <= 0)
            {
                Usuario usuario = new Usuario()
                {
                    Nome = "Administrador",
                    AdminSN = true,
                    Login = "admin",
                    Senha = "admin",
                };
                DbFactory.Instance.UsuarioRepository.SaveOrUpdate(usuario);
            }

            var produtos = DbFactory.Instance.ProdutoRepository.FindAll();
            var cat = DbFactory.Instance.CategoriaRepository.FindAll();
            if(cat.Count <= 0)
            {
                Categoria c = new Categoria()
                {
                    Nome = "Esporte"
                };
                DbFactory.Instance.CategoriaRepository.Save(c);
            }
            

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

        public ActionResult ApagarProduto(Guid id)
        {
            var p = DbFactory.Instance.ProdutoRepository.FindById(id);
            if (p != null)
            {
                DbFactory.Instance.ProdutoRepository.Delete(p);
            }

            return RedirectToAction("Index");
        }
        public ActionResult DetalharProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            ViewBag.IdProduto = produto.Id;
            if (produto != null)
            {
                return View(produto);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Buscar(String edtBusca)
        {
            Historico h = new Historico();
            h.Pesquisa = edtBusca;
            if (Session["Usuario"] != null)
            {
                h.Usuario.Id = (Guid)Session["UsuarioID"];
            }


            DbFactory.Instance.HistoricoRepository.SalvandoHistorico(h);
            DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);



            DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);

            if (String.IsNullOrEmpty(edtBusca))
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


        public ActionResult BuscaAvancada()
        {
            // Busca por categoria
            ViewBag.IdCategoria = new SelectList(
                DbFactory.Instance.CategoriaRepository.FindAll(),
                "Id",
                "Nome"
            );

            return View();
        }

        [HttpPost]
        public ActionResult BuscaAvancada(FormCollection form)
        {
            String tipoBusca = form["tipoBusca"];

            if (tipoBusca.Contains("BuscaCategoria"))
            {
                var catGuid = Guid.Parse(form["IdCategoria"]);
                var produtos = DbFactory.Instance.ProdutoRepository.GetAllByCategoria(catGuid);
                return View("Index", produtos);
            }

            if (tipoBusca.Contains("BuscaPorPreco"))
            {
                var preco = Double.Parse(form["precoProduto"]);
                var produtos = DbFactory.Instance.ProdutoRepository.BuscaProdutoPorPreco(preco);
                return View("Index", produtos);
            }

            return View("Index");
        }
    }
}