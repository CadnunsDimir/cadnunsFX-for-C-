using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;


namespace CadnunsDimir.Libs
{
    public class MySqlConn 
    {
        String ip;
        String login;
        String senha;
        String db;
        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

        public MySqlConn(String ip, String login, String senha, String db)
        {
            this.ip = ip;
            this.login = login;
            this.senha = senha;
            this.db = db;
        }
        public DataTable tabela(String query)
        {

                //string connectionString = "server=192.168.0.99;uid=root;pwd=falconfx;database=noticias";
                //string connectionString = "Database='cadastro';Data Source='192.168.0.99';User Id='root';Password='falconfx'; pooling=false";
                string connectionString = "Database='" + db + "';Data Source='" + ip + "';User Id='" + login + "';Password='" + senha + "'; pooling=false";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;

        }

        public void comando(String query)
        {
            String connectionString = "Database='" + db + "';Data Source='" + ip + "';User Id='" + login + "';Password='" + senha + "'; pooling=false";

            mConn = new MySqlConnection(connectionString);
            mConn.Open();

            //Query SQL
            MySqlCommand command = new MySqlCommand(query, mConn);

            //Executa a Query SQL
            command.ExecuteNonQuery();

            // Fecha a conexão
            mConn.Close();
 
        }
    }
}