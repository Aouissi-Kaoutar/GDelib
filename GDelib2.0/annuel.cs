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
    public partial class annuel : Form
    {
        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");

        string clas;
        string libele;
        public annuel(string clas, string libele)
        {
            InitializeComponent();

            this.clas = clas;
            this.libele = libele;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PV_Load(object sender, EventArgs e)
        {
           // label1.Text = libele;


            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            String query = " SELECT  nom ,prenom  , avg( note)as Moyenne_Genaral from notes ";


            conX.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = conX;
            command.CommandText = query;
            SqlDataReader d = command.ExecuteReader();

         
            DataTable t = new DataTable();
            t.Load(d);
            //  dataGridView3.DataSource = null;
            dataGridView1.DataSource = t;
            
        
            
            for (int i = 0; d.Read(); i++)
            {
                dataGridView1.Rows.Add();

                dataGridView1.Rows[i].Cells["id_eleve"].Value = d["id_eleve"];

                dataGridView1.Rows[i].Cells["nom"].Value = d["nom"];

                dataGridView1.Rows[i].Cells["prenom"].Value = d["prenom"];

               

                dataGridView1.Rows[i].Cells["resulta"].Value = d["note"];

            }



            conX.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        


        


        
    }
}
