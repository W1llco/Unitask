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
            this.dg_Regions = new System.Windows.Forms.DataGridView();
            this.dg_Partys = new System.Windows.Forms.DataGridView();
            this.sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginFromHomeButton = new System.Windows.Forms.Button();
            this.LoginFromBoothButton = new System.Windows.Forms.Button();
            this.LoginAsAdminButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Regions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Partys)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Regions
            // 
            this.dg_Regions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Regions.Location = new System.Drawing.Point(557, 288);
            this.dg_Regions.Name = "dg_Regions";
            this.dg_Regions.RowTemplate.Height = 25;
            this.dg_Regions.Size = new System.Drawing.Size(240, 150);
            this.dg_Regions.TabIndex = 0;
            
            this.dg_Partys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Partys.Location = new System.Drawing.Point(450, 400);
            this.dg_Partys.Name = "dg_Partys";
            this.dg_Partys.RowTemplate.Height = 25;
            this.dg_Partys.Size = new System.Drawing.Size(240, 150);
            this.dg_Partys.TabIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(168, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to the voting system";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.LoginAsAdminButton);
            this.Controls.Add(this.LoginFromBoothButton);
            this.Controls.Add(this.LoginFromHomeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_Regions);
            this.Controls.Add(this.dg_Partys);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dg_Regions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Partys)).EndInit();
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
    }
}
