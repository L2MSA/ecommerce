using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class Comentario
    {
        public virtual Guid Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual String Descricao { get; set; }
        public virtual String Avaliacao { get; set; }
    }

    public class ComentarioMap : ClassMapping<Comentario>
    {
        public ComentarioMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            ManyToOne(x => x.Usuario, m =>
            {
                m.Column("IdUsuario");
                m.Lazy(LazyRelation.NoLazy);
            });

            ManyToOne(x => x.Produto, m =>
            {
                m.Column("IdProduto");
                m.Lazy(LazyRelation.NoLazy);
            });

            Property(x => x.Descricao);
            Property(x => x.Avaliacao);
        }
    }
}
