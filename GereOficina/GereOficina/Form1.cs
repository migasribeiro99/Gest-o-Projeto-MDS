using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GereOficina
{
    public partial class Form1 : Form
    {
        private Model1Container minhaOficina;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdicionarCliente_Click(object sender, EventArgs e)
        {
            if (textBoxNomeCliente.Text.Length == 0 || textBoxNifCliente.Text.Length == 0 || comboBoxCidade.Text.Length == 0)
            {
                MessageBox.Show("Preencha Todos os Campos!!", "Alerta");
                return;
            }
            string cidade = comboBoxCidade.Text;
            Cliente novoCliente = new Cliente(textBoxNomeCliente.Text, textBoxNifCliente.Text);

            textBoxNomeCliente.Text = "";
            textBoxNifCliente.Text = "";
            comboBoxCidade.Text = "";

            minhaOficina.Clientes.Add(novoCliente);
            minhaOficina.SaveChanges();
            listBoxClientes.DataSource = null;
            CarregarDadosClientes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            minhaOficina = new Model1Container();
            CarregarDadosClientes();
        }

        private void listBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = (Cliente)listBoxClientes.SelectedItem;
            CarregarDadosCarros();
            string nomeCliente = clienteSelecionado.devolveNome();
            string nifCliente = clienteSelecionado.devolveNif();

            listBoxServico.DataSource = null;
            listBoxReparacao.DataSource = null;
            if (clienteSelecionado == null)
                return;

            listBoxCarro.DataSource = null;
            if (clienteSelecionado.Carro == null)
                return;
            listBoxCarro.DataSource = clienteSelecionado.Carro.ToList<Carro>();

            labelNomeCliente.Text = nomeCliente;
            labelNifCliente.Text = nifCliente;
        }

        private void buttonAdicionarCarro_Click(object sender, EventArgs e)
        {
            string combustivel = comboBoxCombustivel.Text;

            if (listBoxClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um Cliente!!!", "Alerta!");
                return;
            }
            Cliente clienteSelecionado = (Cliente)listBoxClientes.SelectedItem;

            Carro novoCarro = new Carro(textBoxMarcaCarro.Text, textBoxModeloCarro.Text, textBoxMatriculaCarro.Text, combustivel);
            try
            {
                clienteSelecionado.Carro.Add(novoCarro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            listBoxCarro.DataSource = null;
            listBoxCarro.DataSource = clienteSelecionado.Carro.ToList<Carro>(); ;

            textBoxMarcaCarro.Text = "";
            textBoxModeloCarro.Text = "";
            comboBoxCombustivel.Text = "";
            textBoxMatriculaCarro.Text = "";

            minhaOficina.Carros.Add(novoCarro);
            minhaOficina.SaveChanges();
            listBoxCarro.DataSource = null;
            CarregarDadosCarros();


            listBoxServico.SelectedItem = novoCarro;
        }

        private void buttonAdicionarServico_Click(object sender, EventArgs e)
        {

            if (listBoxCarro.SelectedIndex <= -1)
                return;

            Cliente clienteSelecionado = (Cliente)listBoxClientes.SelectedItem;
            Carro carroSelecionado = (Carro)listBoxCarro.SelectedItem;

            string tipoServico = comboBoxServico.Text;
            Servico novoServico = new Servico(tipoServico);

            carroSelecionado.Servico.Add(novoServico);

            listBoxServico.DataSource = null;
            listBoxServico.DataSource = carroSelecionado.Servico;

            comboBoxServico.Text = "";
        }

        private void listBoxCarro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carro carroSelecionado = (Carro)listBoxCarro.SelectedItem;

            //if (carroSelecionado != null)
            //{
            //    listBoxServico.DataSource = carroSelecionado.Servico;
            //    listBoxReparacao.DataSource = null;
            //    string marcaCarro = carroSelecionado.devolveMarca();
            //    string modeloCarro = carroSelecionado.devolveModelo();
            //    string matricula = carroSelecionado.devolveMatricula();
            //    string combustivel = carroSelecionado.Combustivel;

            //    labelMarcaCarro.Text = marcaCarro;
            //    labelModeloCarro.Text = modeloCarro;
            //    labelMatricula.Text = matricula;
            //    labelCombustivel.Text = combustivel;
            //}
        }

        private void listBoxServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Servico servicoSelecionado = (Servico)listBoxServico.SelectedItem;

            //if (servicoSelecionado != null)
            //{
            //    listBoxReparacao.DataSource = null;
            //    listBoxReparacao.DataSource = servicoSelecionado.Parcelas;
            //}
        }

        private void buttonAdicionarReparacao_Click(object sender, EventArgs e)
        {
            //if (listBoxServico.SelectedIndex == -1)
            //    return;

            //Cliente clienteSelecionado = (Cliente)listBoxClientes.SelectedItem;
            //Carro carroSelecionado = (Carro)listBoxCarro.SelectedItem;
            //Servico servicoSelecionado = (Servico)listBoxServico.SelectedItem;

            //Decimal valorAdicionar = 0;
            //try
            //{
            //    valorAdicionar = Decimal.Parse(textBoxValorReparacao.Text);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("UPS!!! Introduza valores numericos");
            //}
            //servicoSelecionado.Parcelas.Add(new Parcelas(textBoxDescricaoReparacao.Text, valorAdicionar));

            ////LISTBOXREPARAÇAO
            //listBoxReparacao.DataSource = null;
            //listBoxReparacao.DataSource = servicoSelecionado.Parcelas;

            ////LISTBOXSERVIÇO
            //listBoxServico.DataSource = null;
            //listBoxServico.DataSource = carroSelecionado.Servico;


            //listBoxServico.SelectedItem = servicoSelecionado;

            //textBoxDescricaoReparacao.Text = "";
            //textBoxValorReparacao.Text = "";
        }
        private void CarregarDadosClientes()
        {
            listBoxClientes.DataSource = minhaOficina.Clientes.ToList<Cliente>();
        }
        private void CarregarDadosCarros()
        {
            listBoxCarro.DataSource = minhaOficina.Carros.ToList<Carro>();
        }
    }
}
