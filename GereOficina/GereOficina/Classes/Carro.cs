using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GereOficina
{
    partial class Carro
    {
        private List<Servico> _servico;

        public Decimal Total
        {
            get
            {
                Decimal totalCarro = 0;
                foreach (Servico item in _servico)
                {
                    totalCarro += item.TotalServico;
                }
                return totalCarro;
            }
        }

        public Carro(string marca, string modelo, string matricula, string combustivel)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Matricula = matricula;
            this.Combustivel = combustivel;
            _servico = new List<Servico>();
        }

        public string devolveMarca()
        {
            return Marca;
        }

        public string devolveModelo()
        {
            return Modelo;
        }

        public string devolveMatricula()
        {
            return Matricula;
        }

        public override string ToString()
        {
            return Marca + " " + Modelo;
        }
    }
}

