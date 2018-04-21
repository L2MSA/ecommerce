using AulaModelo.Modelo.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Repository
{
    public class CarrinhoRepository : RepositoryBase<Carrinho>
    {
        public CarrinhoRepository(ISession session) : base(session) { }

        public IList<Carrinho> findAllById(Guid id)
        {
            try
            {
                return Session.CreateCriteria(typeof(Carrinho)).List<Carrinho>().Where(x => x.Usuario.Id == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não achei todos!", ex);
            }
        }
        public double totalPreco(Guid id)
        {
            double precoTotal = 0;
            var lista = DbFactory.Instance.CarrinhoRepository.findAllById(id);
            for (int i = 0; i < lista.Count; i++)
            {
                precoTotal = precoTotal + lista[i].Produto.Preco;
            }
            return precoTotal;
        }
    }
}
