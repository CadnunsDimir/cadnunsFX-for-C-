using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace CadnunsFx.Data.LocalDB
{
    public class LocalDBConn
    {
        String connString = @"Data Source=|DataDirectory|\Database1.sdf";
        SqlCeConnection conexao;
        /// <summary>
        ///     Inicializa o Objeto LocalDBConn
        ///</summary>
        /// <param name="connString">A String de Conexão</param>
        public LocalDBConn(string connString)
        {
            this.connString = connString;
            conexao = new SqlCeConnection(connString);
        }

        public void comando(string query)
        {            
            conexao.Open();
            new SqlCeCommand(query, conexao).ExecuteNonQuery();
            conexao.Close();
        }

        public object retornaValoresUnicos(string query)
        {            
            conexao.Open();
            Object valor = new SqlCeCommand(query, conexao).ExecuteScalar(); ;
            conexao.Close();
            return valor;
        }
        
    }
}
