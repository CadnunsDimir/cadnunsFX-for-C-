using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;


namespace CadnunsFx.Data.MySql
{
    public class MySqlConn 
    {
        String ip;
        int porta = 3306;//nao usado ainda
        String login;
        String senha;
        String db;
        private MySqlConnection mConn;
        

        public MySqlConn(String ip, String login, String senha, String db)
        {
            this.ip = ip;
            this.login = login;
            this.senha = senha;
            this.db = db;
        }
                
        private MySqlCommand ConexaoBanco(String query)
        {
            //string connectionString = "server=192.168.0.99;uid=root;pwd=falconfx;database=noticias";
            //string connectionString = "Database='cadastro';Data Source='192.168.0.99';User Id='root';Password='falconfx'; pooling=false";
                
            String connectionString = "Database='" + db + "';Data Source='" + ip + "';User Id='" + login + "';Password='" + senha + "'; pooling=false";
            mConn = new MySqlConnection(connectionString);
            mConn.Open();                        
            return new MySqlCommand(query, mConn);

        }

        public DataTable tabela(String query)
        {
                MySqlCommand cmd = ConexaoBanco(query);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                mConn.Close();
                return dt;
        }

        public void comando(String query)
        {
            MySqlCommand command = ConexaoBanco(query);
            command.ExecuteNonQuery();
            mConn.Close();
        }

        public int totalRegistros(String tabela)
        {
            return ContarRegistros(tabela,null, null);
        }

        public int ContarRegistros(String tabela, String coluna,String valor)
        {
            String query = "SELECT COUNT(*) FROM "+tabela;
            query += !String.IsNullOrEmpty(coluna) || !String.IsNullOrEmpty(valor) ? " WHERE " + coluna + "=" + valor : "";
            MySqlCommand command = ConexaoBanco(query);

            //Executa a Query SQL
            int resultado = int.Parse(command.ExecuteScalar().ToString());

            // Fecha a conexão
            mConn.Close();
            return resultado;
        }
    }
}