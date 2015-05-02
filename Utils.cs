using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CadnunsFx
{
    public static class Utils
    {
        public static void MostraErro(String erro)
        {
            MessageBox.Show("Descrição :"+erro, Application.ProductName+" - Ocorreu um erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public static void MostraSucesso(String Operacao)
        {
            MessageBox.Show(Operacao+": essa operação foi realizada com sucesso!!", Application.ProductName + " - Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
