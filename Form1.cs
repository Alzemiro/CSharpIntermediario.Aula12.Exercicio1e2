using Exercicio1Aula12.Classes;
using Exercicio1Aula12.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//1 - Um pequeno mercado está tentando organizar seus produtos.Você foi contratado para desenvolver um sistema simples que irá ajudá-los a gerenciar o estoque.

//A aplicação precisa armazenar as seguintes informações dos produtos:

//Nome dos produtos;
//Preço dos produtos;
//Quantidade dos produtos;
//A aplicação deverá ser criada com o Windows Forms e os dados salvos em um arquivo XML.Você também deverá se atentar também à arquitetura da aplicação, tentando seguir ao máximo a arquitetura sugerida durante o curso.

//2 – O mercado para quem você desenvolveu a aplicação do primeiro exercício, entrou em contato novamente e devido a lentidão do sistema, pediu que você desenvolva um recurso para importar os dados do XML para um banco de dados MySQL, e que altere a aplicação para utilizar apenas esse banco.


namespace Exercicio1Aula12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ManipuladorXML.DeserializationXML<Produto>("ArrayOfProdutos");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            ExibeProdutoPrecoQuantidade(true);

        }

        private void ExibeProdutoPrecoQuantidade(bool j)
        {
            txbPreco.Enabled = j;
            txbProduto.Enabled = j;
            txbQuantidade.Enabled = j;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ExibeProdutoPrecoQuantidade(false);
            txbPreco.Clear();
            txbQuantidade.Clear();
            txbProduto.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                Produto produto = new Produto()
                {
                    Id = 3,
                    Descricao = txbProduto.Text,
                    Preco = Convert.ToDecimal(txbPreco.Text),
                    Quantidade = Convert.ToInt32(txbQuantidade.Text)
                };           


                ManipuladorXML.SerializationXML<Produto>(produto, "ArrayOfProdutos");
                dataGridView1.DataSource = ManipuladorXML.DeserializationXML<Produto>("ArrayOfProdutos");
                dataGridView1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Incluir " + ex);
            }
        }
    }
}
