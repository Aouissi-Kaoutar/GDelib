using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace GDelib2._0
{
    public partial class InsrNote : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");

        public string ss;

        public InsrNote()
        {
            InitializeComponent();
        }

        public InsrNote(string s)
        {
            InitializeComponent();
            this.ss = s;
        }

        private void InsrNote_Load(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = con;
            //String query = "SELECT (id_eleve,nom,prenom,claS) FROM  deleve WHERE claS=\"" + ss + "\"";

            String query = "SELECT * FROM  Eleves WHERE claS='" + ss + "'";

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();

            for (int i = 0; d.Read(); i++)
            {
                dataGridView1.Rows.Add();

                dataGridView1.Rows[i].Cells["id_eleve"].Value = d["id_eleve"];

                dataGridView1.Rows[i].Cells["nom"].Value = d["nom"];

                dataGridView1.Rows[i].Cells["prenom"].Value = d["prenom"];

                dataGridView1.Rows[i].Cells["claS"].Value = d["claS"];

                //  dataGridView1.Rows[i].Cells["id_eleve"].Value = ;

            }
            con.Close();




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    String query = "INSERT INTO dbo.note (id_eleve,nom,prenom,claS,nomElemPeda,note) VALUES (@id_eleve,@nom,@prenom,@claS,@nomElemPeda,@note)";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@id_eleve", dataGridView1.Rows[i].Cells[0].Value);
                    command.Parameters.AddWithValue("@nom", dataGridView1.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@prenom", dataGridView1.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@claS", dataGridView1.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@nomElemPeda", dataGridView1.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@note", dataGridView1.Rows[i].Cells[5].Value);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
                catch (System.Data.SqlClient.SqlException expe)
                {
                    MessageBox.Show("une valeur id_eleve est deja inserer verifier votre Doc  \n \n \n \n" + expe.Message);
                }

            }

        }
    }
}
