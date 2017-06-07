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
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        public string connstring = "Server=127.0.0.1;Port=5432;Database=project;User Id=postgres;Password=backstab1870;";
        
        public DatabaseHandler()
        {



        }
        public DataTable selectDB(string sql)
        {
            
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();

            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
            return dt;
        }
        public void updateDB ()
        {

        }

    }
}
