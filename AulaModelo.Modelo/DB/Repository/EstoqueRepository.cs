using AulaModelo.Modelo.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Repository
{
    public class EstoqueRepository : RepositoryBase<Estoque>
    {
        public EstoqueRepository(ISession session) : base(session) { }
        public Estoque buscarporIdProduto(Guid id)
        {
            try
            {
                return Session.Query<Estoque>().FirstOrDefault(x => x.Produto.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Não achei todos!", ex);
            }
        }

    }
}
