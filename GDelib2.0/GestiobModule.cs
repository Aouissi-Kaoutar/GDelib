using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDelib2._0
{
    public partial class GestiobModule : Form
    {
        public OpenFileDialog ofd;
        string semestre;
        string clas;


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
                (
                   int nLeftRect,
                   int nTopRect,
                   int nRightRect,
                   int nBottomRect,
                   int nWidthEllipse,
                   int nHeightEllipse
                );
        private Control _cntrl;
        private int _CornerRadius = 30;

        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");


        public Control TargetControl
        {
            get { return _cntrl; }
            set
            {
                _cntrl = value;
                _cntrl.SizeChanged += (sender, eventArgs) => _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
            }
        }

        public int CornerRadius
        {
            get { return _CornerRadius; }
            set
            {
                _CornerRadius = value;
                if (_cntrl != null)
                    _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
            }
        }
        public GestiobModule()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Show();
            ListeEtd.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ListeEtd.Show();
            panel3.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ListeEtd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox1.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            //   string pat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 12.0;";
            OleDbConnection conn = new OleDbConnection(path);
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [" + "Feuil1" + "$]", conn);
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
                    String query = "INSERT INTO dbo.ElementPDG (id_elem_PDG,nom_elemPDG,filiere,niveau,type,coefficient,noteElim,seuil_valida) VALUES (@id_elem_PDG,@nom_elemPDG,@filiere,@niveau,@type,@coefficient,@noteElim,@seuil_valida)";
                    SqlCommand command = new SqlCommand(query, conX);
                    command.Parameters.AddWithValue("@id_elem_PDG", dataGridView1.Rows[i].Cells[0].Value);
                    command.Parameters.AddWithValue("@nom_elemPDG", dataGridView1.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@filiere", dataGridView1.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@niveau", dataGridView1.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@type", dataGridView1.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@coefficient", dataGridView1.Rows[i].Cells[5].Value);
                    command.Parameters.AddWithValue("@noteElim", dataGridView1.Rows[i].Cells[6].Value);
                    command.Parameters.AddWithValue("@seuil_valida", dataGridView1.Rows[i].Cells[7].Value);

                    conX.Open();
                    command.ExecuteNonQuery();
                    conX.Close();
                }
                catch (System.Data.SqlClient.SqlException expe)
                {
                    MessageBox.Show("une valeur id_eleve est deja inserer verifier votre Doc  \n \n \n \n" + expe.Message);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel5.Show();
           tabControl1.Hide();
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;


            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string pth = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 8.0;";
            string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox1.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            string pat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 12.0;";
            OleDbConnection conn = new OleDbConnection(path);
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [" + comboBox4.SelectedItem.ToString() + "$]", conn);
            DataTable dt = new DataTable();

            myDtAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    String query = "INSERT INTO dbo.Eleves (id_eleve,nom,prenom,claS,cne,NappoG,photo,date_naissance,email) VALUES (@id_eleve,@nom,@prenom,@claS,@cne,@NappoG,@photo,@date_naissance,@email)";
                    SqlCommand command = new SqlCommand(query, conX);
                    command.Parameters.AddWithValue("@id_eleve", dataGridView1.Rows[i].Cells[0].Value);
                    command.Parameters.AddWithValue("@nom", dataGridView1.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@prenom", dataGridView1.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@claS", dataGridView1.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@cne", dataGridView1.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@NappoG", dataGridView1.Rows[i].Cells[5].Value);
                    command.Parameters.AddWithValue("@photo", dataGridView1.Rows[i].Cells[6].Value);
                    command.Parameters.AddWithValue("@date_naissance", dataGridView1.Rows[i].Cells[7].Value);
                    command.Parameters.AddWithValue("@email", dataGridView1.Rows[i].Cells[8].Value);

                    conX.Open();
                    command.ExecuteNonQuery();
                    conX.Close();
                }
                catch (System.Data.SqlClient.SqlException expe)
                {
                    MessageBox.Show("une valeur id_eleve est deja inserer verifier votre Doc  \n \n \n \n" + expe.Message);
                }

            }
            MessageBox.Show("enregistrement est bient efectuer pour les " + comboBox4.SelectedItem.ToString());

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Eleves WHERE claS='GI3' ", conX);
            conX.Open();
            cmd.ExecuteNonQuery();
            conX.Close();

            MessageBox.Show("vous avez suprimer les donee du class" + comboBox4.SelectedItem.ToString());

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            panel5.Hide();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = ofd.FileName;


            }

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            string pth = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + textBox3.Text + ";Extended Properties=Excel 8.0;";
            string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox3.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            string pat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox3.Text + ";Extended Properties=Excel 12.0;";
            OleDbConnection conn = new OleDbConnection(path);
            string s = comboBox4.SelectedItem.ToString();
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [" + "GI-3"+ "$]", conn);
            DataTable dt = new DataTable();

            myDtAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    String query = "INSERT INTO dbo.Eleves (id_eleve,nom,prenom,claS,cne,NappoG,photo,date_naissance,email) VALUES (@id_eleve,@nom,@prenom,@claS,@cne,@NappoG,@photo,@date_naissance,@email)";
                    SqlCommand command = new SqlCommand(query, conX);
                    command.Parameters.AddWithValue("@id_eleve", dataGridView1.Rows[i].Cells[0].Value);
                    command.Parameters.AddWithValue("@nom", dataGridView1.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@prenom", dataGridView1.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@claS", dataGridView1.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@cne", dataGridView1.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@NappoG", dataGridView1.Rows[i].Cells[5].Value);
                    command.Parameters.AddWithValue("@photo", dataGridView1.Rows[i].Cells[6].Value);
                    command.Parameters.AddWithValue("@date_naissance", dataGridView1.Rows[i].Cells[7].Value);
                    command.Parameters.AddWithValue("@email", dataGridView1.Rows[i].Cells[8].Value);

                    conX.Open();
                    command.ExecuteNonQuery();
                    conX.Close();
                }
                catch (System.Data.SqlClient.SqlException expe)
                {
                    MessageBox.Show("une valeur id_eleve est deja inserer verifier votre Doc  \n \n \n \n" + expe.Message);
                }
            }
            MessageBox.Show("enregistrement est bient efectuer pour les " + comboBox4.SelectedItem.ToString());

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Eleves WHERE claS='GI3' ", conX);
            conX.Open();
            cmd.ExecuteNonQuery();
            conX.Close();

            MessageBox.Show("vous avez suprimer les donee du class" + comboBox4.SelectedItem.ToString());
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;


            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string pth = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 8.0;";
            string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox1.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            string pat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 12.0;";
            OleDbConnection conn = new OleDbConnection(path);
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [" +"Feuil1"+ "$]", conn);
            DataTable dt = new DataTable();

            myDtAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    String query = "INSERT INTO dbo.ElementPDG (id_elem_PDG,nom_elemPDG,clas,semestre,type,coefficient,noteElim,seuil_valida) VALUES (@id_elem_PDG,@nom_elemPDG,@clas,@semestre,@type,@coefficient,@noteElim,@seuil_valida)";
                    SqlCommand command = new SqlCommand(query, conX);
                    command.Parameters.AddWithValue("@id_elem_PDG", dataGridView1.Rows[i].Cells[0].Value);
                    command.Parameters.AddWithValue("@nom_elemPDG", dataGridView1.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@clas", dataGridView1.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@semestre", dataGridView1.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@type", dataGridView1.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@coefficient", dataGridView1.Rows[i].Cells[5].Value);
                    command.Parameters.AddWithValue("@noteElim", dataGridView1.Rows[i].Cells[6].Value);
                    command.Parameters.AddWithValue("@seuil_valida", dataGridView1.Rows[i].Cells[7].Value);

                    conX.Open();
                    command.ExecuteNonQuery();
                    conX.Close();
                }
                catch (System.Data.SqlClient.SqlException expe)
                {
                    MessageBox.Show("une valeur id_eleve est deja inserer verifier votre Doc  \n \n \n \n" + expe.Message);
                }
                MessageBox.Show("enregistrement est bient efectuer pour les " + comboBox1.SelectedItem.ToString());
            }
        }

        private void f()
        {
            conX.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = conX;

            String query = "SELECT * FROM  ElementPDG WHERE filiere='" + comboBox2.SelectedItem.ToString() + "' and semester='" + semestre + "'";

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();

            comboBox1.Items.Clear();

            for (int i = 0; d.Read(); i++)
            {
                comboBox1.Items.Add(d["nomElemPeda"]);
            }
            conX.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            semestre = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            semestre = "2";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            clas = comboBox2.SelectedItem.ToString();
            f();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;


            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 c = new Form2(comboBox2.SelectedItem.ToString(), semestre, comboBox1.SelectedItem.ToString(), ofd);
                c.Show();
            }
            catch (System.NullReferenceException eee)
            {
                MessageBox.Show("manque un champ\n \n \n" + eee.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
