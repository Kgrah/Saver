namespace WindowSaver
{
    partial class Form1
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
            this.testBox1 = new System.Windows.Forms.TextBox();
            this.writeButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.getProcsButton = new System.Windows.Forms.Button();
            this.killButton = new System.Windows.Forms.Button();
            this.urlTest = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.excelTestB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testBox1
            // 
            this.testBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.testBox1.Location = new System.Drawing.Point(12, 12);
            this.testBox1.Multiline = true;
            this.testBox1.Name = "testBox1";
            this.testBox1.Size = new System.Drawing.Size(258, 598);
            this.testBox1.TabIndex = 0;
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(420, 105);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(75, 23);
            this.writeButton.TabIndex = 2;
            this.writeButton.Text = "Write!";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(420, 134);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 3;
            this.runButton.Text = "Run!";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // getProcsButton
            // 
            this.getProcsButton.Location = new System.Drawing.Point(420, 163);
            this.getProcsButton.Name = "getProcsButton";
            this.getProcsButton.Size = new System.Drawing.Size(75, 23);
            this.getProcsButton.TabIndex = 4;
            this.getProcsButton.Text = "Procs!";
            this.getProcsButton.UseVisualStyleBackColor = true;
            this.getProcsButton.Click += new System.EventHandler(this.getProcsButton_Click);
            // 
            // killButton
            // 
            this.killButton.Location = new System.Drawing.Point(420, 192);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(75, 23);
            this.killButton.TabIndex = 5;
            this.killButton.Text = "Kill!";
            this.killButton.UseVisualStyleBackColor = true;
            this.killButton.Click += new System.EventHandler(this.killButton_Click);
            // 
            // urlTest
            // 
            this.urlTest.Location = new System.Drawing.Point(591, 146);
            this.urlTest.Name = "urlTest";
            this.urlTest.Size = new System.Drawing.Size(75, 23);
            this.urlTest.TabIndex = 6;
            this.urlTest.Text = "URL?\r\n\r\n";
            this.urlTest.UseVisualStyleBackColor = true;
            this.urlTest.Click += new System.EventHandler(this.urlTest_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.Location = new System.Drawing.Point(559, 175);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 77);
            this.textBox1.TabIndex = 7;
            // 
            // excelTestB
            // 
            this.excelTestB.Location = new System.Drawing.Point(591, 105);
            this.excelTestB.Name = "excelTestB";
            this.excelTestB.Size = new System.Drawing.Size(75, 23);
            this.excelTestB.TabIndex = 8;
            this.excelTestB.Text = "Excel!";
            this.excelTestB.UseVisualStyleBackColor = true;
            this.excelTestB.Click += new System.EventHandler(this.excelTestB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1522, 622);
            this.Controls.Add(this.excelTestB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.urlTest);
            this.Controls.Add(this.killButton);
            this.Controls.Add(this.getProcsButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.testBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox testBox1;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button getProcsButton;
        private System.Windows.Forms.Button killButton;
        private System.Windows.Forms.Button urlTest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button excelTestB;
    }
}

