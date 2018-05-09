using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class Produto
    {
        public static List<Produto> Produtos = new List<Produto>();
        private static Random rnd = new Random();

        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Descricao { get; set; }
        public virtual String Imagem { get; set; }
        public virtual String Fabricante { get; set; }
        public virtual Double Preco { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual IList<Comentario> Comentarios { get; set; }
        public virtual Estoque Estoque { get; set; }

        public Produto()
        {
            Comentarios = new List<Comentario>();
        }
    }

    public class ProdutoMap : ClassMapping<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);
            Property(x => x.Descricao);
            Property(x => x.Imagem);
            Property(x => x.Fabricante);
            Property(x => x.Preco);
            Bag(x => x.Comentarios, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("IdProduto"));
                m.Inverse(true);
            },
            r => r.OneToMany());


            ManyToOne(x => x.Categoria, m =>
            {
                m.Column("IdCategoria");
                m.Lazy(LazyRelation.NoLazy);
            });

            
        }
    }
}