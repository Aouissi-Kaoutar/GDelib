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
    public partial class Calcul : Form
    {
       // private object session;

        public Calcul()
        {
            InitializeComponent();
        }
        private float Rechercher_Note_Etudiant(int IdEleve, int IdelmP) //fonction qui permet de retourner la note d'un étudiant donné dans un module donné
        {
            float note = -1;
            //   Program.cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Program.cn;
            cmd.CommandText = "select note from note where IdEleve='" + IdEleve + "' and IdElmP='" + IdelmP + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                note = float.Parse(dr[0].ToString());
            }
            dr.Close();
            // Program.cn.Close();
            return note;
        }
        private int num_module(string nom) //fonction qui permet de retourner le numéro d'un module à partir de son nom
        {
            int num = -1;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Program.cn;
            cmd.CommandText = "select IdElmP from elmPedagogique where nomElmP='" + nom + "'";
            num = int.Parse(cmd.ExecuteScalar().ToString());
            //Program.cn.Close();
            return num;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            //
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Program.cn;
            cmd.CommandText = " Select IdEleve, avg( note) as moy from  ( SELECT n.IdEleve ,  n.note from note n, elmPedagogique e where n.IdElmP = e.IdElmP   and e.Type = 'semiModule' and e.ElmPere = '" + textBox1.Text.ToString() + "' union all SELECT n.IdEleve ,  n.note from note n, elmPedagogique e where n.IdElmP = e.IdElmP   and e.Type = 'semiModule' and e.ElmPere = '" + textBox1.Text.ToString() + "' )s  group by IdEleve";
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(dr);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = t;
            dr.Close();
            int i = 0;

            // Program.cn.Open();

            if (comboBox4.SelectedIndex != -1)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {


                    SqlCommand cmd2 = new SqlCommand("INSERT INTO note VALUES(@idEleve, @IdElmP, @annee, @session , @Note , @res) ", Program.cn);

                    /*****************************************************************/
                    int IdEleve;

                    if (row.Cells["IdEleve"].Value == null)
                    {
                        // MessageBox.Show("insertion des notes effectuer avec succes / verfier que tous les donnees  des etudiants inserés sont valides !!", "champ invalide", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                        break;

                    }

                    StringBuilder output = new StringBuilder();
                    output.AppendFormat("{0} ", row.Cells["IdEleve"].Value);
                    output.AppendLine();
                    IdEleve = int.Parse(output.ToString());


                    cmd2.Parameters.AddWithValue("@IdEleve", IdEleve);
                    /********************************************************************/
                    if (comboBox4.SelectedIndex == -1)
                    {
                        Program.cn.Dispose();
                        MessageBox.Show("Numéro Module invalide!!", "invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    // StringBuilder output2 = new StringBuilder();
                    // output.AppendFormat("{0} ", combomodule.SelectedItem.ToString());
                    // output.AppendLine();
                    int idElm = int.Parse(textBox1.Text);

                    cmd2.Parameters.AddWithValue("@IdElmP", idElm);
                    /**************************************************************/
                    cmd2.Parameters.AddWithValue("@annee", comboBox1.SelectedItem.ToString());
                    /**************************************************************/
                    if (radioButton1.Checked) { cmd2.Parameters.AddWithValue("@session", 0); }
                    else if (radioButton2.Checked) { cmd2.Parameters.AddWithValue("@session", 1); }
                    else
                    {

                        MessageBox.Show("exception :Attention vous deviez specifier une session ", "avertissement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    /**********************************************************/
                    float note;
                    if (float.TryParse(row.Cells["moy"].Value.ToString(), out note) == false)
                    {
                        MessageBox.Show("Champ Note invalide!!", "champ invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else if (note < 0 || note > 20)
                    { MessageBox.Show("Champ Note invalide!!", "champ invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (Rechercher_Note_Etudiant(IdEleve, num_module(comboBox4.SelectedItem.ToString())) != -1) //vérification de l'existence de la note
                    {

                        MessageBox.Show("Note déja attribuée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                    else { cmd2.Parameters.AddWithValue("@Note", row.Cells["moy"].Value); }
                    /*****************************************************/

                    if (note >= 12 && note <= 20) { cmd2.Parameters.AddWithValue("@res", "validé"); }
                    else if (note <= 12 && note >= 0) { cmd2.Parameters.AddWithValue("@res", "non validé"); }
                    else cmd2.Parameters.AddWithValue("@res", "NULL");



                    cmd2.ExecuteNonQuery();
                    i++;
                }
                fillcombo2();
            }
            else
            {
                MessageBox.Show("Veuillez choisir un module");
            }

            // fillcombo2();
            MessageBox.Show("" + i + " \t notes inserés , vous pouvez effectuer une modification individuale des notes  .");
            //
        }

        void fillcombo2()
        {

            dataGridView1.Visible = true;
            //panel5.Visible = false;

            SqlCommand cmidmodule = new SqlCommand();
            cmidmodule.CommandText = " SELECT IdElmP from elmPedagogique where nomElmP= '" + comboBox4.Text.ToString() + "'";
            cmidmodule.Connection = Program.cn;
            int idModule = int.Parse(cmidmodule.ExecuteScalar().ToString());
            textBox1.Text = idModule.ToString();
            if ((comboBox4.SelectedItem != null))
            {
                String elmP = comboBox4.SelectedItem.ToString();

                SqlCommand cm1 = new SqlCommand("select IdElmP from elmPedagogique where nomElmP=@nom ", Program.cn);

                cm1.Parameters.AddWithValue("@nom", elmP);
                int IdElmP = (int)cm1.ExecuteScalar();
                SqlCommand cm2 = new SqlCommand("select nApogee,CNE,Nom,Prenom,note,resultat from eleve,note,elmPedagogique where note.IdElmP=@IdElmP and note.session=@session and elmPedagogique.IdElmP=@IdElmP and eleve.IdEleve = note.IdEleve", Program.cn);
                //SqlCommand cm2 = new SqlCommand("select note as noteModule from note where IdElmP=?", cn);
                cm2.Parameters.AddWithValue("@IdElmP", IdElmP);
               // cm2.Parameters.AddWithValue("@session", session);
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.SelectCommand = cm2;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                dataGridView1.DataSource = bsource;
                dataGridView1.AutoGenerateColumns = false;
                sda.Update(dt);
                //Program.cn.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
    }
