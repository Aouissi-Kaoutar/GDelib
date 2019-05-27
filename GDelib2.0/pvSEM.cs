using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KimToo;
namespace GDelib2._0
{
    public partial class pvSEM : Form
    {
        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        List<string> listModule;
        List<string> listId_Module;
        
         List<string> liseEleves;
        int rrr = 0;
        string clas;
        string semestre;
        string libele;
        public pvSEM(string clas, string semest, string libele)
        {
            InitializeComponent();

            this.clas = clas;
            this.semestre = semest;
            this.libele = libele;
        }

        private void kkkk2()
        {
                conX.Open();
                string listeEleve = "select Id_eleve from Eleves where claS='" + clas + "'and semester='" + semestre + "'";

                SqlCommand command = new SqlCommand();
                command.Connection = conX;
                command.CommandText = listeEleve;


                SqlDataReader Eleves = command.ExecuteReader();
                liseEleves = new List<string>();
                for (int j = 0; Eleves.Read(); j++)
                {
                    liseEleves.Add(Eleves["Id_eleve"].ToString());
                }
                conX.Close();
            for (int i = 0; i < liseEleves.Count; i++)
            {
                string listeNote = "select nom,prenom,nomElemPeda,note,res,id_elem_PDG from notes where claS='" + clas+"' and semester='"+semestre+"' and id_eleve='" + liseEleves[i] + "' ";
                SqlCommand command2 = new SqlCommand();
                command2.Connection = conX;
                command2.CommandText = listeNote;
                conX.Open();
                SqlDataReader Notes = command2.ExecuteReader();

                dataGridView1.Rows.Add();
                rrr++;


                for (int j = 0; Notes.Read(); j++)
                {
                    String nom = Notes["nom"].ToString();
                    String prenom = Notes.GetString(1);
                    dataGridView1.Rows[i].Cells["Name"].Value = nom + " " + prenom;
                    int k = j+1;
                    int indic;
                    String Note = Notes["id_elem_PDG"].ToString();
                    for (indic = 1; indic < 7; indic++)
                    {
                        if (@Note == listModule[j]) { 
                        dataGridView1.Rows[i].Cells["noteM"+k].Value = Notes["note"];
                        dataGridView1.Rows[i].Cells["statuM"+k].Value = Notes["res"];
                    }
                    }
                    
                }

                conX.Close();
            }



        }

       
        private void pvSEM_Load(object sender, EventArgs e)
        {


           

        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 30;
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


                dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight * 2;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
                dataGridView1.Paint += new PaintEventHandler(dataDridView1_Paint);
                dataGridView1.Scroll += new ScrollEventHandler(dataDridView1_Scroll);
                dataGridView1.ColumnWidthChanged +=new DataGridViewColumnEventHandler(dataGridView1_ColumnWhidthChanged);
                


            
            }

        

        private void dataGridView1_CellPainting(Object sender,DataGridViewCellPaintingEventArgs e) {
            if(e.RowIndex==-1 && e.ColumnIndex> -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }


        }

        private void dataDridView1_Paint(object sender, PaintEventArgs e)
        {
            string query = "select * from ElementPDG where clas='" + clas + "'and semestre='" + semestre + "'";

            try
            {

                listModule = new List<string>();
                SqlCommand command = new SqlCommand();
                command.Connection = conX;
                command.CommandText = query;
                conX.Open();
                SqlDataReader d = command.ExecuteReader();


                for (int j = 0; d.Read(); j++)
                {
                    listModule.Add(d["nom_elemPDG"].ToString());
                  //  listId_Module.Add(d["id_elem_PDG"].ToString());
                }


                int k = 0;
            for (int i = 1; i < 12; i = i + 2)
            {

                Rectangle r1 = dataGridView1.GetCellDisplayRectangle(i, -1, true);
                int w2 = dataGridView1.GetCellDisplayRectangle(i + 1, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(listModule[i - k], dataGridView1.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                k++;
            }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                conX.Close();
            }

            kkkk2();
          
        }


           

            public void dataDridView1_Scroll(object sender, ScrollEventArgs e) {
            Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
            dataGridView1.Invalidate(rtHeader);
        }
        public void dataGridView1_ColumnWhidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
            dataGridView1.Invalidate(rtHeader);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "C: ";
            saveFileDialog1.Title = "Enregistrer PDF"; 
            saveFileDialog1.Filter = "PDF Files| *.pdf"; ;


            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create));
                PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                doc.Open();  //open Document to write
                             // PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.YELLOW)));

                //table.AddCell(cell);
                //  int niv = int.Parse(comboBox8.SelectedValue.ToString());
                //int annee1 = int.Parse(comboBox6.SelectedValue.ToString());
                //int annee2 = int.Parse(comboBox6.SelectedValue.ToString()) - 1;
               
              

                Paragraph paragraph = new Paragraph(" UNIVERSITE MOHAMMED PREMIER \n Ecole Nationale des Sciences Appliquées(ENSA) \n Oujda-Maroc \n ");
                paragraph.Alignment = Element.ALIGN_CENTER;
                doc.Add(paragraph);
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
                }
                table.HeaderRows = 1;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        if (dataGridView1[k, i].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                        }
                    }
                }

                doc.Add(table);
                doc.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.AddHorizontalRule();
            easyHTMLReports1.AddDatagridView(dataGridView1);
            easyHTMLReports1.ShowPrintPreviewDialog();
        }
    }

    }

