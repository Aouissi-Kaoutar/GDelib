using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDelib2._0
{
    public partial class DB : Form
    {
        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");
        public string query;
        public string SupretionQuery;
        public DB(string s,string k)
        {
            InitializeComponent();
            this.query = s;
            this.SupretionQuery = k;
        }

        private void DB_Load(object sender, EventArgs e)
        {
            // con.ConnectionString = conX;
            g();
        }
        public void g()
        {
            conX.Open();
            SqlCommand cmd = new SqlCommand(query, conX);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conX.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voulez vous vrement suprimer la base de donne des Eleves ");
            conX.Open();
             SqlCommand cmd = new SqlCommand(SupretionQuery, conX);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();

             da.Fill(ds);
         //    dataGridView1.DataSource = ds.Tables[0];
             conX.Close();
            //dataGridView1.Refresh();
            g();
            MessageBox.Show("Supretion bient efectuer");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
