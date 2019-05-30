using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDelib2._0
{
    public partial class GestiobModule : Form
    {
        public OpenFileDialog ofd;
        string semestre;
        string clas;


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

        // public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");


        public SqlConnection conX = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");

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
        public GestiobModule()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ListeEtd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            


            configurationFilier1.Hide();
            this.BackgroundImage = null;
            collecteNotes1.Show();



            button6.BackColor = Color.FromArgb(2, 127, 143);
            button1.BackColor = Color.PowderBlue;
            button3.BackColor = Color.PowderBlue;

            panel9.BackColor = Color.FromArgb(80, 80, 80);
            panel3.BackColor = Color.FromArgb(128, 228, 228);
            panel8.BackColor = Color.FromArgb(228, 228, 228);


        }

        private void button12_Click(object sender, EventArgs e)
        {
           

        }

        private void button11_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
          
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel2.Show();
            configurationFilier1.Hide();
           // this.BackgroundImage = Properties.Resources.Sans_titre;
            collecteNotes1.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            configurationFilier1.Show();
            this.BackgroundImage = null;
            collecteNotes1.Hide();

            button1.BackColor = Color.FromArgb(2, 127, 143);
            button3.BackColor = Color.PowderBlue;
            button6.BackColor = Color.PowderBlue;

            panel8.BackColor = Color.FromArgb(80, 80, 80);
            panel9.BackColor = Color.FromArgb(128, 228, 228);
            panel3.BackColor = Color.FromArgb(228, 228, 228);
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

           

        }

        private void button9_Click_1(object sender, EventArgs e)
        {  }

        private void button8_Click_1(object sender, EventArgs e)
        {
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void f()
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            semestre = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            semestre = "2";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
           
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
              //  Form2 c = new Form2(comboBox2.SelectedItem.ToString(), ofd);
              //  c.Show();
            }
            catch (System.NullReferenceException eee)
            {
                MessageBox.Show("manque un champ\n \n \n" + eee.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            configurationFilier1.Hide();
            this.BackgroundImage = null;
           new Diplome().Show();
            
           

            button3.BackColor = Color.FromArgb(2, 127, 143);
            button1.BackColor = Color.PowderBlue;
            button6.BackColor = Color.PowderBlue;
         
            panel3.BackColor = Color.FromArgb(80, 80, 80);
            panel9.BackColor = Color.FromArgb(128, 228, 228);
            panel8.BackColor = Color.FromArgb(228, 228, 228);
        }

        private void GestiobModule_Load(object sender, EventArgs e)
        {
            configurationFilier1.Hide();
            collecteNotes1.Hide();
        }

        private void acceuilCntrol1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_Enter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(215, 4, 51);
        }

        private void close_leave(object sender, EventArgs e)
        {
            button2.BackColor = Color.PowderBlue;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

            button2.BackColor = Color.FromArgb(215, 4, 51);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {

            button2.BackColor = Color.PowderBlue;
        }

        private void collecteNotes1_Load(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void configurationFilier1_Load(object sender, EventArgs e)
        {

        }

        private void collecteNotes1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
