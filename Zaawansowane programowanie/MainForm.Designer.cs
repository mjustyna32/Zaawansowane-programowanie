namespace Zaawansowane_programowanie
{
    partial class MainForm
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
            this.generatorFormButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // generatorFormButton
            // 
            this.generatorFormButton.Location = new System.Drawing.Point(6, 2);
            this.generatorFormButton.Name = "generatorFormButton";
            this.generatorFormButton.Size = new System.Drawing.Size(146, 57);
            this.generatorFormButton.TabIndex = 0;
            this.generatorFormButton.Text = "Generator";
            this.generatorFormButton.UseVisualStyleBackColor = true;
            this.generatorFormButton.Click += new System.EventHandler(this.generatorFormButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.loadFileButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 72);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.generatorFormButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(633, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(157, 70);
            this.panel2.TabIndex = 5;
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(411, 3);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(216, 57);
            this.loadFileButton.TabIndex = 2;
            this.loadFileButton.Text = "Wczytaj plik";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wybierz plik lub wygeneruj nowy.";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 360);
            this.panel3.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(34, 20);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(222, 68);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 260);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 100);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.startButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(530, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(262, 100);
            this.panel5.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parametry:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(640, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 60);
            this.button2.TabIndex = 3;
            this.button2.Text = "Ustaw domyślnie";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 432);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Zaawansowane programowanie";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generatorFormButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}

