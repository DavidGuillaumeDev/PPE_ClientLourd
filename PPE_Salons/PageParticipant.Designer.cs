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
            this.label1.Location = new System.Drawing.Point(17, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // Prenom
            // 
            this.Prenom.AutoSize = true;
            this.Prenom.Location = new System.Drawing.Point(21, 110);
            this.Prenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Prenom.Name = "Prenom";
            this.Prenom.Size = new System.Drawing.Size(57, 17);
            this.Prenom.TabIndex = 1;
            this.Prenom.Text = "Prénom";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(111, 55);
            this.tbNom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(333, 22);
            this.tbNom.TabIndex = 2;
            // 
            // tbPrenom
            // 
            this.tbPrenom.Location = new System.Drawing.Point(111, 110);
            this.tbPrenom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPrenom.Name = "tbPrenom";
            this.tbPrenom.Size = new System.Drawing.Size(333, 22);
            this.tbPrenom.TabIndex = 3;
            // 
            // Enregistrer
            // 
            this.Enregistrer.Location = new System.Drawing.Point(345, 240);
            this.Enregistrer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Enregistrer.Name = "Enregistrer";
            this.Enregistrer.Size = new System.Drawing.Size(100, 28);
            this.Enregistrer.TabIndex = 4;
            this.Enregistrer.Text = "Enregistrer";
            this.Enregistrer.UseVisualStyleBackColor = true;
            this.Enregistrer.Click += new System.EventHandler(this.Enregistrer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 240);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Badge";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(21, 171);
            this.email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(41, 17);
            this.email.TabIndex = 6;
            this.email.Text = "email";
            // 
            // tbemail
            // 
            this.tbemail.Location = new System.Drawing.Point(111, 171);
            this.tbemail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbemail.Name = "tbemail";
            this.tbemail.Size = new System.Drawing.Size(333, 22);
            this.tbemail.TabIndex = 7;
            // 
            // Error1
            // 
            this.Error1.AutoSize = true;
            this.Error1.Location = new System.Drawing.Point(133, 86);
            this.Error1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error1.Name = "Error1";
            this.Error1.Size = new System.Drawing.Size(48, 17);
            this.Error1.TabIndex = 8;
            this.Error1.Text = "Error1";
            // 
            // Error2
            // 
            this.Error2.AutoSize = true;
            this.Error2.Location = new System.Drawing.Point(133, 138);
            this.Error2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error2.Name = "Error2";
            this.Error2.Size = new System.Drawing.Size(48, 17);
            this.Error2.TabIndex = 9;
            this.Error2.Text = "Error2";
            // 
            // Error3
            // 
            this.Error3.AutoSize = true;
            this.Error3.Location = new System.Drawing.Point(133, 199);
            this.Error3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error3.Name = "Error3";
            this.Error3.Size = new System.Drawing.Size(48, 17);
            this.Error3.TabIndex = 10;
            this.Error3.Text = "Error3";
            // 
            // PageParticipant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 336);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PageParticipant";
            this.Text = "Détails Participant";
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