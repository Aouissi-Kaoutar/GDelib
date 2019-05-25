using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDelib2._0
{
    public partial class Form2 : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");

        public string clas;
        public string semes;
        public string elemP;
        public string miS;
        public string session;
        public OpenFileDialog ofd;
        public float not;
        public Form2()
        {
            InitializeComponent();
        }


        public Form2( string cls, string elmPDG, string s,string session, OpenFileDialog ofd)
        {
            InitializeComponent();
            this.clas = cls;
           this.semes = s; 
           this.elemP = elmPDG;
            this.session = session;
            this.ofd = ofd;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                  if (session == "ord")
                    { 
                        String query = "INSERT INTO dbo.notes (id_eleve,nom,prenom,claS,semester,nomElemPeda,note,session,res) VALUES (@id_eleve,@nom,@prenom,@claS,@semester,@nomElemPeda,@note,@session,@res)";
                   
                        SqlCommand command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@id_eleve", dataGridView1.Rows[i].Cells[0].Value);
                        command.Parameters.AddWithValue("@nom", dataGridView1.Rows[i].Cells[1].Value);
                        command.Parameters.AddWithValue("@prenom", dataGridView1.Rows[i].Cells[2].Value);
                        command.Parameters.AddWithValue("@claS", clas);
                        command.Parameters.AddWithValue("@semester", semes);
                        command.Parameters.AddWithValue("@nomElemPeda",elemP);
                        command.Parameters.AddWithValue("@session", session);
                        command.Parameters.AddWithValue("@note", dataGridView1.Rows[i].Cells[3].Value);
                        not = float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        if (not != null || not < 20 || not > 0)
                        {
                            if (not < 12) { command.Parameters.AddWithValue("@res","rattrape"); }
                            else { command.Parameters.AddWithValue("@res", "valide"); }
                            try { 
                            con.Open();
                            command.ExecuteNonQuery();
                            }
                            catch(Exception exp){
                                MessageBox.Show(exp.Message);
                            }
                            finally { 
                            con.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("la note du"+ dataGridView1.Rows[i].Cells[1].Value.ToString()+"n'est pas dans la forme entandu");
                        }
                        
                   }
                  if (session == "rat")
                    {
                          string query = "UPDATE notes  SET note =@notr Where id_eleve =@id_eleve";

                        SqlCommand command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@id_eleve", dataGridView1.Rows[i].Cells[0].Value);
                        command.Parameters.AddWithValue("@nom", dataGridView1.Rows[i].Cells[1].Value);
                        command.Parameters.AddWithValue("@prenom", dataGridView1.Rows[i].Cells[2].Value);
                        command.Parameters.AddWithValue("@claS", clas);
                        command.Parameters.AddWithValue("@semester", semes);
                        command.Parameters.AddWithValue("@nomElemPeda", elemP);

                        command.Parameters.AddWithValue("@note", dataGridView1.Rows[i].Cells[3].Value);

                        not = float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        if (not != null || not < 20 || not > 0)
                        {
                            if (not < 12) { command.Parameters.AddWithValue("@res", "non valide"); }
                            else { command.Parameters.AddWithValue("@res", "valide"); }

                            try
                            {
                                con.Open();
                                command.ExecuteNonQuery();
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message);
                            }
                            finally
                            {
                                con.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("la note du" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "n'est pas dans la forme entandu");
                        }
                       
                    }








                }


                catch (System.Data.SqlClient.SqlException expe)
                {
                    MessageBox.Show("une valeur id_eleve est deja inserer verifier votre Doc  \n \n \n \n" + expe.Message);
                }
                finally { }

            }
            MessageBox.Show("enregistrement est bient efectuer pour les " +clas);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*  con.Open();

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

              }



              con.Close();*/

            string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ofd.FileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";

             OleDbConnection conn = new OleDbConnection(path);
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [" +"GI-3" + "$]", conn);
            DataTable dt = new DataTable();

            myDtAdapter.Fill(dt);
            dataGridView1.DataSource = dt;



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



        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
                    query = "Delete from  dbo.notes where id_eleve=@id_eleve";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@id_eleve", dataGridView1.Rows[i].Cells[0].Value);
                   
                    command.ExecuteNonQuery();

                }

                MessageBox.Show("la Supretion eSt b1 paC");

            }
           
            finally
            {
                con.Close();
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
