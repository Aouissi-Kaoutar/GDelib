using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Collections.Generic;
//using Excel = Microsoft.Office.Interop.Excel;


namespace GDelib2._0
{
    public partial class user : Form
    {
        public OpenFileDialog ofd;
        /* ExcelFile ef = new ExcelFile();

         // Adds new worksheet to excelFile.
         ExcelWorksheet ws = ef.Worksheets.Add("New worksheet");

         // Sets the value of the cell "A1".
         ws.Cells["A1"].Value = "Hello world!";

                 // Saves the excel file.
                 ef.SaveXls(@"C:\Users\...\{id.xls");

              con.Open();

             SqlCommand command = new SqlCommand();
         command.Connection = con;

             //String query = "SELECT * FROM  Eleves WHERE claS='" + clas+ "'";
             String query = "SELECT * FROM  Eleves WHERE claS='GI3'";

         command.CommandText = query;

             SqlDataReader d = command.ExecuteReader();

             for (int i = 0; d.Read(); i++)
             {
                 dataGridView1.Rows.Add();

                 dataGridView1.Rows[i].Cells["id_eleve"].Value = d["id_eleve"];

                 dataGridView1.Rows[i].Cells["nom"].Value = d["nom"];

                 dataGridView1.Rows[i].Cells["prenom"].Value = d["prenom"];

                 dataGridView1.Rows[i].Cells["filier"].Value = d["claS"];

                 dataGridView1.Rows[i].Cells["nomElemPeda"].Value = elemP;

             }*/



        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        string semestre;
        string clas;

        public user()
        {
            InitializeComponent();
             button1.BackColor = Color.Transparent;
             button3.BackColor = Color.Transparent;
             button4.BackColor = Color.Transparent;

             radioButton2.BackColor = Color.Transparent;
             radioButton1.BackColor = Color.Transparent;

             label1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            button12.BackColor = Color.Transparent;
            button13.BackColor = Color.Transparent;
            button14.BackColor = Color.Transparent;

            ListeEtd.Hide();
            acceuil.Show();

            comboBox2.Items.Add("GI3");
            comboBox2.Items.Add("GI4");
            comboBox2.Items.Add("GI5");
        }
       


        private void user_Load(object sender, EventArgs e)
        {



        }

        private void button10_Click(object sender, EventArgs e)
        {

            ListeEtd.Show();
            acceuil.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            acceuil.Show();
            ListeEtd.Hide();
        }
        
private void button1_Click(object sender, EventArgs e)
        {
            
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;


            button1.BackColor = Color.FromArgb(44, 47, 51);
           
            clas = button1.Text;

            f();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(44, 47, 51);
            button1.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;


            clas = button3.Text;

            f();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            button4.BackColor = Color.FromArgb(44, 47, 51);
            button1.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            clas = button4.Text;

            f();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            semestre = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            semestre = "2";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
             try
             {
                 Form2 c = new Form2(comboBox2.SelectedItem.ToString(), semestre, comboBox1.SelectedItem.ToString(), ofd);
                 c.Show();
             }
             catch(System.NullReferenceException eee) {
                  MessageBox.Show("manque un champ\n \n \n"+eee.Message);
             }
            

        }
        private void f()
        {
            con.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = con;
          
            String query = "SELECT * FROM  ElementPDG WHERE filier='" + comboBox2.SelectedItem.ToString() + "' and semester='" + semestre + "'";

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();

            comboBox1.Items.Clear();

            for (int i = 0; d.Read(); i++)
            {
                comboBox1.Items.Add(d["nomElemPeda"]);
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ListeEtd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            clas = comboBox2.SelectedItem.ToString();
            f();
        }

        private void fermerRoug(object sender, EventArgs e)
        {
            button11.BackColor = Color.Red   ;

        }

        private void button15_Click(object sender, EventArgs e)
        {
             ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;


            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
