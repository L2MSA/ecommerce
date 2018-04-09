using AulaModelo.Modelo.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Repository
{
    public class ComentarioRepository : RepositoryBase<Comentario>
    {
        public ComentarioRepository(ISession session) : base(session) { }

            public IList<Comentario> GetAllByUser(Guid IdUsuario)
            {
                try
                {
                    return this.Session.Query<Comentario>().Where(w => w.Id == IdUsuario).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Não achei os comentarios desse Usuario", ex);
                }
            }

        public IList<Comentario> GetAllByProduto(Guid IdProduto)
        {
            try
            {
                return this.Session.Query<Comentario>().Where(w => w.Id == IdProduto).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não achei os comentarios desse produto", ex);
            }
        }

    }
}
