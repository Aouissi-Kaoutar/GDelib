﻿using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;




namespace GDelib2._0
{
    public partial class pvSEM : Form
    {
        //OUISSAL CONNEX
        //    public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        //KAWTAR CONX
        //public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        /*
                static string path = Path.GetFullPath(Environment.CurrentDirectory);
                static string dataBseName = "GDelibe2.mdf";
                public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + dataBseName + "; Integrated Security=True;Connect Timeout=30");
        */
        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Desktop\kawtar\aaaaa\GDelib2.0-2019\GDelib2.0\Database1.mdf;Integrated Security=True");

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
            string query = " SELECT  nom_elemPDG FROM ElementPDG where clas='" + clas + "'and semestre='" + semestre + "'";
                 listModule = new List<string>();
                 SqlCommand command1 = new SqlCommand();
                 command1.Connection = conX;
                 command1.CommandText = query;
                 conX.Open();
                 SqlDataReader d = command1.ExecuteReader();
                 for (int j = 0; d.Read(); j++)
                 {
                     if (d["nom_elemPDG"].ToString() != null)
                         listModule.Add(@d["nom_elemPDG"].ToString().Replace(" ", string.Empty));
                     //  listId_Module.Add(d["id_elem_PDG"].ToString());
                 }
                 conX.Close();

           
                conX.Open();
                string listeEleve = "select Id_eleve from Eleves where claS='" + clas+ "'";
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
             {   string listeNote = "select nom,prenom,nomElemPeda,note,res,id_elem_PDG from notes where claS='" + clas+"' and semester='"+semestre+"' and id_eleve='" + liseEleves[i] + "' ";
                //6ROW

                SqlCommand command2 = new SqlCommand();
                command2.Connection = conX;
                command2.CommandText = listeNote;
                conX.Open();
                SqlDataReader Notes = command2.ExecuteReader();
                dataGridView1.Rows.Add();
                string f = "";
                for (int j = 0; Notes.Read(); j++)
                {
                    String nom = Notes["nom"].ToString();
                    String prenom = Notes.GetString(1);
                    dataGridView1.Rows[i].Cells["Name"].Value = nom + " " + prenom;
                    int k = j+1;
                   // int indic;
                    String idModule = Notes["id_elem_PDG"].ToString();
                    String nomModule = Notes["nomElemPeda"].ToString().Replace(" ", string.Empty);
                    int b = 1;
                   
                    f = f +"*****"+ nomModule;
                    foreach (String s in listModule)
                    { 
                        if (s== nomModule)
                        {  dataGridView1.Rows[i].Cells["noteM"+b].Value = Notes["note"];
                            dataGridView1.Rows[i].Cells["statuM"+b].Value = Notes["res"];

                        }
                        b++;
                    }
                   


                    /* if (nomModule == listModule[0])
                     {
                         dataGridView1.Rows[i].Cells["noteM1"].Value = Notes["note"];
                         dataGridView1.Rows[i].Cells["statuM1"].Value = Notes["res"];
                     }
                     if (nomModule == listModule[1])
                     {
                         dataGridView1.Rows[i].Cells["noteM2"].Value = Notes["note"];
                         dataGridView1.Rows[i].Cells["statuM2"].Value = Notes["res"];
                     }
                     if (nomModule == listModule[2])
                     {
                         dataGridView1.Rows[i].Cells["noteM3"].Value = Notes["note"];
                         dataGridView1.Rows[i].Cells["statuM3" + k].Value = Notes["res"];
                     }
                     if (nomModule == listModule[3])
                     {
                         dataGridView1.Rows[i].Cells["noteM4"].Value = Notes["note"];
                         dataGridView1.Rows[i].Cells["statuM4"].Value = Notes["res"];
                     }
                     if (nomModule == listModule[4])
                     {
                         dataGridView1.Rows[i].Cells["noteM5"].Value = Notes["note"];
                         dataGridView1.Rows[i].Cells["statuM5"].Value = Notes["res"];
                     }
                     if (nomModule == listModule[5])
                     {
                         dataGridView1.Rows[i].Cells["noteM6"].Value = Notes["note"];
                         dataGridView1.Rows[i].Cells["statuM6"].Value = Notes["res"];
                     }

                     /*
                         for (indic = 1; indic < 7; indic++)
                     {
                         if (nomModule == listModule[j]) { 
                         dataGridView1.Rows[i].Cells["noteM"+k].Value = Notes["note"];
                         dataGridView1.Rows[i].Cells["statuM"+k].Value = Notes["res"];
                     }
                     }*/

                }
              //  MessageBox.Show(f);

                conX.Close();
            }



        }

       
        private void pvSEM_Load(object sender, EventArgs e)
        {

            kkkk2();
           

        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 30;
            label1.Text = libele;
            //**************************

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


    
            //****************
            

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
                System.Drawing.Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }


        }

        private void dataDridView1_Paint(object sender, PaintEventArgs e)
        {
            try { 

                int k = 0;
            for (int i = 1; i < 12; i = i + 2)
            {

                    System.Drawing.Rectangle r1 = dataGridView1.GetCellDisplayRectangle(i, -1, true);
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
               // MessageBox.Show(exp.Message);
            }
            finally
            {
                conX.Close();
            }

           // kkkk2();
          
        }


           

            public void dataDridView1_Scroll(object sender, ScrollEventArgs e) {
            System.Drawing.Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
            dataGridView1.Invalidate(rtHeader);
        }
        public void dataGridView1_ColumnWhidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            System.Drawing.Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
            dataGridView1.Invalidate(rtHeader);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void exportToPdf(DataGridView dgv, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgv.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);

            }
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdftable.AddCell(new Phrase(cell.Value.ToString(), text));


                    }

                }
            }
            catch (System.NullReferenceException exx)
            {
            }



            var savefiledialoge = new SaveFileDialog();
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
            exportToPdf(dataGridView1, "PV Semestrielle");
        }
    }
}
