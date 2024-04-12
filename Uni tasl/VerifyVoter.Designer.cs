namespace Uni_tasl
{
    partial class VerifyVoter
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
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.VerifyedcheckBox = new System.Windows.Forms.CheckBox();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verify Voter";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameBox.Location = new System.Drawing.Point(8, 67);
            this.UsernameBox.Margin = new System.Windows.Forms.Padding(2);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(586, 36);
            this.UsernameBox.TabIndex = 1;
            // 
            // VerifyedcheckBox
            // 
            this.VerifyedcheckBox.AutoSize = true;
            this.VerifyedcheckBox.Location = new System.Drawing.Point(8, 193);
            this.VerifyedcheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.VerifyedcheckBox.Name = "VerifyedcheckBox";
            this.VerifyedcheckBox.Size = new System.Drawing.Size(82, 19);
            this.VerifyedcheckBox.TabIndex = 2;
            this.VerifyedcheckBox.Text = "ID Verifyed";
            this.VerifyedcheckBox.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Location = new System.Drawing.Point(8, 130);
            this.dataGridViewUser.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.RowHeadersWidth = 62;
            this.dataGridViewUser.RowTemplate.Height = 33;
            this.dataGridViewUser.Size = new System.Drawing.Size(518, 44);
            this.dataGridViewUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Results";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(598, 76);
            this.Search.Margin = new System.Windows.Forms.Padding(2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(78, 20);
            this.Search.TabIndex = 6;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 227);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 20);
            this.button2.TabIndex = 7;
            this.button2.Text = "Submitted";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // VerifyVoter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 342);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewUser);
            this.Controls.Add(this.VerifyedcheckBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VerifyVoter";
            this.Text = "VerifyVoter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox UsernameBox;
        private CheckBox VerifyedcheckBox;
        private DataGridView dataGridViewUser;
        private Label label2;
        private Label label3;
        private Button Search;
        private Button button2;
    }
}