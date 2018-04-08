using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class Usuario
    {
        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Login { get; set; }
        public virtual String Senha { get; set; }
        public virtual String Telefone { get; set; }
        public virtual Categoria Interesse { get; set; }
        public virtual IList<Comentario> Comentarios { get; set; }
        public virtual Boolean AdminSN { get; set; }

        public Usuario()
        {
            Comentarios = new List<Comentario>();
        }

    }
    public class UsuarioMap : ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Nome);
            Property(x => x.Login);
            Property(x => x.Senha);
            Property(x => x.Telefone);

            ManyToOne(x => x.Interesse, m =>
            {
                m.Column("IdInteresse");
                m.Lazy(LazyRelation.NoLazy);
            });

            //Bag(x => x.Interesses, m =>
            //{
            //    m.Cascade(Cascade.Detach);
            //    m.Lazy(CollectionLazy.Lazy);
            //    m.Key(k => k.Column("IdInteresse"));
            //    m.Inverse(true);
            //},
            //r => r.OneToMany());

            Bag(x => x.Comentarios, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("IdComentario"));
                m.Inverse(true);
            },
            r => r.OneToMany());

            Property(x => x.AdminSN);
        }
    }
}
