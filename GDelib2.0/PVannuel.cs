using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data;

namespace GDelib2._0
{
    public partial class PVannuel : Form
    {
        string clas;
        string semestre;
        string libele;
      
        public PVannuel(string clas,  string libele)
        {
            InitializeComponent();
            this.clas = clas;
            this.libele = libele;
        }
        
            public SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
            List<string> listModule;
            List<string> listId_Module;

            List<string> liseEleves;
            int rrr = 0;



       

        private void kkkk2()
            {
                cn.Open();
                string listeEleve = "select Id_eleve from Eleves where claS='" + clas + "'and semester='" + semestre + "'";

                SqlCommand command = new SqlCommand();
                command.Connection = cn;
                command.CommandText = listeEleve;


                SqlDataReader Eleves = command.ExecuteReader();
                liseEleves = new List<string>();
                for (int j = 0; Eleves.Read(); j++)
                {
                    liseEleves.Add(Eleves["Id_eleve"].ToString());
                }
                cn.Close();
                for (int i = 0; i < liseEleves.Count; i++)
                {
                    string listeNote = "select nom,prenom,nomElemPeda,note,res,id_elem_PDG from notes where claS='" + clas + "' and semester='" + semestre + "' and id_eleve='" + liseEleves[i] + "' ";
                    SqlCommand command2 = new SqlCommand();
                    command2.Connection = cn;
                    command2.CommandText = listeNote;
                cn.Open();
                    SqlDataReader Notes = command2.ExecuteReader();

                    dataGridView1.Rows.Add();
                    rrr++;


                    for (int j = 0; Notes.Read(); j++)
                    {
                        String nom = Notes["nom"].ToString();
                        String prenom = Notes.GetString(1);
                        dataGridView1.Rows[i].Cells["Name"].Value = nom + " " + prenom;
                        int k = j + 1;
                        int indic;
                        String Note = Notes["id_elem_PDG"].ToString();
                        for (indic = 1; indic < 7; indic++)
                        {
                            if (@Note == listModule[j])
                            {
                                dataGridView1.Rows[i].Cells["noteM" + k].Value = Notes["note"];
                                dataGridView1.Rows[i].Cells["statuM" + k].Value = Notes["res"];
                            }
                        }

                    }

                    cn.Close();
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
                dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView1_ColumnWhidthChanged);




            }



            private void dataGridView1_CellPainting(Object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex == -1 && e.ColumnIndex > -1)
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
                    command.Connection = cn;
                    command.CommandText = query;
                cn.Open();
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
                cn.Close();
                }

                kkkk2();

            }




            public void dataDridView1_Scroll(object sender, ScrollEventArgs e)
            {
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            String path = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                          ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
            OleDbConnection conn = new OleDbConnection(path);
            //exporter

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = " C:";
            saveFileDialog1.Title = "Enregistrer Excel";
           // saveFileDialog1.FileName = comboBox7.Text.ToUpper().Trim() + "_" + comboBox8.Text + "_" + (int.Parse(comboBox6.SelectedValue.ToString()) - 1) + "-" + comboBox6.Text + "Annuelle";
            saveFileDialog1.Filter = "Excel Files(2007)|*.xls|Excel Files(2003)|*.xlsx";
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 20;
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;

                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        try
                        {

                            ExcelApp.Cells[i + 1, j + 1] = dataGridView1.Rows[i - 1].Cells[j].Value.ToString();
                        }
                        catch (Exception) { }

                    }
                }
                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            String cne = row.Cells[1].Value.ToString();

            //////////////
            int IdEleve;
            ///recuperer le id de l elemP 
            SqlCommand cm1 = new SqlCommand("select id_elemPDG from ElementPDG  where clas='" + clas  + "'", cn);

            
            int IdElmP = (int)cm1.ExecuteScalar();

            //selectionner l'id de l'eleve selectionne
            string listeEleve = "select Id_eleve from Eleves where claS='" + clas + "'and semester='" + semestre + "'";
            
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandText = listeEleve;
            //selectionner les donnees
            SqlDataReader Eleves = command.ExecuteReader();
            liseEleves = new List<string>();
            for (int j = 0; Eleves.Read(); j++)
            {
                liseEleves.Add(Eleves["Id_eleve"].ToString());
            }
            cn.Close();
            for (int i = 0; i < liseEleves.Count; i++)
            {

                
                SqlCommand cm2 = new SqlCommand("select nom,prenom,nomElemPeda,note,res,id_elem_PDG from notes where claS='" + clas + "' and id_eleve='" + liseEleves[i] + "' ", cn);
            cm2.Parameters.AddWithValue("@IdElmP", IdElmP);
            cm2.Parameters.AddWithValue("@IdEleve", IdEleve);


            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.SelectCommand = cm2;
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int IdElmPS = (int)ds.Tables[0].Rows[i][0];
                int sessionS = (int)ds.Tables[0].Rows[i][1];
                SqlCommand c = new SqlCommand("select nomElmP,note from note,elmPedagogique where note.IdEleve=@IdEleve and note.session=@sessionS and note.IdElmP=@IdElmPS and elmPedagogique.IdElmP=@IdElmPS", cn);
                c.Parameters.AddWithValue("@IdElmPS", IdElmPS);
                c.Parameters.AddWithValue("@IdEleve", IdEleve);
                c.Parameters.AddWithValue("@sessionS", sessionS);
                using (SqlDataReader sdr = c.ExecuteReader())
                {

                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        String nomElmP = sdr.GetString(0);
                        float note = sdr.GetFloat(1);
                        string[] roww = new string[] { nomElmP, note.ToString() };
                        dataGridView1.Rows.Add(roww);
                    }
                }

            }
        }
        
    
    private void button2_Click(object sender, EventArgs e)
        {

            
    }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }


