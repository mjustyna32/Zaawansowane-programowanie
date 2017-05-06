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
            this.labelFileName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDownBests = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownIteration = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCrossFactor = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMutationPower = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMutationCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCrossInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIteration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrossFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrossInterval)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // generatorFormButton
            // 
            this.generatorFormButton.Location = new System.Drawing.Point(0, 3);
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
            this.panel1.Controls.Add(this.labelFileName);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.loadFileButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 72);
            this.panel1.TabIndex = 1;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(15, 41);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(0, 17);
            this.labelFileName.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.generatorFormButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(727, 0);
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
            this.panel3.Controls.Add(this.numericUpDownBests);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.numericUpDownIteration);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.numericUpDownPopulationSize);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.numericUpDownCrossFactor);
            this.panel3.Controls.Add(this.numericUpDownMutationPower);
            this.panel3.Controls.Add(this.numericUpDownMutationCount);
            this.panel3.Controls.Add(this.numericUpDownCrossInterval);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(886, 369);
            this.panel3.TabIndex = 2;
            // 
            // numericUpDownBests
            // 
            this.numericUpDownBests.Location = new System.Drawing.Point(289, 226);
            this.numericUpDownBests.Name = "numericUpDownBests";
            this.numericUpDownBests.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownBests.TabIndex = 17;
            this.numericUpDownBests.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Udział najlepszych";
            // 
            // numericUpDownIteration
            // 
            this.numericUpDownIteration.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownIteration.Location = new System.Drawing.Point(289, 26);
            this.numericUpDownIteration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownIteration.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownIteration.Name = "numericUpDownIteration";
            this.numericUpDownIteration.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownIteration.TabIndex = 15;
            this.numericUpDownIteration.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Liczba iteracji";
            // 
            // numericUpDownPopulationSize
            // 
            this.numericUpDownPopulationSize.Location = new System.Drawing.Point(289, 56);
            this.numericUpDownPopulationSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownPopulationSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPopulationSize.Name = "numericUpDownPopulationSize";
            this.numericUpDownPopulationSize.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownPopulationSize.TabIndex = 13;
            this.numericUpDownPopulationSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Rozmiar populacji bazowej";
            // 
            // numericUpDownCrossFactor
            // 
            this.numericUpDownCrossFactor.Location = new System.Drawing.Point(289, 85);
            this.numericUpDownCrossFactor.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownCrossFactor.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCrossFactor.Name = "numericUpDownCrossFactor";
            this.numericUpDownCrossFactor.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownCrossFactor.TabIndex = 11;
            this.numericUpDownCrossFactor.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numericUpDownMutationPower
            // 
            this.numericUpDownMutationPower.Location = new System.Drawing.Point(289, 193);
            this.numericUpDownMutationPower.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownMutationPower.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMutationPower.Name = "numericUpDownMutationPower";
            this.numericUpDownMutationPower.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownMutationPower.TabIndex = 10;
            this.numericUpDownMutationPower.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDownMutationCount
            // 
            this.numericUpDownMutationCount.Location = new System.Drawing.Point(289, 156);
            this.numericUpDownMutationCount.Name = "numericUpDownMutationCount";
            this.numericUpDownMutationCount.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownMutationCount.TabIndex = 9;
            this.numericUpDownMutationCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownCrossInterval
            // 
            this.numericUpDownCrossInterval.Location = new System.Drawing.Point(289, 122);
            this.numericUpDownCrossInterval.Maximum = new decimal(new int[] {
            98,
            0,
            0,
            0});
            this.numericUpDownCrossInterval.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCrossInterval.Name = "numericUpDownCrossInterval";
            this.numericUpDownCrossInterval.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownCrossInterval.TabIndex = 8;
            this.numericUpDownCrossInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Siła mutacji (%)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Procent populacji ulegający mutacjom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Rozmiar przedziału krzyżowania (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Współczynnik krzyżowania";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(728, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 60);
            this.button2.TabIndex = 3;
            this.button2.Text = "Ustaw domyślnie";
            this.button2.UseVisualStyleBackColor = true;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 269);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(886, 100);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.startButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(624, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(262, 100);
            this.panel5.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(34, 20);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(222, 68);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 441);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Zaawansowane programowanie";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIteration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrossFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrossInterval)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownCrossFactor;
        private System.Windows.Forms.NumericUpDown numericUpDownMutationPower;
        private System.Windows.Forms.NumericUpDown numericUpDownMutationCount;
        private System.Windows.Forms.NumericUpDown numericUpDownCrossInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownPopulationSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.NumericUpDown numericUpDownIteration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownBests;
        private System.Windows.Forms.Label label9;
    }
}

