using AulaModelo.Modelo.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Repository
{
    public class HistoricoRepository : RepositoryBase<Historico>
    {
        public HistoricoRepository(ISession session) : base(session) { }

        public void SalvandoHistorico(Historico h)
        {
            try
            {
                Session.Clear();

                var transacao = Session.BeginTransaction();

                Session.SaveOrUpdate(h);

                transacao.Commit();

                //return h;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar!", ex);
            }
        }
        public IList<Historico> findAllById(Guid id)
        {
            try
            {
                return Session.CreateCriteria(typeof(Historico)).List<Historico>().Where(x => x.IdUsuario == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não achei todos!", ex);
            }
        }
    }
}
