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

namespace GDelib2._0
{
    public partial class user : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");

        public user()
        {
            InitializeComponent();
            
        }
        public user(string s)
        {
            InitializeComponent();

            label4.Text = s;

            ListeEtd.Hide();
            acceuil.Show();
        }


        private void user_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

            InsrNote c =new InsrNote(button1.Text);
            c.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            acceuil.Show();
            ListeEtd.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsrNote c = new InsrNote(button3.Text);
            c.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            InsrNote c = new InsrNote(button4.Text);
            c.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string s;
            SqlCommand command = new SqlCommand();
            command.Connection = con;
          
            String query = "SELECT * FROM  ElementPDG";

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();
            s = d["nomElemPeda"].ToString();
            for (int i = 0; d.Read(); i++)
            {
                comboBox1.Items.Add(s);
                
            }
            con.Close();



        }
    }
}
