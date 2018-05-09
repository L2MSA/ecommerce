using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class Estoque
    {
        public virtual Guid Id { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual double PrecoAtual { get; set; }
        public virtual int Quantidade { get; set; }
    }
    public class EstoqueMap : ClassMapping<Estoque>
    {
        public EstoqueMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            ManyToOne(x => x.Produto, m =>
            {
                m.Column("IdProduto");
                m.Lazy(LazyRelation.NoLazy);
            });
            Property(x => x.PrecoAtual);
            Property(x => x.Quantidade);
         
        }
    }
}
