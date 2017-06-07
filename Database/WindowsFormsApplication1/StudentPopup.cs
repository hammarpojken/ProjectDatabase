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
        private string studentid;
        
        public StudentPopup(String studentid)
        {
            this.studentid = studentid;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dt = dbhandler.selectDB("SELECT * FROM student WHERE personnr = " + studentid);
           
            this.Text = dt.Rows[0].Field<string>(1) + " " + dt.Rows[0].Field<string>(2);
            textBox1.Text = dt.Rows[0].Field<string>(1);
            textBox2.Text = dt.Rows[0].Field<string>(2);
            textBox3.Text = dt.Rows[0].Field<Int64>(0).ToString();
            textBox4.Text = dt.Rows[0].Field<string>(3);
            textBox5.Text = dt.Rows[0].Field<string>(5);

        }

   
    }
}
