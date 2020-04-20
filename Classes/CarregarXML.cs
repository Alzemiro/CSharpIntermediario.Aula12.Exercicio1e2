using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Exercicio1Aula12.Classes
{
    public class CarregarXML
    {
        public static string LoadXML()
        {
            string endereco = string.Empty;
            try
            {
               endereco = ConfigurationManager.AppSettings["EnderecoXML"].ToString();
              
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao carregador o documento: " + ex);
            }
            return endereco;
        }

    }
}
