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
    }

    public class CategoriaMap : ClassMapping<Categoria>
    {
        public CategoriaMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);
        }
    }
}
