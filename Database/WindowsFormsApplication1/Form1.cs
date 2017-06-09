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
        // Det som sker när applicationen startas
        private void form1Load(object sender, EventArgs e)
        {
            dt = dbhandler.selectDB("SELECT * FROM student");
            dataGridView1.DataSource = dt;
        }

  

        private void tab_TabIndexChanged(object sender, EventArgs e)
        {
            
        }
         //Fyller tabbarna med rätt information när man växlar 
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
        // Sök funktion för studenter
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(""))
            {
                dt = dbhandler.selectDB("SELECT * FROM student");
                dataGridView1.DataSource = dt;
            }
            dt = dbhandler.selectDB("SELECT * FROM student WHERE LOWER (fname) LIKE '" + this.textBox1.Text.ToLower() + "%' OR LOWER (lname) LIKE '" + this.textBox1.Text.ToLower() + "%'");
            dataGridView1.DataSource = dt;

        }
        // popup funktion för specifik student
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string studentid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            new StudentPopup(studentid).Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.Equals("") || comboBox1.SelectedItem.Equals(null))
            {
                dt = dbhandler.selectDB("SELECT * FROM student");
                dataGridView1.DataSource = dt;
            } else if (comboBox1.SelectedItem.Equals("Antagna"))
            {
                dt = dbhandler.selectDB("SELECT st.fname, st.lname, sta.antagen FROM student st JOIN status sta ON st.personnr= sta.studentid WHERE sta.antagen = TRUE");
                dataGridView1.DataSource = dt;
            }else if (comboBox1.SelectedItem.Equals("Klara"))
            {
                dt = dbhandler.selectDB("SELECT st.fname, st.lname, sta.klar FROM student st JOIN status sta ON st.personnr= sta.studentid WHERE sta.klar = TRUE");
                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new StudentPopup().Show();
        }
    }
}
