namespace Uni_tasl
{
    partial class ModifyElection
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
            this.electionName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.countElectionButton = new System.Windows.Forms.Button();
            this.startTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.finishTimePicker = new System.Windows.Forms.DateTimePicker();
            this.votingSystemComboBox = new System.Windows.Forms.ComboBox();
            this.modifyButton = new System.Windows.Forms.Button();
            this.winnerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // electionName
            // 
            this.electionName.AutoSize = true;
            this.electionName.Location = new System.Drawing.Point(32, 19);
            this.electionName.Name = "electionName";
            this.electionName.Size = new System.Drawing.Size(84, 15);
            this.electionName.TabIndex = 0;
            this.electionName.Text = "Election Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Winner:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Voting System:";
            // 
            // countElectionButton
            // 
            this.countElectionButton.Location = new System.Drawing.Point(113, 173);
            this.countElectionButton.Name = "countElectionButton";
            this.countElectionButton.Size = new System.Drawing.Size(117, 23);
            this.countElectionButton.TabIndex = 7;
            this.countElectionButton.Text = "Count Election";
            this.countElectionButton.UseVisualStyleBackColor = true;
            // 
            // startTimePicker1
            // 
            this.startTimePicker1.Location = new System.Drawing.Point(143, 44);
            this.startTimePicker1.Name = "startTimePicker1";
            this.startTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.startTimePicker1.TabIndex = 8;
            // 
            // finishTimePicker
            // 
            this.finishTimePicker.Location = new System.Drawing.Point(143, 73);
            this.finishTimePicker.Name = "finishTimePicker";
            this.finishTimePicker.Size = new System.Drawing.Size(200, 23);
            this.finishTimePicker.TabIndex = 9;
            // 
            // votingSystemComboBox
            // 
            this.votingSystemComboBox.FormattingEnabled = true;
            this.votingSystemComboBox.Location = new System.Drawing.Point(143, 104);
            this.votingSystemComboBox.Name = "votingSystemComboBox";
            this.votingSystemComboBox.Size = new System.Drawing.Size(121, 23);
            this.votingSystemComboBox.TabIndex = 10;
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(32, 173);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 11;
            this.modifyButton.Text = "Modify Election";
            this.modifyButton.UseVisualStyleBackColor = true;
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.Location = new System.Drawing.Point(143, 142);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(78, 15);
            this.winnerLabel.TabIndex = 12;
            this.winnerLabel.Text = "Not Available";
            // 
            // ModifyElection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.winnerLabel);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.votingSystemComboBox);
            this.Controls.Add(this.finishTimePicker);
            this.Controls.Add(this.startTimePicker1);
            this.Controls.Add(this.countElectionButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.electionName);
            this.Name = "ModifyElection";
            this.Text = "ModifyElection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label electionName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button countElectionButton;
        private DateTimePicker startTimePicker1;
        private DateTimePicker finishTimePicker;
        private ComboBox votingSystemComboBox;
        private Button modifyButton;
        private Label winnerLabel;
    }
}