using AulaModelo.Modelo.DB;
using AulaModelo.Modelo.DB.Model;
using AulaModelo.Modelo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AulaModelo.WSPagamento;

namespace AulaModelo.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InserirProduto()
        {
            ViewBag.IdCategoria = new SelectList(
                DbFactory.Instance.CategoriaRepository.FindAll(),
                "Id",
                "Nome"
            );

            return View("EditarProduto", new Produto());
        }

        public ActionResult EditarProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);

            ViewBag.IdCategoria = new SelectList(
                DbFactory.Instance.CategoriaRepository.FindAll(),
                "Id",
                "Nome"
            );

            if (produto != null)
                return View(produto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GravarProduto(Produto produto, Guid IdCategoria)
        {

            ViewBag.IdCategoria = new SelectList(
            DbFactory.Instance.CategoriaRepository.FindAll(),
            "Id",
            "Nome",
            IdCategoria
        );

            if (produto.Id.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                var categoria = DbFactory.Instance.CategoriaRepository.FindById(IdCategoria);
                produto.Categoria = categoria;
                DbFactory.Instance.ProdutoRepository.SaveOrUpdate(produto);
                Estoque estoque = new Estoque()
                {
                    Produto = produto,
                    PrecoAtual = produto.Preco,
                    Quantidade = produto.Estoque.Quantidade

                };
                DbFactory.Instance.EstoqueRepository.SaveOrUpdate(estoque);
            }
            else
            {
                var categoria = DbFactory.Instance.CategoriaRepository.FindById(IdCategoria);
                produto.Categoria = categoria;

                Estoque estoque = new Estoque()
                {
                    Produto = produto,
                    PrecoAtual = produto.Preco,
                    Quantidade = produto.Estoque.Quantidade

                };

                var e = DbFactory.Instance.EstoqueRepository.buscarporIdProduto(produto.Id);
                var p = DbFactory.Instance.ProdutoRepository.FindById(produto.Id);

                var precoAtual = p.Preco;
                var PrecoEstoqueNovo = produto.Preco;
                var estoqueAtual = e.Quantidade;
                var estoqueNovo = produto.Estoque.Quantidade;

                var PrecoMinimo = CalcPrecoMinimo(precoAtual, PrecoEstoqueNovo, estoqueAtual, estoqueNovo);

                estoque = e;
                estoque.Quantidade += produto.Estoque.Quantidade;
                estoque.PrecoAtual = Math.Round(produto.Preco, 2);
                produto.Estoque = estoque;
                

                produto.Preco = CalcPrecoImpostos(PrecoMinimo);

                

                DbFactory.Instance.ProdutoRepository.SaveOrUpdate(produto);
                DbFactory.Instance.EstoqueRepository.SaveOrUpdate(produto.Estoque);
            }



            return RedirectToAction("Index", "Home");
        }

        public double CalcPrecoMinimo(double precoAtual, double PrecoEstoqueNovo, double estoqueAtual, double estoqueNovo)
        {
            double PrecoMinimo = ((estoqueAtual * precoAtual) + (estoqueNovo * PrecoEstoqueNovo)) / (estoqueAtual + estoqueNovo);
            return Math.Round(PrecoMinimo, 2);
        }

        public double CalcPrecoImpostos(double precoMinimo)
        {
            double precoVenda;
            double despVariavel = 5.60;
            double despFixa = 3;
            double margLucro = 20;
            double Impostos = 36.25;

            var totalImpostos = despVariavel + despFixa + margLucro + Impostos;

            precoVenda = precoMinimo * (1 + (totalImpostos / 100));

           

            return Math.Round(precoVenda, 2);
        }

        public ActionResult ApagarProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            if (produto != null)
                DbFactory.Instance.ProdutoRepository.Delete(produto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ExibirProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            return View("ExibirProduto", produto);
        }

        public static double descontoAvista(double valor)
        {
            return valor = valor - (valor / 100) * 15;
        }

        public ActionResult GerenciarProduto()
        {
            var produtos = DbFactory.Instance.ProdutoRepository.FindAll().ToList();

            return View(produtos);
        }

        public ActionResult Buscar(String edtBusca)
        {

            DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);

            if (String.IsNullOrEmpty(edtBusca))
            {
                return RedirectToAction("Index");
            }
            var pessoas = DbFactory.Instance.ProdutoRepository.GetAllByName(edtBusca);

            return View("Index", pessoas);
        }



        public ActionResult DetalharProduto(Guid id)
        {
            ViewBag.IdProduto = id;
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            if (produto != null)
                return View(produto);

            return RedirectToAction("Index");
        }

        public ActionResult ComentariosProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);


            double TotalComentariosBons = (double)produto.Comentarios.Where(w => w.Avaliacao == "Bom").Count() / produto.Comentarios.Count();
            double TotalComentariosRuins = (double)produto.Comentarios.Where(w => w.Avaliacao == "Ruim").Count() / produto.Comentarios.Count();
            double TotalComentariosNeutros = (double)produto.Comentarios.Where(w => w.Avaliacao == "Neutro").Count() / produto.Comentarios.Count();


            ViewBag.TotalComentariosBons = TotalComentariosBons * 100;
            ViewBag.TotalComentariosRuins = TotalComentariosRuins * 100;
            ViewBag.TotalComentariosNeutros = TotalComentariosNeutros * 100;


            if (produto != null)
                return View(produto);

            return View("ComentariosProduto", produto.Comentarios);
        }
        public ActionResult adicionaraoCarrinho(Guid id)
        {

            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            //Produto preenchido//
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];
            //Usuario preenchido//
            Carrinho carrinho = new Carrinho();
            carrinho.Produto = produto;
            carrinho.Usuario = usuario;
            var addCarrinho = DbFactory.Instance.CarrinhoRepository.Save(carrinho);
            return RedirectToAction("ExibirProduto/" + id);
        }
        public ActionResult viewCarrinho()
        {
            var Id = (Guid)Session["UsuarioId"];
            var listadeCarrinhos = DbFactory.Instance.CarrinhoRepository.findAllById(Id);
            return View(listadeCarrinhos);
        }
        public ActionResult gravarComentario(Comentario comentario)
        {
            return RedirectToAction("");
        }

        public ActionResult apagardoCarrinho(Guid id)
        {
            var carrinho = DbFactory.Instance.CarrinhoRepository.FindById(id);
            DbFactory.Instance.CarrinhoRepository.Delete(carrinho);
            return RedirectToAction("viewCarrinho");
        }

        public ActionResult FinalizarCompra()
        {

            //int[] parcelas = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ////ViewBag.parcelas = parcelas;

            //ViewBag.parcelas = new SelectList(
            //    parcelas,
            //    "parcelas"
            //);
            return View(new tDadosCartao());
        }

        public ActionResult ConfirmarCompra(tDadosCartao cartao)
        {
            Card ServiceCard = new Card();  //chamada do WS de pagamento de cartao
            var mensagem = "";

            try
            {
                ServiceCard.ValidarCartao(cartao);
                return View("CompraConfirmada");
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                ViewBag.mensagem = mensagem;
                return View("FinalizarCompra", cartao);
            }        
        }
    }
}