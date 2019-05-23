using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GDelib2._0
{
    public partial class collecteNotes : UserControl
    {

        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        public string semestre;
        public string clas;
        public string ElemPDG;


        public OpenFileDialog ofd;
        public collecteNotes()
        {
            InitializeComponent();
            comboBox2.Items.Add("GI3");
            comboBox2.Items.Add("GI4");
            comboBox2.Items.Add("GI5");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;


            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            semestre = "1";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            semestre = "2";
        }

        private void f()
        {
            con.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = con;

            String query = "SELECT * FROM  ElementPDG WHERE clas='" + comboBox5.SelectedItem.ToString() + "' and semestre='" + semestre + "'";

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();

            comboBox1.Items.Clear();

            for (int i = 0; d.Read(); i++)
            {
                comboBox6.Items.Add(d["nom_elemPDG"]);
            }
            con.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            clas = comboBox5.SelectedItem.ToString();
            f();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 c = new Form2(clas, ElemPDG, semestre, ofd);
                 c.Show();
               
            }
            catch (System.NullReferenceException eee)
            {
                MessageBox.Show("manque un champ\n \n \n" + eee.Message);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElemPDG  = comboBox6.SelectedItem.ToString();
        }
    }
}
