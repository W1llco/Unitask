namespace Uni_tasl
{
    partial class EndElection
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
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 44);
            label2.Name = "label2";
            label2.Size = new Size(188, 25);
            label2.TabIndex = 1;
            label2.Text = "Choose active election";
            // 
            // button1
            // 
            button1.Location = new Point(45, 338);
            button1.Name = "button1";
            button1.Size = new Size(184, 34);
            button1.TabIndex = 2;
            button1.Text = "End Election";
            button1.UseVisualStyleBackColor = true;
            // 
            // EndElection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "EndElection";
            Text = "EndElection";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
    }
}