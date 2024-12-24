using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Repository
{
    public class Repository
    {
        public SqlConnection conexao { get; set; }

        public Repository()
        {
            this.conexao = new SqlConnection("Configuration.Conexao");
        }
    }
}
