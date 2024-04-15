namespace Uni_tasl
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginFromHomeButton = new System.Windows.Forms.Button();
            this.LoginFromBoothButton = new System.Windows.Forms.Button();
            this.LoginAsAdminButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sqliteCommand1
            // 
            this.sqliteCommand1.CommandTimeout = 30;
            this.sqliteCommand1.Connection = null;
            this.sqliteCommand1.Transaction = null;
            this.sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to the voting system ";
            // 
            // LoginFromHomeButton
            // 
            this.LoginFromHomeButton.Location = new System.Drawing.Point(52, 62);
            this.LoginFromHomeButton.Name = "LoginFromHomeButton";
            this.LoginFromHomeButton.Size = new System.Drawing.Size(141, 23);
            this.LoginFromHomeButton.TabIndex = 2;
            this.LoginFromHomeButton.Text = "Login From Home";
            this.LoginFromHomeButton.UseVisualStyleBackColor = true;
            this.LoginFromHomeButton.Click += new System.EventHandler(this.LoginFromHomeButton_Click);
            // 
            // LoginFromBoothButton
            // 
            this.LoginFromBoothButton.Location = new System.Drawing.Point(208, 62);
            this.LoginFromBoothButton.Name = "LoginFromBoothButton";
            this.LoginFromBoothButton.Size = new System.Drawing.Size(126, 23);
            this.LoginFromBoothButton.TabIndex = 3;
            this.LoginFromBoothButton.Text = "Login From Booth";
            this.LoginFromBoothButton.UseVisualStyleBackColor = true;
            this.LoginFromBoothButton.Click += new System.EventHandler(this.LoginFromBoothButton_Click);
            // 
            // LoginAsAdminButton
            // 
            this.LoginAsAdminButton.Location = new System.Drawing.Point(358, 62);
            this.LoginAsAdminButton.Name = "LoginAsAdminButton";
            this.LoginAsAdminButton.Size = new System.Drawing.Size(110, 23);
            this.LoginAsAdminButton.TabIndex = 4;
            this.LoginAsAdminButton.Text = "Login As Admin";
            this.LoginAsAdminButton.UseVisualStyleBackColor = true;
            this.LoginAsAdminButton.Click += new System.EventHandler(this.LoginAsAdminButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please Select one of the login in Options";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginAsAdminButton);
            this.Controls.Add(this.LoginFromBoothButton);
            this.Controls.Add(this.LoginFromHomeButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dg_Regions;
        private DataGridView dg_Partys;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private Label label1;
        private Button LoginFromHomeButton;
        private Button LoginFromBoothButton;
        private Button LoginAsAdminButton;
        private Label label2;
    }
}
