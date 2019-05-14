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

        public string clas;
        public string semes;
        public string elemP;
        public string miS;
        public InsrNote()
        {
            InitializeComponent();
        }

        public InsrNote(string s,string c,string k)
        {
            InitializeComponent();
            this.clas = s;
            this.semes = c;
            this.elemP = k;
        }

        private void InsrNote_Load(object sender, EventArgs e)
        {
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

                dataGridView1.Rows[i].Cells["nomElementPeda"].Value = elemP;

            }



            con.Close();




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            String query;
            con.Open();
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    /*string query = "UPDATE dbo.notes SET" +
                        " id_eleve = @id_eleve," +
                        " nom = @nom," +
                        "prenom = @prenom," +
                        "claS = @claS, " +
                        " nomElemPeda= @nomElemPeda," +
                        "note = @note," +
                        " WHERE id_eleve = @id_eleve";        
                      */
                     query = "INSERT INTO  dbo.notes" +
                        "(id_eleve,nom,prenom,claS,miS,nomElemPeda,note) " +
                        "VALUES (@id_eleve,@nom,@prenom,@claS,@miS,@nomElemPeda,@note)";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@id_eleve", dataGridView1.Rows[i].Cells[0].Value);
                    command.Parameters.AddWithValue("@nom", dataGridView1.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@prenom", dataGridView1.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@claS", dataGridView1.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@miS", miS);
                    command.Parameters.AddWithValue("@nomElemPeda", dataGridView1.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@note", dataGridView1.Rows[i].Cells[5].Value);

                    command.ExecuteNonQuery();
                    
                }
            }
           
            finally
            {
                con.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.miS = "1";
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            this.miS = "2";
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
