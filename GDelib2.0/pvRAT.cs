using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GDelib2._0
{
    public partial class pvRAT : Form
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

        string clas;
        string semestre;
        string libele;
        public pvRAT(string clas,string semest,string libele)
        {
            InitializeComponent();

            this.clas=clas;
            this.semestre= semest;
            this.libele= libele;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void PDG()
        {
            conX.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = conX;

            String query = "SELECT nom_elemPDG FROM  ElementPDG WHERE clas='" + clas + "' and semestre='" + semestre + "' ";

            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();

            comboBox1.Items.Clear();

            for (int i = 0; d.Read(); i++)
            {
                comboBox1.Items.Add(d["nom_elemPDG"]);
            }
            conX.Close();
        }


        private void PV_Load(object sender, EventArgs e)
        {

            PDG();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ToExcel(DataGridView dGV,string filename)
        {
            string stOutput = "";
            string sHeaders = "";
            for(int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
                stOutput += sHeaders + "\r\n";

            for (int i = 0; i < dGV.RowCount - 1; i++)
                {
                    string stline = "";
                    for(int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    
                        stline = stline.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                        stOutput += stline + "\t \n";
                }
            Encoding utf16= Encoding.GetEncoding(1254);

            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length);
            bw.Flush();
            bw.Close();
            fs.Close();

        }



        private void button2_Click(object sender, EventArgs e)
        {
SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Document(*.xls)|*.xls";
            sfd.FileName = "listRtt.xls";
            if (sfd.ShowDialog() == DialogResult.OK) { 
                ToExcel(dataGridView1, sfd.FileName);
            }
        }


        public void exportToPdf(DataGridView dgv,string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgv.Columns.Count);
            pdftable.DefaultCell.Padding= 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            foreach(DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);

            }
            try { 
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdftable.AddCell(new Phrase(cell.Value.ToString(), text));


                        }
            
                    }
               }catch(System.NullReferenceException exx){
                }



    var savefiledialoge =new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();


                }

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            exportToPdf(dataGridView1, "liste RAT ");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            label1.Text = libele;


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
            try
            {

                String query = "SELECT * FROM dbo.notes WHERE res='rattrape' and claS='" + clas + "' and semester='" + semestre + "'and nomElemPeda='" + comboBox1.SelectedItem.ToString() + "'";


                conX.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = conX;
                command.CommandText = query;

                SqlDataReader d = command.ExecuteReader();


                for (int i = 0; d.Read(); i++)
                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i].Cells["id_eleve"].Value = d["id_eleve"];

                    dataGridView1.Rows[i].Cells["nom"].Value = d["nom"];

                    dataGridView1.Rows[i].Cells["prenom"].Value = d["prenom"];

                    //  dataGridView1.Rows[i].Cells["filier"].Value = d["claS"];

                    dataGridView1.Rows[i].Cells["resulta"].Value = d["note"];

                }



                conX.Close();
            } catch (System.NullReferenceException ess)
            {
                MessageBox.Show("veuilez choisir un element");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
