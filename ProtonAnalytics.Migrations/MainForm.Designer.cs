namespace ProtonAnalytics.Migrations
{
    partial class MainForm
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
            this.btnRunMigrations = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRunMigrations
            // 
            this.btnRunMigrations.Location = new System.Drawing.Point(12, 12);
            this.btnRunMigrations.Name = "btnRunMigrations";
            this.btnRunMigrations.Size = new System.Drawing.Size(114, 23);
            this.btnRunMigrations.TabIndex = 0;
            this.btnRunMigrations.Text = "Run Migrations";
            this.btnRunMigrations.UseVisualStyleBackColor = true;
            this.btnRunMigrations.Click += new System.EventHandler(this.btnRunMigrations_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(12, 41);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(768, 519);
            this.txtResults.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnRunMigrations);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunMigrations;
        private System.Windows.Forms.TextBox txtResults;
    }
}

