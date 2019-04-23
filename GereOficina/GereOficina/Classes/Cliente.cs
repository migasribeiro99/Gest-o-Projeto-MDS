using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GereOficina
{
    partial class Cliente
    {

        private List<Carro> _carro;

        public Decimal Total
        {
            get
            {
                Decimal TotalCliente = 0;
                foreach (Carro item in _carro)
                {
                    TotalCliente = TotalCliente + item.Total;
                }
                return TotalCliente;
            }
        }

        public Cliente(string nomeCliente, string nifCliente)
        {
            this.NomeCliente = nomeCliente;
            this.NifCliente = nifCliente;
            _carro = new List<Carro>();

        }
        public string devolveNome()
        {
            return NomeCliente;
        }

        public string devolveNif()
        {
            return NifCliente;
        }

        public override string ToString()
        {
            return NomeCliente;
        }
    }
}

