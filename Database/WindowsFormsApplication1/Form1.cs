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
    public partial class Form1 : Form
    {
        private DatabaseHandler dbhandler = new DatabaseHandler();
        private DataTable dt = new DataTable();
        public Form1()
        {
           
            InitializeComponent();
        }

        private void form1Load(object sender, EventArgs e)
        {
            dt = dbhandler.selectDB("SELECT * FROM student");
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tab_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tab_Selected(object sender, TabControlEventArgs e)
        {
            if(e.TabPageIndex.Equals(1))
            {
                dt = dbhandler.selectDB("SELECT * FROM utbildning");
                dataGridView2.DataSource = dt;

            } else if (e.TabPageIndex.Equals(2))
            {
                dt = dbhandler.selectDB("SELECT * FROM anstalld");
                dataGridView3.DataSource = dt;
            }
            else
            {
                dt = dbhandler.selectDB("SELECT * FROM student");
                dataGridView1.DataSource = dt;
            }
           
        }
    }
}
