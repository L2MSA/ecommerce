﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class Historico
    {
        public virtual Guid Id { get; set; }
        public virtual String Pesquisa { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Historico()
        {
            Usuario = new Usuario();
        }
    }



    public class HistoricoMap : ClassMapping<Historico>
    {
        public HistoricoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Pesquisa);

            ManyToOne(x => x.Usuario, m =>
            {
                m.Column("IdUsuario");
                m.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}
