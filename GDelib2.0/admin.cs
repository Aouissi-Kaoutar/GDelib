using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using ExcelDataReader.Log;
using System.Data.SqlClient;

namespace GDelib2._0
{
   
    public partial class admin : Form
    {
        public SqlConnection conX = new SqlConnection(@"Data Source=KAWTAR\SQLEXPRESS04;Initial Catalog=GDeleb2.0;Integrated Security=True");
        public int[] id_eleve;
        public string[] nom;
        public string[] prenom;
        public string[] claS;
        public string[] cne;
        public string[] Napagee;
        public string[] photo;
        public string[] date_naissance;
        public string[] email;
        public admin()
        {
            InitializeComponent();
            ListeEtd.Hide();
            acceuil.Show();
        }
        DataSet result;
        private void button4_Click(object sender, EventArgs e)
        {
            /* using (OpenFileDialog ofd = new OpenFileDialog() { Filter= "Excel Files|*.xls;*.xlsx", ValidateNames = true })
             {
                 if (ofd.ShowDialog() == DialogResult.OK)
                 {
                     FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                     IExcelDataReader reader;  
                         reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                     reader.IsFirstRowAsColumnNames = true;
                    result = reader.AsDataSet();
                    comboBox1.Items.Clear();
                     foreach (DataTable dt in result.Tables)
                         comboBox1.Items.Add(dt.TableName);
                     reader.Close();
                 }
             }*/

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
          

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   dataGridView1.DataSource = result.Tables[comboBox1.SelectedIndex];
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            acceuil.Show();
            ListeEtd.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListeEtd.Show();
            acceuil.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string pth = @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 8.0;";
            string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+textBox1.Text+";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            string pat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 12.0;";
        OleDbConnection conn = new OleDbConnection(pat);
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [" + textBox2.Text + "$]", conn);
           DataSet dt = new DataSet();

            myDtAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            int i = 0;
            foreach (System.Data.DataTable tbl in dt.Tables)
                foreach (DataRow dr in tbl.Rows)
            {
                 id_eleve[i]= Convert.ToInt32(dr[0]);
                 nom[i] =  dr[1].ToString();    
                 prenom[i]= dr[2].ToString();
                claS[i]= dr[3].ToString();
                cne[i]= dr[4].ToString();
                Napagee[i]= dr[5].ToString();
                photo[i]= dr[6].ToString();
                date_naissance[i]= dr[7].ToString();
                email[i]= dr[8].ToString();

                i++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conX.Open();

            int t = email.Length;
            for (int j = 0; j < t; j++)
            {
                try
                {

                    using (SqlCommand command = new SqlCommand(
                        "insert into eleve(id_eleve,nom,prenom,class) values ", conX))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Table not created.");
                }


            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int t = email.Length;
            for (int j = 0; j < t; j++)
            {
                A.Text +=nom[j]+"||";
                B.Text += prenom[j] + "||";



                    }
        }
    }
}
