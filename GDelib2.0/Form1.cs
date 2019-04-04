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
    public partial class Form1 : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=KAWTAR\SQLEXPRESS04;Initial Catalog=GDeleb2.0;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
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
                            user B = new user();
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
    }
}
