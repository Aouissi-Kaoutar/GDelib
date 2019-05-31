using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDelib2._0
{
    public partial class Form1 : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\Documents\GDelibe2.mdf;Integrated Security=True;Connect Timeout=30");

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
    
    public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {



            string textL = textLogin.Text.Trim();
            string textP = textPassword.Text.Trim();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From users where login='" + textLogin.Text + "' and password='" + textPassword.Text + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            try
            {
                if (textL != "" && textP != "")
                {
                    if (dt.Rows.Count > 0)
                    {
                        string s = dt.Rows[0].ItemArray.GetValue(1).ToString();
                      //  MessageBox.Show(s);
                        if (textL.ToString().Equals("ensao"))
                        {
                            admin A = new admin();
                            this.Hide();
                            A.Show();

                        }
                        else
                        {

                            user B = new user();// dt.Rows[0][2].ToString());
                            this.Hide();
                            B.Show();

                        }

                    }
                    else
                    {
                        MessageBox.Show("login ou mot de passe est incorrect");
                    }


                }
                else
                {
                    MessageBox.Show("login ou mot de passe n'existe pas,veuillez le saisir s'il vous plait");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur");
            }
            finally
            {
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            

        }

        private void button6_Click(object sender, EventArgs e)
        {

            string textL = textLogin.Text.Trim();
            string textP = textPassword.Text.Trim();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From users where login='" + textLogin.Text + "' and password='" + textPassword.Text + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            try
            {
                if (textL != "" && textP != "")
                {
                    if (dt.Rows.Count > 0)
                    {
                        string s = dt.Rows[0].ItemArray.GetValue(1).ToString();
                        //  MessageBox.Show(s);
                        if (textL.ToString().Equals("ensao"))
                        {
                             GestiobModule A = new GestiobModule();
                              this.Hide();
                              A.Show();
                            
                        }
                        else
                        {

                            user B = new user();//dt.Rows[0][2].ToString());
                            this.Hide();
                            B.Show();

                        }

                    }
                    else
                    {
                        MessageBox.Show("login ou mot de passe est incorrect");
                    }


                }
                else
                {
                    MessageBox.Show("login ou mot de passe n'existe pas,veuillez le saisir s'il vous plait");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur");
            }
            finally
            {
                con.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login(object sender, EventArgs e)
        {
            if (textLogin.Text == "Login") {

                textLogin.Text = "";
                textLogin.ForeColor = Color.Black;
            };

        }

        private void loginLeave(object sender, EventArgs e)
        {

            if (textLogin.Text == "")
            {

                textLogin.Text = "Login";
                textLogin.ForeColor = Color.FromArgb(9, 9, 9);
            };


        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {
            textPassword.ForeColor = Color.Black;
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (textPassword.Text == "Password")
            {
                textPassword.UseSystemPasswordChar = true;
                textPassword.Text = "";
                textPassword.ForeColor = Color.Black;
               
             
            };


        }

        private void password_leave(object sender, EventArgs e)
        {
/*
            if (textPassword.Text != "Password")
            {
                textPassword.UseSystemPasswordChar = false;
                textPassword.Text = "password";
                textPassword.ForeColor = Color.Silver;}

    */           

            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textLogin_TextChanged(object sender, EventArgs e)
        {
            textLogin.ForeColor = Color.Black;
        }

        private void textLogin_MouseEnter(object sender, EventArgs e)
        {
            textLogin.ForeColor = Color.FromArgb(59, 132, 134);
            textLogin.Font = new Font("Century Gothic", 11, FontStyle.Bold); //"Century Gothic; 11,25pt; style = Italic";

        }

        private void textLogin_MouseLeave(object sender, EventArgs e)
        {
            textLogin.ForeColor = Color.FromArgb(90, 90, 90);
            textLogin.Font = new Font("Century Gothic", 11, FontStyle.Italic); //"Century Gothic; 11,25pt; style = Italic";

        }

        private void textPassword_MouseEnter(object sender, EventArgs e)
        {
            textPassword.ForeColor = Color.FromArgb(59, 132, 134);
            textPassword.Font = new Font("Century Gothic", 11,FontStyle.Bold); //"Century Gothic; 11,25pt; style = Italic";
        }

        private void textPassword_MouseLeave(object sender, EventArgs e)
        {

            textPassword.ForeColor = Color.FromArgb(90, 90, 90);
            textPassword.Font = new Font("Century Gothic",11, FontStyle.Italic);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.PowderBlue;
            button6.ForeColor = Color.FromArgb(80, 80, 80);

        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor =  Color.FromArgb(80, 80, 80);
            button6.ForeColor = Color.Wheat;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackgroundImage = Properties.Resources._22;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackgroundImage = Properties.Resources._12;
        }
    }
}
