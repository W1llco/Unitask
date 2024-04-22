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
            this.NameBox = new System.Windows.Forms.TextBox();
            this.VerifyedcheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewVoters = new System.Windows.Forms.DataGridView();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoters)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verify Voter";
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameBox.Location = new System.Drawing.Point(9, 89);
            this.NameBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(669, 43);
            this.NameBox.TabIndex = 1;
            // 
            // VerifyedcheckBox
            // 
            this.VerifyedcheckBox.AutoSize = true;
            this.VerifyedcheckBox.Location = new System.Drawing.Point(13, 384);
            this.VerifyedcheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.VerifyedcheckBox.Name = "VerifyedcheckBox";
            this.VerifyedcheckBox.Size = new System.Drawing.Size(104, 24);
            this.VerifyedcheckBox.TabIndex = 2;
            this.VerifyedcheckBox.Text = "ID Verifyed";
            this.VerifyedcheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Results";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(683, 101);
            this.Search.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(89, 27);
            this.Search.TabIndex = 6;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 415);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 27);
            this.button2.TabIndex = 7;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewVoters
            // 
            this.dataGridViewVoters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVoters.Location = new System.Drawing.Point(9, 172);
            this.dataGridViewVoters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewVoters.Name = "dataGridViewVoters";
            this.dataGridViewVoters.RowHeadersWidth = 51;
            this.dataGridViewVoters.RowTemplate.Height = 25;
            this.dataGridViewVoters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVoters.Size = new System.Drawing.Size(763, 205);
            this.dataGridViewVoters.TabIndex = 8;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(678, 138);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(94, 29);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // VerifyVoter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 456);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.dataGridViewVoters);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VerifyedcheckBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "VerifyVoter";
            this.Text = "VerifyVoter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox UsernameBox;
        private CheckBox VerifyedcheckBox;
        private Label label2;
        private Label label3;
        private Button Search;
        private Button button2;
        private TextBox NameBox;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridViewVoters;
        private Button refreshButton;
    }
}