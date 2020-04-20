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

                List<Produto> produtoList = new List<Produto>();
                produtoList.Add(produto);


                ManipuladorXML.SerializationXML<Produto>(produtoList);
                //dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Incluir " + ex);
            }
        }
    }
}
