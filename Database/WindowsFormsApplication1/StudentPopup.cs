using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class StudentPopup : Form
    {
        private DatabaseHandler dbhandler = new DatabaseHandler();
        private DataTable dt = new DataTable();
        private DataTable dtbetyg = new DataTable();
        private string studentid;
        
        public StudentPopup(String studentid)
        {
            this.studentid = studentid;
            InitializeComponent();
        }
        // laddar in all data om studenten
        private void Form2_Load(object sender, EventArgs e)
        {
            dt = dbhandler.selectDB("SELECT * FROM student WHERE personnr = " + studentid);
           
            this.Text = dt.Rows[0].Field<string>(1) + " " + dt.Rows[0].Field<string>(2);
            textBox1.Text = dt.Rows[0].Field<string>(1);
            textBox2.Text = dt.Rows[0].Field<string>(2);
            textBox3.Text = dt.Rows[0].Field<Int64>(0).ToString();
            textBox4.Text = dt.Rows[0].Field<string>(3);
            textBox5.Text = dt.Rows[0].Field<string>(5);
            textBox6.Text = dt.Rows[0].Field<int>(4).ToString();
            textBox7.Text = dt.Rows[0].Field<string>(6).ToString();
            textBox8.Text = dt.Rows[0].Field<string>(7).ToString();
            textBox9.Text = dt.Rows[0].Field<string>(8).ToString();
            textBox10.Text = dt.Rows[0].Field<string>(9).ToString();
            if (dt.Rows[0].IsNull(10)) 
            {
                textBox11.Text = "Inget angivet";
            } else if (dt.Rows[0].Field<Boolean>(10).ToString().Equals("False")) {
                textBox11.Text = "Nej";
            } else
            {
                textBox11.Text = "Ja";
                
            }
            dtbetyg = dbhandler.selectDB("SELECT kurs.namn, betyg.betyg FROM kurs JOIN betyg ON kurs.kursid = betyg.kurs WHERE betyg.student =" + studentid);
            this.dataGridView1.DataSource = dtbetyg;
        }


    }
}
