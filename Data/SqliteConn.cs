using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CadnunsFx.Data.SQLite
{
    public class SqliteConn
    {
        /*
         * Esse método´precisa ser atualizado
         * não funciona
         * 
         * 
         */
        private string arquivo;
        //SQLiteConnection conn;
        
        public SqliteConn(string nomeArquivo, string tabela)
        {
            this.arquivo = nomeArquivo;
            if (!File.Exists(arquivo))
            {
                SQLiteConnection.CreateFile(arquivo);

            }
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + arquivo);

            
            comando(conn, "create database " + arquivo);
        }

        public void comando(SQLiteConnection conn, string query)
        {
            
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(string.Concat(query), conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
