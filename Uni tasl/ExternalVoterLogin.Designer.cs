namespace Uni_tasl
{
    partial class ExternalVoterLogin
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
            this.Login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.DOBlabel = new System.Windows.Forms.Label();
            this.DobDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(20, 249);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 10;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(22, 103);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 23);
            this.PasswordTextBox.TabIndex = 8;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(22, 29);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(39, 15);
            this.UsernameLabel.TabIndex = 7;
            this.UsernameLabel.Text = "Name";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(22, 47);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(100, 23);
            this.UsernameTextBox.TabIndex = 6;
            // 
            // DOBlabel
            // 
            this.DOBlabel.AutoSize = true;
            this.DOBlabel.Location = new System.Drawing.Point(22, 139);
            this.DOBlabel.Name = "DOBlabel";
            this.DOBlabel.Size = new System.Drawing.Size(73, 15);
            this.DOBlabel.TabIndex = 12;
            this.DOBlabel.Text = "Date of Birth";
            // 
            // DobDateTimePicker
            // 
            this.DobDateTimePicker.Location = new System.Drawing.Point(22, 157);
            this.DobDateTimePicker.Name = "DobDateTimePicker";
            this.DobDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.DobDateTimePicker.TabIndex = 14;
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.Location = new System.Drawing.Point(20, 208);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(100, 23);
            this.CodeTextBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "One time code";
            // 
            // ExternalVoterLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CodeTextBox);
            this.Controls.Add(this.DobDateTimePicker);
            this.Controls.Add(this.DOBlabel);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Name = "ExternalVoterLogin";
            this.Text = "ExternalVoterLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Login;
        private Label label2;
        private TextBox PasswordTextBox;
        private Label UsernameLabel;
        private TextBox UsernameTextBox;
        private Label DOBlabel;
        private DateTimePicker DobDateTimePicker;
        private TextBox CodeTextBox;
        private Label label1;
    }
}