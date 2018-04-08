using AulaModelo.Modelo.DB;
using AulaModelo.Modelo.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.Utils
{
    public class ListaCategorias
    {
        public static IList<Categoria> Categorias = new List<Categoria>();

        public IList<Categoria> getCategorias()
        {
            Categorias = DbFactory.Instance.CategoriaRepository.FindAll();
            return Categorias;
        }
    }
}
