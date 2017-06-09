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
        private DataTable dtstudent = new DataTable();
        private DataTable dtbetyg = new DataTable();
        private string studentid;
        
        public StudentPopup(String studentid)
        {
            this.studentid = studentid;
            
            InitializeComponent();
            this.button1.Show();
            Form2_Load();
        }
        public StudentPopup()
        {
           
            InitializeComponent();
            button2.Show();
            
        }
        // laddar in all data om studenten
        private void Form2_Load()
        {
            
            dtstudent = dbhandler.selectDB("SELECT * FROM student WHERE personnr = " + studentid).Copy();
           
                this.Text = dtstudent.Rows[0].Field<string>(1) + " " + dtstudent.Rows[0].Field<string>(2);
                textBox1.Text = dtstudent.Rows[0][1].ToString();
                textBox2.Text = dtstudent.Rows[0].Field<string>(2);
                textBox3.Text = dtstudent.Rows[0].Field<Int64>(0).ToString();
                textBox4.Text = dtstudent.Rows[0].Field<string>(3);
                textBox5.Text = dtstudent.Rows[0].Field<string>(5);
                textBox6.Text = dtstudent.Rows[0].Field<int>(4).ToString();
                textBox7.Text = dtstudent.Rows[0].Field<string>(6).ToString();
                textBox8.Text = dtstudent.Rows[0].Field<string>(7).ToString();
                textBox9.Text = dtstudent.Rows[0].Field<string>(8).ToString();
                textBox10.Text = dtstudent.Rows[0].Field<string>(9).ToString();

                if (dtstudent.Rows[0].IsNull(10))
                {
                    textBox11.Text = "Inget angivet";
                }
                else if (dtstudent.Rows[0].Field<Boolean>(10).ToString().Equals("False"))
                {
                    textBox11.Text = "Nej";
                }
                else
                {
                    textBox11.Text = "Ja";

                }
                dtbetyg = dbhandler.selectDB("SELECT kurs.namn, betyg.betyg FROM kurs JOIN betyg ON kurs.kursid = betyg.kurs WHERE betyg.student =" + studentid);
                this.dataGridView1.DataSource = dtbetyg;
            

            
        }
        // funktion för att uppdatera ny student
        private void button1_Click(object sender, EventArgs e)
        {
            dtstudent.Rows[0][0] = Int64.Parse(textBox3.Text);
            dtstudent.Rows[0][1] = textBox1.Text.ToString();
            dtstudent.Rows[0]["lname"] = textBox2.Text.ToString();
            dtstudent.Rows[0]["adress"] = textBox4.Text.ToString();
            dtstudent.Rows[0]["postnr"] = Int32.Parse(textBox6.Text);
            dtstudent.Rows[0]["ort"] = textBox5.Text.ToString();
            dtstudent.Rows[0]["pr"] = textBox7.Text.ToString();
            dtstudent.Rows[0]["ma"] = textBox8.Text.ToString();
            dtstudent.Rows[0]["sv"] = textBox9.Text.ToString();
            dtstudent.Rows[0]["en"] = textBox10.Text.ToString();
            dtstudent.Rows[0]["gy"] = Boolean.Parse(textBox11.Text);

            dbhandler.updateStudent(dtstudent, Int64.Parse(studentid));
            this.Close();
        }
        // för att skapa ny student
        private void button2_Click(object sender, EventArgs e)
        {
            dtstudent = dbhandler.selectDB("SELECT * FROM student");
            dtstudent.Rows[0][0] = Int64.Parse(textBox3.Text);
            dtstudent.Rows[0][1] = textBox1.Text.ToString();
            dtstudent.Rows[0]["lname"] = textBox2.Text.ToString();
            dtstudent.Rows[0]["adress"] = textBox4.Text.ToString();
            dtstudent.Rows[0]["postnr"] = Int32.Parse(textBox6.Text);
            dtstudent.Rows[0]["ort"] = textBox5.Text.ToString();
            dtstudent.Rows[0]["pr"] = textBox7.Text.ToString();
            dtstudent.Rows[0]["ma"] = textBox8.Text.ToString();
            dtstudent.Rows[0]["sv"] = textBox9.Text.ToString();
            dtstudent.Rows[0]["en"] = textBox10.Text.ToString();
            dtstudent.Rows[0]["gy"] = Boolean.Parse(textBox11.Text);

            dbhandler.newStudentRow(dtstudent);
            this.Close();
        }
    }
}
