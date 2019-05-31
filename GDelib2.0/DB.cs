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
    public partial class DB : Form
    {
        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        public string query;
        public string SupretionQuery;
        public string note;
        SqlDataAdapter adap;
        SqlConnection con;
        DataSet ds;
        SqlCommandBuilder cmdbl;

        public DB(string s, string k,string n)
        {
            InitializeComponent();
            this.query = s;
            this.SupretionQuery = k;
            this.note = n;

        }

        private void DB_Load(object sender, EventArgs e)
        {
            if (note == "note")
            {
                button2.Hide();}
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "eleves");
                dataGridView1.DataSource = ds.Tables[0];
            }catch(Exception exp){
                MessageBox.Show(exp.Message);
            }
            // con.ConnectionString = conX;
            // g();
        }
        public void g()
        {
            SqlCommand command2 = new SqlCommand();
            command2.Connection = conX;
            command2.CommandText = query;
            conX.Open();
            SqlDataReader d = command2.ExecuteReader();
            dataGridView1.Rows.Add();
            for (int j = 0; d.Read(); j++)
            {
               // dataGridView1.Rows.Add();


                dataGridView1.Rows[j].Cells["Id_eleve"].Value = d["Id_eleve"];
                dataGridView1.Rows[j].Cells["nom"].Value = d["nom"];
                dataGridView1.Rows[j].Cells["prenom"].Value = d["prenom"];
                dataGridView1.Rows[j].Cells["filier"].Value = d["claS"];
                dataGridView1.Rows[j].Cells["cne"].Value = d["cne"];
                dataGridView1.Rows[j].Cells["Nappoge"].Value = d["NappoG"];
                dataGridView1.Rows[j].Cells["nationalite"].Value = d["nationalite"];
                dataGridView1.Rows[j].Cells["date_naissance"].Value = d["date_naissance"];
                dataGridView1.Rows[j].Cells["email"].Value = d["email"];

            }




            conX.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("Voulez vous vrement suprimer la base de donne des Eleves ");
            if (MessageBox.Show("Voulez vous vrement suprimer la base de donne des Eleves", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) 
            {
                conX.Open();
                SqlCommand cmd = new SqlCommand(SupretionQuery, conX);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);
                //    dataGridView1.DataSource = ds.Tables[0];
                conX.Close();
                //dataGridView1.Refresh();
                
                    MessageBox.Show("Supretion bient efectuer");
                try
                {
                    con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30";
                    con.Open();
                    adap = new SqlDataAdapter(query, con);
                    ds = new System.Data.DataSet();
                    adap.Fill(ds, "eleves");
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }



            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*  String UpDatQuery = "UPDATE Eleves set Id_eleve=@Id_eleve, nom =@nom, prenom=@prenom,claS=@claS ,cne=@cne,NappoG=@NappoG,semester=@semester,date_naissance=@date_naissance,email=@email WHERE Id_eleve = '@Id_eleve' ";
              SqlCommand command2 = new SqlCommand();
              command2.Connection = conX;
              command2.CommandText = query;


              for (int j = 0; j < dataGridView1.Rows.Count; j++)
              {

                  command2.Parameters.AddWithValue("@Id_eleve", dataGridView1.Rows[j].Cells["Id_eleve"].Value);
                  command2.Parameters.AddWithValue("@nom", dataGridView1.Rows[j].Cells["nom"].Value);
                  command2.Parameters.AddWithValue("@prenom", dataGridView1.Rows[j].Cells["prenom"].Value);
                  command2.Parameters.AddWithValue("@claS", dataGridView1.Rows[j].Cells["filier"].Value);
                  command2.Parameters.AddWithValue("@cne", dataGridView1.Rows[j].Cells["cne"].Value);
                  command2.Parameters.AddWithValue("@NappoG", dataGridView1.Rows[j].Cells["Nappoge"].Value);
                  command2.Parameters.AddWithValue("@nationalite", dataGridView1.Rows[j].Cells["nationalite"].Value);
                  command2.Parameters.AddWithValue("@date_naissance", dataGridView1.Rows[j].Cells["date_naissance"].Value);
                  command2.Parameters.AddWithValue("@email", dataGridView1.Rows[j].Cells["email"].Value);



                  conX.Open();
                  command2.ExecuteNonQuery();

                  conX.Close();

              }

                  g();

             */

            try
            {
                cmdbl = new SqlCommandBuilder(adap);
                adap.Update(ds, "eleves");
                MessageBox.Show("Information updated");

            }
            catch (Exception esd)
            {
                MessageBox.Show(esd.Message);
            }



        }
        }
    }

