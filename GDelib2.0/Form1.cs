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
                        MessageBox.Show("login ou mot de passe est incorte");
                    }


                }
                else
                {
                    MessageBox.Show("login ou mot de passe nexiste pas,veuiller le saisire  s'il vous plais");
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
                        MessageBox.Show("login ou mot de passe est incorte");
                    }


                }
                else
                {
                    MessageBox.Show("login ou mot de passe nexiste pas,veuiller le saisire  s'il vous plais");
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
                textLogin.ForeColor = Color.Silver;
            };


        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (textLogin.Text == "Password")
            {

                textPassword.Text = "";
                textPassword.ForeColor = Color.Black;
              //  textPassword.UseSystemPasswordChar = true;
            };


        }

        private void password_leave(object sender, EventArgs e)
        {

            if (textLogin.Text == "")
            {

                textPassword.Text = "password";
                textPassword.ForeColor = Color.Silver;
               // textPassword.UseSystemPasswordChar = false;
            };
        }
    }
}
