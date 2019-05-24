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

            String query = "SELECT * FROM dbo.notes WHERE claS='GI-3' and semester=" + semestre;


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

            var col3 = new DataGridViewTextBoxColumn();
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


            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { col3, col4, col5, col6 });

            for (int i = 0; d.Read(); i++)
            {
                dataGridView1.Rows.Add();

                dataGridView1.Rows[i].Cells["id_eleve"].Value = d["id_eleve"];

                dataGridView1.Rows[i].Cells["nom"].Value = d["nom"];

                dataGridView1.Rows[i].Cells["prenom"].Value = d["prenom"];

                //  dataGridView1.Rows[i].Cells["filier"].Value = d["claS"];

                dataGridView1.Rows[i].Cells["RESULTA"].Value = d["note"];

            }



            conX.Close();


        }
    }
}
