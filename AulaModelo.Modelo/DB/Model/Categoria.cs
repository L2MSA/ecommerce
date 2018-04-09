using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class Categoria
    {
        public static List<Categoria> Categorias = new List<Categoria>();

        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual IList<Produto> Produtos { get; set; }

        public Categoria()
        {
            Produtos = new List<Produto>();
        }
    }

    public class CategoriaMap : ClassMapping<Categoria>
    {
        public CategoriaMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);

            Bag(x => x.Produtos, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("IdCategoria"));
                m.Inverse(true);
            },
            r => r.OneToMany());
        }
    }
}