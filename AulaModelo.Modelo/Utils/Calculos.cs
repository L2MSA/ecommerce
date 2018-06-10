using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.Utils
{
    public class Calculos
    {
        public object cartaoDados = new object();
        public double CalcPrecoMinimo(double precoAtual, double PrecoEstoqueNovo, double estoqueAtual, double estoqueNovo)
        {
            double PrecoMinimo = ((estoqueAtual * precoAtual) + (estoqueNovo * PrecoEstoqueNovo)) / (estoqueAtual + estoqueNovo);
            return Math.Round(PrecoMinimo, 2);
        }

        public double CalcPrecoImpostos(double valor)
        {
            double precoVenda;
            double despVariavel = 5.60;
            double despFixa = 3;
            double margLucro = 20;
            double Impostos = 36.25;

            var totalImpostos = despVariavel + despFixa + margLucro + Impostos;

            precoVenda = valor * (1 + (totalImpostos / 100));



            return Math.Round(precoVenda, 2);
        }

        public double CalcImpostosNFe(double valor)
        {
            double precoVenda;
            double despVariavel = 5.60;
            double despFixa = 3;
            double margLucro = 20;
            double Impostos = 36.25;

            var totalImpostos = despVariavel + despFixa + margLucro + Impostos;

            precoVenda = valor * (1 + (totalImpostos / 100));



            return Math.Round(precoVenda, 2);
        }

    }
}
