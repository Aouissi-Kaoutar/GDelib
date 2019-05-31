using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {/*
            Bitmap bm = new Bitmap(this.panel1.Width, this.panel1.Height);
            panel1.DrawToBitmap(bm, new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));
            e.Graphics.DrawImage(bm, 0, 0);*/

          

        }

        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap image = new Bitmap(panel1.Width, panel1.Height, panel1.CreateGraphics());
            panel1.DrawToBitmap(image, new Rectangle(0, 0, panel1.Width, panel1.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)image.Height / (float)image.Width);
            e.Graphics.DrawImage(image, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
        }

        private void button3_Click(object sender, EventArgs e)
        {/*
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
            */
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            PrintDialog pdi = new PrintDialog();
            pdi.Document = doc;
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
                doc.Print();
            }
            else
            {
                MessageBox.Show("User cancelled the print job");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
