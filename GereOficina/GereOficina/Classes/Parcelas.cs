using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GereOficina
{
    partial class Parcelas
    {
        public string descricaoPecas;
        public Decimal valor;

        public Parcelas(string descricaoPecas, Decimal valor)
        {
            this.descricaoPecas = descricaoPecas;
            this.valor = valor;
        }

        public override string ToString()
        {
            return descricaoPecas + " (" + valor + " €)";
        }
    }
}
