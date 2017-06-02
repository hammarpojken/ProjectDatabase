using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace WindowsFormsApplication1
{
    class DatabaseHandler
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private string conn = "Server=127.0.0.1;Port=5432;Database=project;User Id=postgres;Password=backstab1870;";

        public DatabaseHandler()
        {


        }
        public DataSet selectDB(string sql)
        {
            DataSet ds = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();

            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            return ds;
        }
        public void updateDB ()
        {

        }

    }
}
