using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel;
//using Microsoft.Office.Interop.Excel;
//using _Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using ExcelDataReader.Log;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GDelib2._0
{

    public partial class admin : Form
    {
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
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }
       // DataSet result;
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
                try { 
                String query = "INSERT INTO dbo.Eleves (id_eleve,nom,prenom,claS,cne,NappoG,photo,date_naissance,email) VALUES (@id_eleve,@nom,@prenom,@claS,@cne,@NappoG,@photo,@date_naissance,@email)";
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
                }catch(System.Data.SqlClient.SqlException expe) {
                    MessageBox.Show("une valeur id_eleve est deja inserer verifier votre Doc  \n \n \n \n" + expe.Message);
                }



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
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Eleves WHERE claS='GI3' ", conX);
            conX.Open();
            cmd.ExecuteNonQuery();
            conX.Close();

            MessageBox.Show("vous avez suprimer les donee du class" + textBox2.Text);

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void admin_Load(object sender, EventArgs e)
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


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*GestiobModule A = new GestiobModule();
            this.Hide();
            A.Show();
            */

    }

        private void button8_Click_1(object sender, EventArgs e)
        {
            admin A = new admin();
            this.Hide();
            A.Show();
        }
    }
}
