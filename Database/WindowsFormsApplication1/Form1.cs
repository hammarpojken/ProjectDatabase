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
        private String studentSQL = "SELECT st.personnr AS Personnummer, st.fname AS Förnamn, st.lname AS Efternamn, st.adress AS Adress, st.postnr AS Postnummer, po.ort as Bostadsort, st.gy AS Gymnasiebehörighet, st.pr AS Programmering, st.ma AS Matematik, st.sv AS Svenska, st.en AS Engelska FROM student st JOIN postort po ON st.postnr = po.postnr";
        private String utbildningSQL = "SELECT * FROM utbildning";
        private String anstalldSQL = "SELECT * FROM anstalld";
        public Form1()
        {
           
            InitializeComponent();
        }
        // Det som sker när applicationen startas
        private void form1Load(object sender, EventArgs e)
        {
            dt = dbhandler.selectDB(studentSQL);
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
                dt = dbhandler.selectDB(utbildningSQL);
                dataGridView2.DataSource = dt;

            } else if (e.TabPageIndex.Equals(2))
            {
                dt = dbhandler.selectDB(anstalldSQL);
                dataGridView3.DataSource = dt;
            }
            else
            {
                dt = dbhandler.selectDB(studentSQL);
                dataGridView1.DataSource = dt;
            }
           
        }
        // Sök funktion för studenter
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(""))
            {
                dt = dbhandler.selectDB(studentSQL);
                dataGridView1.DataSource = dt;
            }
            dt = dbhandler.selectDB(studentSQL + " WHERE LOWER (fname) LIKE '" + this.textBox1.Text.ToLower() + "%' OR LOWER (lname) LIKE '" + this.textBox1.Text.ToLower() + "%'");
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
                dt = dbhandler.selectDB(studentSQL);
                dataGridView1.DataSource = dt;
            } else if (comboBox1.SelectedItem.Equals("Antagna"))
            {
                dt = dbhandler.selectDB("SELECT st.fname as Förnamn, st.lname AS Efternamn, sta.antagen as Antagen FROM student st JOIN status sta ON st.personnr= sta.studentid WHERE sta.antagen = TRUE");
                dataGridView1.DataSource = dt;
            }else if (comboBox1.SelectedItem.Equals("Klara"))
            {
                dt = dbhandler.selectDB("SELECT st.fname as Förnamn, st.lname AS Efternamn, sta.klar as Klar FROM student st JOIN status sta ON st.personnr= sta.studentid WHERE sta.klar = TRUE");
                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new StudentPopup().Show();
        }
    }
}
