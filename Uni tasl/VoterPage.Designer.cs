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
            this.SuspendLayout();
            // 
            // dropdownVote
            // 
            this.dropdownVote.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropdownVote.FormattingEnabled = true;
            this.dropdownVote.Location = new System.Drawing.Point(40, 81);
            this.dropdownVote.Name = "dropdownVote";
            this.dropdownVote.Size = new System.Drawing.Size(537, 38);
            this.dropdownVote.TabIndex = 0;
            this.dropdownVote.SelectedIndexChanged += new System.EventHandler(this.dropdownVote_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(40, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Voting Page";
            // 
            // voteButton
            // 
            this.voteButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.voteButton.Location = new System.Drawing.Point(40, 127);
            this.voteButton.Name = "voteButton";
            this.voteButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.voteButton.Size = new System.Drawing.Size(75, 34);
            this.voteButton.TabIndex = 2;
            this.voteButton.Text = "Vote";
            this.voteButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Please select below";
            // 
            // VoterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.voteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropdownVote);
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
    }
}