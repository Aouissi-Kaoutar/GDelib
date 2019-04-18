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
using DataTable = System.Data.DataTable;

namespace GDelib2._0
{

    public partial class admin : Form
    {
        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        
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
            string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox1.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            string pat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties=Excel 12.0;";
            OleDbConnection conn = new OleDbConnection(path);
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [" + textBox2.Text + "$]", conn);
            DataTable dt = new DataTable();

            myDtAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

/*

            _Application excel = new _Excel.Application();
            Workbook wb = excel.Workbooks.Open(textBox1.Text);

            Worksheet ws = wb.Worksheets[textBox2.Text];

          
            int index = 0;
            object rowIndex = 2;

            while (((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 1]).Value2 != null)
            {

                dt = new System.Data.DataTable();
                dt.Columns.Add("id_eleve");
                dt.Columns.Add("nom");
                dt.Columns.Add("prenom");
                dt.Columns.Add("claS");
                dt.Columns.Add("cne");
                dt.Columns.Add("Napagee");
                dt.Columns.Add("photo");
                dt.Columns.Add("date_naissance");
                dt.Columns.Add("email");


                DataRow row;
                rowIndex = 2 + index;
                row = dt.NewRow();
                row[0] = 15;
                row[1] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 2]).Value2);
                row[2] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 3]).Value2);
                row[3] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 4]).Value2);
                row[4] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 5]).Value2);
                row[5] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 6]).Value2);
                row[6] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 7]).Value2);
                row[7] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 8]).Value2);
                row[8] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 9]).Value2);

                index++;
                dt.Rows.Add(row);


            }

            conX.Open();
            SqlBulkCopy bulkcopy = new SqlBulkCopy(conX);
            //I assume you have created the table previously
            //Someone else here already showed how  
            bulkcopy.DestinationTableName = "eleve";
            try
            {
                bulkcopy.WriteToServer(dt);
                conX.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

*/




        }

        private void button5_Click(object sender, EventArgs e)
        {
           /* _Application excel = new _Excel.Application();
            Workbook wb = excel.Workbooks.Open(textBox1.Text);

            Worksheet ws = wb.Worksheets[textBox2.Text];

            System.Data.DataTable dt = null;
            int index = 0;
            object rowIndex = 2;

            while (((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 1]).Value2 != null)
            {

                dt = new System.Data.DataTable();
                dt.Columns.Add("id_eleve");
                dt.Columns.Add("nom");
                dt.Columns.Add("prenom");
                dt.Columns.Add("claS");
                dt.Columns.Add("cne");
                dt.Columns.Add("Napagee");
                dt.Columns.Add("photo");
                dt.Columns.Add("date_naissance");
                dt.Columns.Add("email");


                DataRow row;
                rowIndex = 2 + index;
                row = dt.NewRow();
                row[0] = 15;
                row[1] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 2]).Value2);
                row[2] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 3]).Value2);
                row[3] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 4]).Value2);
                row[4] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 5]).Value2);
                row[5] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 6]).Value2);
                row[6] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 7]).Value2);
                row[7] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 8]).Value2);
                row[8] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)ws.Cells[rowIndex, 9]).Value2);

                index++;
                dt.Rows.Add(row);


            }
         
            conX.Open();
            SqlBulkCopy bulkcopy = new SqlBulkCopy(conX);
            //I assume you have created the table previously
            //Someone else here already showed how  
            bulkcopy.DestinationTableName = "eleve";
            try
            {
                bulkcopy.WriteToServer(dt);
                conX.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
               //
            

    */


            for(int i =0;i<dataGridView1.Rows.Count-1;i++)
            {

                String query = "INSERT INTO dbo.eleve (id_eleve,nom,prenom,claS,cne,NappoG,photo,date_naissance,email) VALUES (@id_eleve,@nom,@prenom,@claS,@cne,@NappoG,@photo,@date_naissance,@email)";
                SqlCommand command = new SqlCommand(query, conX);
                command.Parameters.AddWithValue("@id_eleve", dataGridView1.Rows[i].Cells[0].Value );
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
               
                /* SqlCommand cmd = new SqlCommand(@"INSERT INTO eleve (id_eleve,nom,prenom,claS,cne,NappoG,photo,date_naissance,email) VALUES (
                     '"+dataGridView1.Rows[i].Cells[0].Value+"','"
                     + dataGridView1.Rows[i].Cells[1].Value+"','"
                     + dataGridView1.Rows[i].Cells[2].Value + "','"
                     + dataGridView1.Rows[i].Cells[3].Value + "','"
                     + dataGridView1.Rows[i].Cells[4].Value + "','"
                     + dataGridView1.Rows[i].Cells[5].Value + "','"
                     + dataGridView1.Rows[i].Cells[6].Value + "','"
                     + dataGridView1.Rows[i].Cells[7].Value + "','"
                     + dataGridView1.Rows[i].Cells[8].Value + "')", conX);
                 conX.Open();
                 cmd.ExecuteNonQuery();
                 conX.Close();
            */

            }
            MessageBox.Show("enregistrement est bient efectuer pour les " + textBox2.Text);

        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM eleve WHERE claS='GI3' ", conX);
            conX.Open();
            cmd.ExecuteNonQuery();
            conX.Close();

            MessageBox.Show("vous avez suprimer les donee du class" + textBox2.Text);

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
