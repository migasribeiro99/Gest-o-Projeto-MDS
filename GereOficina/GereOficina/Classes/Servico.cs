using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GereOficina
{
    partial class Servico
    {
        DateTime dataServico;
        private List<Parcelas> _parcelas;

        public Decimal TotalServico
        {
            get
            {
                Decimal totalServico = 0;
                foreach (Parcelas item in _parcelas)
                {
                    totalServico += item.valor;
                }
                return totalServico;

            }

        }

        public Servico(string servico)
        {
            this.TipoServico = servico;
            _parcelas = new List<Parcelas>();
            dataServico = DateTime.Now;
        }
        public override string ToString()
        {
            return TipoServico + " (" + dataServico.ToShortDateString() + ")" + " " + TotalServico + "€";
        }
    }
}
