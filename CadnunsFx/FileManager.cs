using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;


namespace CadnunsDimir.Libs
{
    public class GerenArquivos
    {
        public static DataTable listaArquivosFake(String path, String extensao)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("link", Type.GetType("System.String"));
            tabela.Columns.Add("Titulo", Type.GetType("System.String"));
            DataRow newRow = tabela.NewRow();

            // Set values in the columns:
            newRow["link"] = "NewCompanyID";
            newRow["Titulo"] = "NewCompanyName";

            // Add the row to the rows collection.
            tabela.Rows.Add(newRow);
            //-------------------------------------
            DataRow newRow2 = tabela.NewRow();

            // Set values in the columns:
            newRow2["link"] = "NewCompanyID";
            newRow2["Titulo"] = "NewCompanyName";

            // Add the row to the rows collection.
            tabela.Rows.Add(newRow2);

            return tabela;

        }

        public static DataTable listaArquivos(String path, String extensao)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("link", Type.GetType("System.String"));
            tabela.Columns.Add("Titulo", Type.GetType("System.String"));
            //DataRow newRow = tabela.NewRow();

            DirectoryInfo diretorio = new DirectoryInfo(path);
            //a extesão do arquivos deve ser algo assim "*.*"
            //por exemplo páginas : "*.aspx"
            FileInfo[] Arquivos = diretorio.GetFiles(extensao);
            foreach (FileInfo fileinfo in Arquivos)
            {
                DataRow newRow = tabela.NewRow();
                newRow["link"] = "/"+fileinfo.Name;
                newRow["Titulo"] = fileinfo.Name.Split('.')[0];
                tabela.Rows.Add(newRow);
            }

            return tabela;
        }
    }
}
