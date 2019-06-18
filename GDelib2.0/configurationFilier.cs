using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace GDelib2._0
{
    public partial class configurationFilier : UserControl
    {

        //OUISSAL CONNEX
        //    public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        //KAWTAR CONX
        // public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");

        /*
                static string path = Path.GetFullPath(Environment.CurrentDirectory);
                static string dataBseName = "GDelibe2.mdf";
                public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + dataBseName + "; Integrated Security=True;Connect Timeout=30");
        */
        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Desktop\kawtar\aaaaa\GDelib2.0-2019\GDelib2.0\Database1.mdf;Integrated Security=True");

        public configurationFilier()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = ofd.FileName;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;




            string pth = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + textBox3.Text + ";Extended Properties=Excel 8.0;";
            string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox3.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            string pat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox3.Text + ";Extended Properties=Excel 12.0;";
            OleDbConnection conn = new OleDbConnection(path);
            string s = comboBox4.SelectedItem.ToString();
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [" + comboBox4.SelectedItem.ToString() + "$]", conn);
            DataTable dt = new DataTable();

            myDtAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {

           
                try
                {
                conX.Open();
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value.ToString() != "")
                    {
                        String query = "INSERT INTO dbo.Eleves (id_eleve,nom,prenom,claS,cne,NappoG,nationalite,date_naissance,email,etat) VALUES (@id_eleve,@nom,@prenom,@claS,@cne,@NappoG,@photo,@date_naissance,@email,@etat)";
                    SqlCommand command = new SqlCommand(query, conX);
                    command.Parameters.AddWithValue("@id_eleve", dataGridView2.Rows[i].Cells[0].Value);
                    command.Parameters.AddWithValue("@nom", dataGridView2.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@prenom", dataGridView2.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@claS", comboBox4.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@cne", dataGridView2.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@NappoG", dataGridView2.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@photo", dataGridView2.Rows[i].Cells[5].Value);
                    command.Parameters.AddWithValue("@date_naissance", dataGridView2.Rows[i].Cells[6].Value);
                    command.Parameters.AddWithValue("@email", dataGridView2.Rows[i].Cells[7].Value);
                    command.Parameters.AddWithValue("@etat", dataGridView2.Rows[i].Cells[8].Value);

                  
                    command.ExecuteNonQuery();

                    }
                }

            }
            catch (System.Data.SqlClient.SqlException expe)
                {
                MessageBox.Show("Valeurs deja inserer \n\n\n"+expe.Message);
               
                    }
                    finally
                    {
                        conX.Close();
                        MessageBox.Show("enregistrement est bient efectuer pour les " + comboBox4.SelectedItem.ToString());



            }
         
           


        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Eleves WHERE claS='"+ comboBox4.SelectedItem.ToString() + "' ", conX);
            conX.Open();
            cmd.ExecuteNonQuery();
            conX.Close();

            MessageBox.Show("vous avez suprimer les donee du class" + comboBox4.SelectedItem.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
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


            string pth = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 8.0;";
            string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox1.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            string pat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 12.0;";
            OleDbConnection conn = new OleDbConnection(path);
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [" + comboBox1.SelectedItem.ToString() + "$]", conn);
            DataTable dt = new DataTable();

            myDtAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    
                    String query = "INSERT INTO dbo.ElementPDG (id_elem_PDG,nom_elemPDG,clas,semestre,type,coefficient,noteElim,seuil_valida) VALUES (@id_elem_PDG,@nom_elemPDG,@clas,@semestre,@type,@coefficient,@noteElim,@seuil_valida)";
                    SqlCommand command = new SqlCommand(query, conX);
                    command.Parameters.AddWithValue("@id_elem_PDG", dataGridView1.Rows[i].Cells[0].Value);
                    command.Parameters.AddWithValue("@nom_elemPDG", dataGridView1.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@clas", comboBox1.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@semestre", dataGridView1.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@type", dataGridView1.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@coefficient", dataGridView1.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@noteElim", dataGridView1.Rows[i].Cells[5].Value);
                    command.Parameters.AddWithValue("@seuil_valida", dataGridView1.Rows[i].Cells[6].Value);

                    conX.Open();
                    command.ExecuteNonQuery();
                   
                }
                catch (System.Data.SqlClient.SqlException expe)
                {
                    MessageBox.Show("une valeur id_eleve est deja inserer verifier votre Doc  \n \n \n \n" + expe.Message);
                }
                finally
                {
                    conX.Close();
                }
               
            }
            MessageBox.Show("enregistrement est bient efectuer pour les " + comboBox1.SelectedItem.ToString());

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB("SELECT * From Eleves", @"DELETE FROM Eleves ","");
            db.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB("SELECT * From notes", @"DELETE FROM notes ","note");
            db.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
         DB db = new DB("SELECT * From ElementPDG", @"DELETE FROM ElementPDG ","");
            db.Show();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            button12.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.BackColor = Color.Gray;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            button11.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.BackColor = Color.Gray;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Gray;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.Gray;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.Gray;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Gray;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(2, 127, 143);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Gray;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.PowderBlue;
            button1.ForeColor = Color.Black;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gray;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.PowderBlue;
            button2.ForeColor = Color.Black;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.Gray;
            button6.ForeColor = Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.PowderBlue;
            button6.ForeColor = Color.Black;
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
