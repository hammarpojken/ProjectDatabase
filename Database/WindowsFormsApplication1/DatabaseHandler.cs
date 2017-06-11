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
        public void newStudentRow (DataTable dt)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            // tog bort ort
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO student VALUES (:personnr, :fname, :lname, :adress, :postnr, :pr,:ma,:sv,:en,:gy)", conn);

            try
            {
                command.Parameters.Add(new NpgsqlParameter("personnr", NpgsqlTypes.NpgsqlDbType.Bigint));
                command.Parameters.Add(new NpgsqlParameter("fname", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("lname", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("adress", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("postnr", NpgsqlTypes.NpgsqlDbType.Integer));
               // command.Parameters.Add(new NpgsqlParameter("ort", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("pr", NpgsqlTypes.NpgsqlDbType.Char));
                command.Parameters.Add(new NpgsqlParameter("ma", NpgsqlTypes.NpgsqlDbType.Char));
                command.Parameters.Add(new NpgsqlParameter("sv", NpgsqlTypes.NpgsqlDbType.Char));
                command.Parameters.Add(new NpgsqlParameter("en", NpgsqlTypes.NpgsqlDbType.Char));
                command.Parameters.Add(new NpgsqlParameter("gy", NpgsqlTypes.NpgsqlDbType.Boolean));
                command.Parameters[0].Value = dt.Rows[0][0];
                command.Parameters[1].Value = dt.Rows[0][1];
                command.Parameters[2].Value = dt.Rows[0][2];
                command.Parameters[3].Value = dt.Rows[0][3];
                command.Parameters[4].Value = dt.Rows[0][4];
               // command.Parameters[5].Value = dt.Rows[0][10];
                command.Parameters[5].Value = dt.Rows[0][5];
                command.Parameters[6].Value = dt.Rows[0][6];
                command.Parameters[7].Value = dt.Rows[0][7];
                command.Parameters[8].Value = dt.Rows[0][8];
                command.Parameters[9].Value = dt.Rows[0][9];
                command.ExecuteNonQuery();
                conn.Close(); 
            } catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
           

        }
        public void updateStudent(DataTable dtstudent, Int64 id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("update student set \"personnr\" = :personnr, \"fname\" = :fname, \"lname\" = :lname, \"adress\" = :adress," +
               " \"postnr\" = :postnr, \"pr\" = :pr," +
               " \"ma\" = :ma, \"sv\" = :sv, \"en\" = :en, \"gy\" = :gy Where \"personnr\" = " + id, conn);
            try
            {
                cmd.Parameters.Add(new NpgsqlParameter("personnr", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("fname", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("lname", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("adress", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("postnr", NpgsqlTypes.NpgsqlDbType.Integer));
                //cmd.Parameters.Add(new NpgsqlParameter("ort", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("pr", NpgsqlTypes.NpgsqlDbType.Char));
                cmd.Parameters.Add(new NpgsqlParameter("ma", NpgsqlTypes.NpgsqlDbType.Char));
                cmd.Parameters.Add(new NpgsqlParameter("sv", NpgsqlTypes.NpgsqlDbType.Char));
                cmd.Parameters.Add(new NpgsqlParameter("en", NpgsqlTypes.NpgsqlDbType.Char));
                cmd.Parameters.Add(new NpgsqlParameter("gy", NpgsqlTypes.NpgsqlDbType.Boolean));
                cmd.Parameters[0].Value = dtstudent.Rows[0][0];
                cmd.Parameters[1].Value = dtstudent.Rows[0][1];
                cmd.Parameters[2].Value = dtstudent.Rows[0][2];
                cmd.Parameters[3].Value = dtstudent.Rows[0][3];
                cmd.Parameters[4].Value = dtstudent.Rows[0][4];
                //cmd.Parameters[5].Value = dtstudent.Rows[0][5];
                cmd.Parameters[5].Value = dtstudent.Rows[0][5];
                cmd.Parameters[6].Value = dtstudent.Rows[0][6];
                cmd.Parameters[7].Value = dtstudent.Rows[0][7];
                cmd.Parameters[8].Value = dtstudent.Rows[0][8];
                cmd.Parameters[9].Value = dtstudent.Rows[0][9];
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

    }

}
