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

namespace GDelib2._0
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
            ListeEtd.Hide();
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
           string pth = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + ofd.FileName + ";Extended Properties=Excel 8.0;";
                String path = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ ofd.FileName+";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(pth);
            OleDbDataAdapter myDtAdapter = new OleDbDataAdapter("Select * from [GI-3$]",conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                try
                {
                    myDtAdapter.Fill(dt);
                }
                catch (Exception ex)
                {
                     3ex.Message();
                }

               
                dataGridView1.DataSource = dt;

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = result.Tables[comboBox1.SelectedIndex];
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

    }
}
