namespace Uni_tasl
{
    partial class VoterPage
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
            this.dropdownVote = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.voteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DisplayName = new System.Windows.Forms.Label();
            this.logOutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dropdownVote
            // 
            this.dropdownVote.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropdownVote.FormattingEnabled = true;
            this.dropdownVote.Location = new System.Drawing.Point(46, 143);
            this.dropdownVote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dropdownVote.Name = "dropdownVote";
            this.dropdownVote.Size = new System.Drawing.Size(613, 45);
            this.dropdownVote.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(46, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "Voting Page";
            // 
            // voteButton
            // 
            this.voteButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.voteButton.Location = new System.Drawing.Point(46, 201);
            this.voteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.voteButton.Name = "voteButton";
            this.voteButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.voteButton.Size = new System.Drawing.Size(86, 45);
            this.voteButton.TabIndex = 2;
            this.voteButton.Text = "Vote";
            this.voteButton.UseVisualStyleBackColor = true;
            this.voteButton.Click += new System.EventHandler(this.voteButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Please select below";
            // 
            // DisplayName
            // 
            this.DisplayName.AutoSize = true;
            this.DisplayName.Location = new System.Drawing.Point(46, 81);
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Size = new System.Drawing.Size(50, 20);
            this.DisplayName.TabIndex = 4;
            this.DisplayName.Text = "label3";
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(808, 12);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(94, 29);
            this.logOutButton.TabIndex = 5;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // VoterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.DisplayName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.voteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropdownVote);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VoterPage";
            this.Text = "VoterPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox dropdownVote;
        private Label label1;
        private Button voteButton;
        private Label label2;
        private Label DisplayName;
        private Button logOutButton;
    }
}