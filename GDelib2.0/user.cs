using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDelib2._0
{
    public partial class user : Form
    {
        
        public user()
        {
            InitializeComponent();
            
        }
        public user(string s)
        {
            InitializeComponent();

            label4.Text = s;

            ListeEtd.Hide();
            acceuil.Show();
        }


        private void user_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

            ListeEtd.Show();
            acceuil.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
