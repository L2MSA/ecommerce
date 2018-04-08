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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var users = DbFactory.Instance.UsuarioRepository.FindAll();
            var categorias = DbFactory.Instance.CategoriaRepository.FindAll();

            if (categorias.Count <= 0)
            {
                Categoria categoria = new Categoria()
                {
                    Nome = "Sem categoria"
                };
                DbFactory.Instance.CategoriaRepository.SaveOrUpdate(categoria);
            }

            if (users.Count <= 0)
            {
                Usuario usuario = new Usuario()
                {
                    Nome = "Administrador",
                    AdminSN = true,
                    Login = "usuario",
                    Senha = "usuario",
                    Telefone = "00000000000"
                };
                DbFactory.Instance.UsuarioRepository.SaveOrUpdate(usuario);
            }

            IList<Produto> produtos = new List<Produto>();
            IList<Produto> sortProdutos = new List<Produto>();

            if (LoginUtils.Usuario != null)
            {
                Usuario usuario = LoginUtils.Usuario;
                if (usuario.AdminSN)
                {
                    produtos = DbFactory.Instance.ProdutoRepository.FindAll();
                    return View(produtos);
                }

                var idInteresse = usuario.Interesse.Id;
                produtos = DbFactory.Instance.ProdutoRepository.GetAllByCategoria(idInteresse);
                sortProdutos = produtos.OrderBy(a => Guid.NewGuid()).ToList();
                return View(sortProdutos);
            }

            produtos = DbFactory.Instance.ProdutoRepository.FindAll();
            sortProdutos = produtos.OrderBy(a => Guid.NewGuid()).ToList();
            return View(sortProdutos);
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
            
            if(String.IsNullOrEmpty(edtBusca))
                return RedirectToAction("Index");

            var produtos = DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);
            return View("Index", produtos);
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