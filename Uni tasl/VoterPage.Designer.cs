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
            dropdownVote = new ComboBox();
            label1 = new Label();
            voteButton = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // dropdownVote
            // 
            dropdownVote.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            dropdownVote.FormattingEnabled = true;
            dropdownVote.Location = new Point(57, 135);
            dropdownVote.Margin = new Padding(4, 5, 4, 5);
            dropdownVote.Name = "dropdownVote";
            dropdownVote.Size = new Size(766, 53);
            dropdownVote.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(57, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(325, 70);
            label1.TabIndex = 1;
            label1.Text = "Voting Page";
            // 
            // voteButton
            // 
            voteButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            voteButton.Location = new Point(57, 211);
            voteButton.Margin = new Padding(4, 5, 4, 5);
            voteButton.Name = "voteButton";
            voteButton.RightToLeft = RightToLeft.Yes;
            voteButton.Size = new Size(107, 57);
            voteButton.TabIndex = 2;
            voteButton.Text = "Vote";
            voteButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 105);
            label2.Name = "label2";
            label2.Size = new Size(163, 25);
            label2.TabIndex = 3;
            label2.Text = "Please select below";
            // 
            // VoterPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(label2);
            Controls.Add(voteButton);
            Controls.Add(label1);
            Controls.Add(dropdownVote);
            Margin = new Padding(4, 5, 4, 5);
            Name = "VoterPage";
            Text = "VoterPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox dropdownVote;
        private Label label1;
        private Button voteButton;
        private Label label2;
    }
}