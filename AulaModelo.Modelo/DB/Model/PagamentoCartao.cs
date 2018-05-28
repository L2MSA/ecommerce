using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class PagamentoCartao
    {
        public String NumeroCartao { get; set; }
        public String Codigo { get; set; }
        public String NomeCliente { get; set; }
        public String Validade { get; set; }
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public String NomeEmpresa { get; set; }
        public String CNPJEmpresa { get; set; }

    }
}
