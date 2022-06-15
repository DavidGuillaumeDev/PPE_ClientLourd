
namespace PPE_Salons
{
    partial class PageUtilisateur
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
            this.Enregistrer = new System.Windows.Forms.Button();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.Prenom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNiveau = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Enregistrer
            // 
            this.Enregistrer.Location = new System.Drawing.Point(370, 230);
            this.Enregistrer.Margin = new System.Windows.Forms.Padding(4);
            this.Enregistrer.Name = "Enregistrer";
            this.Enregistrer.Size = new System.Drawing.Size(100, 28);
            this.Enregistrer.TabIndex = 15;
            this.Enregistrer.Text = "Enregistrer";
            this.Enregistrer.UseVisualStyleBackColor = true;
            this.Enregistrer.Click += new System.EventHandler(this.Enregistrer_Click);
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(137, 65);
            this.tbNom.Margin = new System.Windows.Forms.Padding(4);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(333, 22);
            this.tbNom.TabIndex = 13;
            // 
            // Prenom
            // 
            this.Prenom.AutoSize = true;
            this.Prenom.Location = new System.Drawing.Point(46, 122);
            this.Prenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Prenom.Name = "Prenom";
            this.Prenom.Size = new System.Drawing.Size(52, 17);
            this.Prenom.TabIndex = 12;
            this.Prenom.Text = "Niveau";
            this.Prenom.Click += new System.EventHandler(this.Prenom_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nom";
            // 
            // comboBoxNiveau
            // 
            this.comboBoxNiveau.FormattingEnabled = true;
            this.comboBoxNiveau.Location = new System.Drawing.Point(136, 122);
            this.comboBoxNiveau.Name = "comboBoxNiveau";
            this.comboBoxNiveau.Size = new System.Drawing.Size(333, 24);
            this.comboBoxNiveau.TabIndex = 21;
            // 
            // PageUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 308);
            this.Controls.Add(this.comboBoxNiveau);
            this.Controls.Add(this.Enregistrer);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.Prenom);
            this.Controls.Add(this.label1);
            this.Name = "PageUtilisateur";
            this.Text = "Détails Utilisateur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Enregistrer;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label Prenom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxNiveau;
    }
}