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
        public string namef;
        public string semestre=null;
        public string clas;
        public string ElemPDG;
        public string session;
        string nameFile;

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
                char[] splitters = new char[] { '\\' };
                string[] nameFile = ofd.FileName.Split(splitters);
               string name = nameFile[nameFile.Length-1];
                string[] nameF = name.Split(new char[] { '.' });
                 namef = nameF[0];

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
                Form2 c = new Form2(clas, ElemPDG, semestre,session, ofd, namef);
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
                pvSEM pv = new pvSEM(comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), "Liste des resultats  semestrielle pour les " + comboBox2.SelectedItem.ToString());
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
                    PvAnnuelleGI5 pv = new PvAnnuelleGI5(comboBox1.SelectedItem.ToString(), "Liste des resultats  annuelle pour les " + comboBox1.SelectedItem.ToString());
                    pv.Show();
                }
                else {
                    PVanuelle pv = new PVanuelle(comboBox1.SelectedItem.ToString(), "Liste des resultats  annuelle pour les " + comboBox1.SelectedItem.ToString());
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

        private void button6_Click(object sender, EventArgs e)
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

            con.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = con;

            String query = "SELECT Id_eleve,nom,prenom FROM  Eleves WHERE claS='" + clas + "'";

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();



            for (int i = 0; d.Read(); i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id_eleve"].Value = d["Id_eleve"];

                dataGridView1.Rows[i].Cells["nom"].Value = d["nom"];

                dataGridView1.Rows[i].Cells["prenom"].Value = d["prenom"];

            }
            con.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Document(*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dataGridView1, sfd.FileName);
            }
        }


        public void ToExcel(DataGridView dGV, string filename)
        {
            string stOutput = "";
            string sHeaders = "";
            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";

            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stline = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)

                    stline = stline.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stline + "\t \n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);

            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length);
            bw.Flush();
            bw.Close();
            fs.Close();

        }

    }
}
