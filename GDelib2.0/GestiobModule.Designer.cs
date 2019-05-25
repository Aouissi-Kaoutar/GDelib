namespace GDelib2._0
{
    partial class GestiobModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestiobModule));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.button2 = new System.Windows.Forms.Button();
            this.configurationFilier3 = new GDelib2._0.configurationFilier();
            this.collecteNotes1 = new GDelib2._0.collecteNotes();
            this.configurationFilier2 = new GDelib2._0.configurationFilier();
            this.configurationFilier1 = new GDelib2._0.configurationFilier();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.configurationFilier2);
            this.panel1.Controls.Add(this.configurationFilier1);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 624);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel10
            // 
            this.panel10.Location = new System.Drawing.Point(3, 293);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(11, 64);
            this.panel10.TabIndex = 30;
            // 
            // panel9
            // 
            this.panel9.Location = new System.Drawing.Point(3, 216);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(11, 63);
            this.panel9.TabIndex = 30;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(3, 138);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(11, 63);
            this.panel8.TabIndex = 29;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(37, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 92);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Black;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(58)))), ((int)(((byte)(57)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(16, 293);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(177, 64);
            this.button7.TabIndex = 6;
            this.button7.Text = "    Déliberation";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Black;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(58)))), ((int)(((byte)(57)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(16, 216);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(177, 62);
            this.button6.TabIndex = 5;
            this.button6.Text = "   Collecte des notes";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(58)))), ((int)(((byte)(57)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(16, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = " Configuration  filiére";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(1181, -8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 44);
            this.button2.TabIndex = 5;
            this.button2.Text = "x";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            this.button2.Enter += new System.EventHandler(this.close_Enter);
            this.button2.Leave += new System.EventHandler(this.close_leave);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // configurationFilier3
            // 
            this.configurationFilier3.Location = new System.Drawing.Point(195, 43);
            this.configurationFilier3.Margin = new System.Windows.Forms.Padding(21, 21, 21, 21);
            this.configurationFilier3.Name = "configurationFilier3";
            this.configurationFilier3.Size = new System.Drawing.Size(5852, 3153);
            this.configurationFilier3.TabIndex = 6;
            // 
            // collecteNotes1
            // 
            this.collecteNotes1.Location = new System.Drawing.Point(195, 34);
            this.collecteNotes1.Margin = new System.Windows.Forms.Padding(276, 228, 276, 228);
            this.collecteNotes1.Name = "collecteNotes1";
            this.collecteNotes1.Size = new System.Drawing.Size(6015, 3220);
            this.collecteNotes1.TabIndex = 2;
            this.collecteNotes1.Load += new System.EventHandler(this.collecteNotes1_Load);
            // 
            // configurationFilier2
            // 
            this.configurationFilier2.Location = new System.Drawing.Point(809, 5465);
            this.configurationFilier2.Margin = new System.Windows.Forms.Padding(155, 133, 155, 133);
            this.configurationFilier2.Name = "configurationFilier2";
            this.configurationFilier2.Size = new System.Drawing.Size(17620, 8649);
            this.configurationFilier2.TabIndex = 3;
            // 
            // configurationFilier1
            // 
            this.configurationFilier1.Location = new System.Drawing.Point(8241, 467);
            this.configurationFilier1.Margin = new System.Windows.Forms.Padding(155, 133, 155, 133);
            this.configurationFilier1.Name = "configurationFilier1";
            this.configurationFilier1.Size = new System.Drawing.Size(41644, 19253);
            this.configurationFilier1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(29)))), ((int)(((byte)(47)))));
            this.panel2.Location = new System.Drawing.Point(0, 559);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1239, 137);
            this.panel2.TabIndex = 7;
            // 
            // GestiobModule
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::GDelib2._0.Properties.Resources.pf_1558798470;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1220, 626);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.configurationFilier3);
            this.Controls.Add(this.collecteNotes1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestiobModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admin";
            this.Load += new System.EventHandler(this.GestiobModule_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button button7;
            private System.Windows.Forms.Button button6;
            private System.Windows.Forms.PictureBox pictureBox1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
       // private acceuilCntrol acceuilCntrol1;
        private configurationFilier configurationFilier1;
        private collecteNotes collecteNotes1;
        private configurationFilier configurationFilier2;
        private System.Windows.Forms.Button button2;
        private configurationFilier configurationFilier3;
        private System.Windows.Forms.Panel panel2;
    }
    }