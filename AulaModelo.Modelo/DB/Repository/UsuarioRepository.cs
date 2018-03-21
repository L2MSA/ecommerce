using AulaModelo.Modelo.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository(ISession session) : base(session) { }
        public IList<Usuario> GetAllByName(String nome)
        {
            try
            {
                return this.Session.Query<Usuario>().Where(w => w.Nome.ToLower() == nome.Trim().ToLower()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não achei os usuarios pelo filtro nome", ex);
            }
        }
        public Usuario Login(String login, String senha)
        {
            try
            {
                return this.Session.Query<Usuario>().FirstOrDefault(f => f.Login == login && f.Senha == senha);
            }
            catch (Exception ex)
            {
                throw new Exception("Não achei o usuário.", ex);
            }
        }
    }
}
