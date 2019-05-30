namespace GDelib2._0
{
    partial class dbEleve
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbEleve));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id_eleve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nappoge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_naissance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_eleve,
            this.nom,
            this.prenom,
            this.filier,
            this.cne,
            this.Nappoge,
            this.semester,
            this.date_naissance,
            this.email,
            this.column});
            this.dataGridView1.Location = new System.Drawing.Point(1, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(952, 482);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Id_eleve
            // 
            this.Id_eleve.HeaderText = "Id_eleve";
            this.Id_eleve.Name = "Id_eleve";
            // 
            // nom
            // 
            this.nom.HeaderText = "nom";
            this.nom.Name = "nom";
            // 
            // prenom
            // 
            this.prenom.HeaderText = "prenom";
            this.prenom.Name = "prenom";
            // 
            // filier
            // 
            this.filier.HeaderText = "filier";
            this.filier.Name = "filier";
            // 
            // cne
            // 
            this.cne.HeaderText = "cne";
            this.cne.Name = "cne";
            // 
            // Nappoge
            // 
            this.Nappoge.HeaderText = "Nappoge";
            this.Nappoge.Name = "Nappoge";
            // 
            // semester
            // 
            this.semester.HeaderText = "semester";
            this.semester.Name = "semester";
            // 
            // date_naissance
            // 
            this.date_naissance.HeaderText = "date_naissance";
            this.date_naissance.Name = "date_naissance";
            // 
            // email
            // 
            this.email.HeaderText = "email";
            this.email.Name = "email";
            // 
            // column
            // 
            this.column.HeaderText = "";
            this.column.Name = "column";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.PowderBlue;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(846, 599);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 48);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(278, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Les Listes de Base de Donne";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 39);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dbEleve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(951, 670);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dbEleve";
            this.Text = "DB";
            this.Load += new System.EventHandler(this.DB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_eleve;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn filier;
        private System.Windows.Forms.DataGridViewTextBoxColumn cne;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nappoge;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_naissance;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn column;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}