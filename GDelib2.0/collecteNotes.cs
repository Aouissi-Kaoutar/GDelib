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
using System.IO;

namespace GDelib2._0
{
    public partial class collecteNotes : UserControl
    {
        //OUISSAL CONNEX
        //    public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        //KAWTAR CONX
        //public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");

        /*
                static string path = Path.GetFullPath(Environment.CurrentDirectory);
                static string dataBseName = "GDelibe2.mdf";
                public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + dataBseName + "; Integrated Security=True;Connect Timeout=30");
        */
        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Desktop\kawtar\aaaaa\GDelib2.0-2019\GDelib2.0\Database1.mdf;Integrated Security=True");

        public string semestre=null;
        public string clas;
        public string ElemPDG;
        public string session;

        public OpenFileDialog ofd;
        public collecteNotes()
        {
            InitializeComponent();
            
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

            String query = "SELECT nom_elemPDG FROM  ElementPDG WHERE clas='"+ comboBox5.SelectedItem.ToString() + "' and semestre='"+semestre+"'" ;

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();

            comboBox6.Items.Clear();

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
                Form2 c = new Form2(clas, ElemPDG, semestre,session, ofd);
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

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            session = "ord";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            session = "rat";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pvRAT pv = new pvRAT(comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), "Liste des rattrapage pour les " + comboBox2.SelectedItem.ToString());
                pv.Show();
            }
            catch(System.NullReferenceException exx) {
                MessageBox.Show("Monque un champ");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pvSEM pv = new pvSEM(comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), "Liste des resultet  semestrielle pour les " + comboBox2.SelectedItem.ToString());
                pv.Show();

            }
            catch (System.NullReferenceException exx)
            {
                MessageBox.Show("Monque un champ");
            }
        }

        private void ListeEtd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "GI-5") {
                    PvAnnuelleGI5 pv = new PvAnnuelleGI5(comboBox1.SelectedItem.ToString(), "Liste des resultet  annuelle pour les " + comboBox1.SelectedItem.ToString());
                    pv.Show();
                }
                else {
                    PVanuelle pv = new PVanuelle(comboBox1.SelectedItem.ToString(), "Liste des resultet  annuelle pour les " + comboBox1.SelectedItem.ToString());
                    pv.Show();
                }

            }
            catch (System.NullReferenceException exx)
            {
                MessageBox.Show("Monque un champ");
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Gray;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Gray;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Gray;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Gray;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
