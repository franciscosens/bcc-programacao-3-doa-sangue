using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DTO.Infraestrutura
{
    class Conexao
    {
        private SqlConnection sqlConnection;

        public SqlCommand GetCommand()
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LSens\Documents\DbDoaSangue.mdf;Integrated Security=True;Connect Timeout=30");
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            return command;
        }

        public void Close()
        {
            sqlConnection.Close();
        }
    }
}