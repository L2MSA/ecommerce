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

        //public IList<Comentario> GetAllByName(String nome)
        //{
        //    try
        //    {
        //        return this.Session.Query<Categoria>().Where(w => w.Nome.ToLower().Contains(nome.Trim().ToLower())).ToList();
        //    }catch(Exception ex)
        //    {
        //        throw new Exception("Não achei as categorias pelo nome", ex);
        //    }
        //}
    }
}
