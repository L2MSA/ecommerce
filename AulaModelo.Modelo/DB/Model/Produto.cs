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

        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Descricao { get; set; }
        public virtual String Imagem { get; set; }
        public virtual String Fabricante { get; set; }
        public virtual Double Preco { get; set; }
        public virtual Guid IdCategoria { get; set; }
        public virtual int Estoque { get; set; }
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
            Property(x => x.Estoque);
            Property(x => x.IdCategoria);
        }
    }
}
