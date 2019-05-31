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
    public partial class Diplome : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        List<string> s;
        int c = 0;
        string prenom = "";

        public Diplome()
        {
            InitializeComponent();
        }

        private void Diplome_Load(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = con;

            String query = "SELECT * FROM  notes WHERE clas='GI-5' and diplome='diplome'";

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();
            s = new List<string>();
            for (int i = 0; d.Read(); i++)
            {
                s.Add(d["id_eleve"].ToString());
                comboBox1.Items.Add(d["prenom"] + " " + d["nom"]); 
            }
            con.Close();

            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedItem.ToString();

          con.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = con;
            string n= comboBox1.SelectedItem.ToString();

            String query = "SELECT * FROM  Eleves where id_eleve='" + s[comboBox1.SelectedIndex] + "'";

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();

           

            for (int i = 0; d.Read(); i++)
            {
                label4.Text = d["date_naissance"].ToString();
                label3.Text = d["id_eleve"].ToString();
                label5.Text= d["nationalite"].ToString();
            }
            con.Close();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
