namespace PPE_Salons
{
    partial class PageParticipant
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
            this.label1 = new System.Windows.Forms.Label();
            this.Prenom = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbPrenom = new System.Windows.Forms.TextBox();
            this.Enregistrer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.Label();
            this.tbemail = new System.Windows.Forms.TextBox();
            this.Error1 = new System.Windows.Forms.Label();
            this.Error2 = new System.Windows.Forms.Label();
            this.Error3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // Prenom
            // 
            this.Prenom.AutoSize = true;
            this.Prenom.Location = new System.Drawing.Point(16, 89);
            this.Prenom.Name = "Prenom";
            this.Prenom.Size = new System.Drawing.Size(43, 13);
            this.Prenom.TabIndex = 1;
            this.Prenom.Text = "Prénom";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(83, 45);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(251, 20);
            this.tbNom.TabIndex = 2;
            // 
            // tbPrenom
            // 
            this.tbPrenom.Location = new System.Drawing.Point(83, 89);
            this.tbPrenom.Name = "tbPrenom";
            this.tbPrenom.Size = new System.Drawing.Size(251, 20);
            this.tbPrenom.TabIndex = 3;
            // 
            // Enregistrer
            // 
            this.Enregistrer.Location = new System.Drawing.Point(259, 195);
            this.Enregistrer.Name = "Enregistrer";
            this.Enregistrer.Size = new System.Drawing.Size(75, 23);
            this.Enregistrer.TabIndex = 4;
            this.Enregistrer.Text = "Enregistrer";
            this.Enregistrer.UseVisualStyleBackColor = true;
            this.Enregistrer.Click += new System.EventHandler(this.Enregistrer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Badge";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(16, 139);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(31, 13);
            this.email.TabIndex = 6;
            this.email.Text = "email";
            // 
            // tbemail
            // 
            this.tbemail.Location = new System.Drawing.Point(83, 139);
            this.tbemail.Name = "tbemail";
            this.tbemail.Size = new System.Drawing.Size(251, 20);
            this.tbemail.TabIndex = 7;
            // 
            // Error1
            // 
            this.Error1.AutoSize = true;
            this.Error1.Location = new System.Drawing.Point(100, 70);
            this.Error1.Name = "Error1";
            this.Error1.Size = new System.Drawing.Size(35, 13);
            this.Error1.TabIndex = 8;
            this.Error1.Text = "Error1";
            // 
            // Error2
            // 
            this.Error2.AutoSize = true;
            this.Error2.Location = new System.Drawing.Point(100, 112);
            this.Error2.Name = "Error2";
            this.Error2.Size = new System.Drawing.Size(35, 13);
            this.Error2.TabIndex = 9;
            this.Error2.Text = "Error2";
            // 
            // Error3
            // 
            this.Error3.AutoSize = true;
            this.Error3.Location = new System.Drawing.Point(100, 162);
            this.Error3.Name = "Error3";
            this.Error3.Size = new System.Drawing.Size(35, 13);
            this.Error3.TabIndex = 10;
            this.Error3.Text = "Error3";
            // 
            // PageParticipant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 273);
            this.Controls.Add(this.Error3);
            this.Controls.Add(this.Error2);
            this.Controls.Add(this.Error1);
            this.Controls.Add(this.tbemail);
            this.Controls.Add(this.email);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Enregistrer);
            this.Controls.Add(this.tbPrenom);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.Prenom);
            this.Controls.Add(this.label1);
            this.Name = "PageParticipant";
            this.Text = "PageParticipant";
            this.Load += new System.EventHandler(this.PageParticipant_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Prenom;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.TextBox tbPrenom;
        private System.Windows.Forms.Button Enregistrer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.TextBox tbemail;
        private System.Windows.Forms.Label Error1;
        private System.Windows.Forms.Label Error2;
        private System.Windows.Forms.Label Error3;
    }
}