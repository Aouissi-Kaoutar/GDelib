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

namespace GDelib2._0
{
    public partial class pvSEM : Form
    {
        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        List<string> listModule;
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

        private void pvSEM_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 20;
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

            String query = "SELECT * FROM dbo.notes WHERE claS='"+clas+"'and semester=" + semestre;

            try { 
            conX.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = conX;
            command.CommandText = query;

            SqlDataReader d = command.ExecuteReader();

                /* DataTable dt = new DataTable();
                 dt.Columns.Add(new DataColumn("id_eleve", typeof(string)));
                 dt.Columns.Add(new DataColumn("nom", typeof(string)));
                 dt.Columns.Add(new DataColumn("prenom", typeof(string)));
                 dt.Columns.Add(new DataColumn("RESULTA", typeof(string)));
                 dataGridView1.DataSource = dt;*/

                /*  var col3 = new DataGridViewTextBoxColumn();
                  var col4 = new DataGridViewCheckBoxColumn();
                  var col5 = new DataGridViewTextBoxColumn();
                  var col6 = new DataGridViewCheckBoxColumn();

                  col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                  col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                  col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                  col6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

                  col3.HeaderText = "id_eleve";
                  col3.Name = "id_eleve";

                  col4.HeaderText = "nom";
                  col4.Name = "nom";

                  col5.HeaderText = "prenom";
                  col5.Name = "prenom";

                  col6.HeaderText = "RESULTA";
                  col6.Name = "RESULTA";


                  dataGridView1.Columns.AddRange(new DataGridViewColumn[] { col3, col4, col5, col6 });*/

                /* for (int i = 0; d.Read(); i++)
                 {
                     dataGridView1.Rows.Add();

                     dataGridView1.Rows[i].Cells["id_eleve"].Value = d["id_eleve"];

                     dataGridView1.Rows[i].Cells["nom"].Value = d["nom"];

                     dataGridView1.Rows[i].Cells["prenom"].Value = d["prenom"];

                     //  dataGridView1.Rows[i].Cells["filier"].Value = d["claS"];

                     dataGridView1.Rows[i].Cells["RESULTA"].Value = d["note"];

                 }*/
                dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight * 2;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
                dataGridView1.Paint += new PaintEventHandler(dataDridView1_Paint);
                dataGridView1.Scroll += new ScrollEventHandler(dataDridView1_Scroll);
                dataGridView1.ColumnWidthChanged +=new DataGridViewColumnEventHandler(dataGridView1_ColumnWhidthChanged);



            }
                 catch(Exception exp)
                 {
                     MessageBox.Show("manque un champ\n \n \n" + exp.Message);
                 }



                 conX.Close();

         


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





            string query2 = "select * from ElementPDG where clas='" + clas + "'and semestre='" + semestre + "'";

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conX;
                command.CommandText = query2;
                conX.Open();
                SqlDataReader d2 = command.ExecuteReader();
                for (int i = 0; d2.Read(); i++)
                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i].Cells["id_eleve"].Value = d2["id_eleve"];

                    dataGridView1.Rows[i].Cells["nom"].Value = d2["nom"];

                   
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
    }
}
