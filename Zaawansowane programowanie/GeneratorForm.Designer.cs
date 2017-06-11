﻿namespace Zaawansowane_programowanie
{
    partial class GeneratorForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.fragmentsLabel = new System.Windows.Forms.Label();
            this.samplesLabel = new System.Windows.Forms.Label();
            this.clearBlankButton = new System.Windows.Forms.Button();
            this.fragmentsCount = new System.Windows.Forms.NumericUpDown();
            this.samplesCount = new System.Windows.Forms.NumericUpDown();
            this.loadInstanceButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.generatedInstanceLabel = new System.Windows.Forms.Label();
            this.generateAndSaveButton = new System.Windows.Forms.Button();
            this.toSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownErrorCount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownMFragments = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNSamples = new System.Windows.Forms.NumericUpDown();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesCount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMFragments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNSamples)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wygeneruj plik automatycznie lub samodzielnie";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 44);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 529);
            this.panel2.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(918, 529);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(910, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Samodzielnie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(665, 494);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.fragmentsLabel);
            this.panel3.Controls.Add(this.samplesLabel);
            this.panel3.Controls.Add(this.clearBlankButton);
            this.panel3.Controls.Add(this.fragmentsCount);
            this.panel3.Controls.Add(this.samplesCount);
            this.panel3.Controls.Add(this.loadInstanceButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(668, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(239, 494);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.saveButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 394);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(239, 100);
            this.panel5.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(3, 17);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(230, 67);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Zapisz instancję do pliku";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // fragmentsLabel
            // 
            this.fragmentsLabel.AutoSize = true;
            this.fragmentsLabel.Location = new System.Drawing.Point(3, 67);
            this.fragmentsLabel.Name = "fragmentsLabel";
            this.fragmentsLabel.Size = new System.Drawing.Size(155, 17);
            this.fragmentsLabel.TabIndex = 6;
            this.fragmentsLabel.Text = "Liczba fragmentów (m):";
            // 
            // samplesLabel
            // 
            this.samplesLabel.AutoSize = true;
            this.samplesLabel.Location = new System.Drawing.Point(0, 20);
            this.samplesLabel.Name = "samplesLabel";
            this.samplesLabel.Size = new System.Drawing.Size(123, 17);
            this.samplesLabel.TabIndex = 5;
            this.samplesLabel.Text = "Liczba próbek (n):";
            // 
            // clearBlankButton
            // 
            this.clearBlankButton.Location = new System.Drawing.Point(3, 103);
            this.clearBlankButton.Name = "clearBlankButton";
            this.clearBlankButton.Size = new System.Drawing.Size(228, 63);
            this.clearBlankButton.TabIndex = 4;
            this.clearBlankButton.Text = "Wygeneruj czystą karta";
            this.clearBlankButton.UseVisualStyleBackColor = true;
            this.clearBlankButton.Click += new System.EventHandler(this.ClearBlankButton_Click);
            // 
            // fragmentsCount
            // 
            this.fragmentsCount.Location = new System.Drawing.Point(176, 65);
            this.fragmentsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fragmentsCount.Name = "fragmentsCount";
            this.fragmentsCount.Size = new System.Drawing.Size(52, 22);
            this.fragmentsCount.TabIndex = 3;
            this.fragmentsCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // samplesCount
            // 
            this.samplesCount.Location = new System.Drawing.Point(176, 20);
            this.samplesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.samplesCount.Name = "samplesCount";
            this.samplesCount.Size = new System.Drawing.Size(52, 22);
            this.samplesCount.TabIndex = 2;
            this.samplesCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // loadInstanceButton
            // 
            this.loadInstanceButton.Location = new System.Drawing.Point(3, 172);
            this.loadInstanceButton.Name = "loadInstanceButton";
            this.loadInstanceButton.Size = new System.Drawing.Size(228, 68);
            this.loadInstanceButton.TabIndex = 1;
            this.loadInstanceButton.Text = "Załaduj wygenerowaną instancję";
            this.loadInstanceButton.UseVisualStyleBackColor = true;
            this.loadInstanceButton.Click += new System.EventHandler(this.loadInstanceButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(910, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Automatycznie";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Controls.Add(this.button5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(3, 374);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(904, 123);
            this.panel7.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.generatedInstanceLabel);
            this.panel4.Controls.Add(this.generateAndSaveButton);
            this.panel4.Controls.Add(this.toSaveCheckBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(675, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(229, 123);
            this.panel4.TabIndex = 8;
            // 
            // generatedInstanceLabel
            // 
            this.generatedInstanceLabel.AutoSize = true;
            this.generatedInstanceLabel.Location = new System.Drawing.Point(14, 0);
            this.generatedInstanceLabel.Name = "generatedInstanceLabel";
            this.generatedInstanceLabel.Size = new System.Drawing.Size(96, 17);
            this.generatedInstanceLabel.TabIndex = 9;
            this.generatedInstanceLabel.Text = "Brak instancji.";
            // 
            // generateAndSaveButton
            // 
            this.generateAndSaveButton.Location = new System.Drawing.Point(17, 60);
            this.generateAndSaveButton.Name = "generateAndSaveButton";
            this.generateAndSaveButton.Size = new System.Drawing.Size(196, 58);
            this.generateAndSaveButton.TabIndex = 0;
            this.generateAndSaveButton.Text = "Wygeneruj";
            this.generateAndSaveButton.UseVisualStyleBackColor = true;
            this.generateAndSaveButton.Click += new System.EventHandler(this.GenerateAndSave_Click);
            // 
            // toSaveCheckBox
            // 
            this.toSaveCheckBox.AutoSize = true;
            this.toSaveCheckBox.Checked = true;
            this.toSaveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toSaveCheckBox.Location = new System.Drawing.Point(17, 37);
            this.toSaveCheckBox.Name = "toSaveCheckBox";
            this.toSaveCheckBox.Size = new System.Drawing.Size(125, 21);
            this.toSaveCheckBox.TabIndex = 7;
            this.toSaveCheckBox.Text = "Zapisz do pliku";
            this.toSaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 60);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 58);
            this.button5.TabIndex = 2;
            this.button5.Text = "Zamknij";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.numericUpDownErrorCount);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.numericUpDownMFragments);
            this.panel6.Controls.Add(this.numericUpDownNSamples);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(904, 494);
            this.panel6.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Liczba losowych błędów";
            // 
            // numericUpDownErrorCount
            // 
            this.numericUpDownErrorCount.Location = new System.Drawing.Point(327, 87);
            this.numericUpDownErrorCount.Name = "numericUpDownErrorCount";
            this.numericUpDownErrorCount.Size = new System.Drawing.Size(52, 22);
            this.numericUpDownErrorCount.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Liczba próbek (n):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Liczba framgentów (m)";
            // 
            // numericUpDownMFragments
            // 
            this.numericUpDownMFragments.Location = new System.Drawing.Point(327, 15);
            this.numericUpDownMFragments.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMFragments.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownMFragments.Name = "numericUpDownMFragments";
            this.numericUpDownMFragments.Size = new System.Drawing.Size(52, 22);
            this.numericUpDownMFragments.TabIndex = 7;
            this.numericUpDownMFragments.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownNSamples
            // 
            this.numericUpDownNSamples.Location = new System.Drawing.Point(327, 50);
            this.numericUpDownNSamples.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownNSamples.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownNSamples.Name = "numericUpDownNSamples";
            this.numericUpDownNSamples.Size = new System.Drawing.Size(52, 22);
            this.numericUpDownNSamples.TabIndex = 8;
            this.numericUpDownNSamples.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GeneratorForm";
            this.Text = "Generator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fragmentsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesCount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMFragments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNSamples)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label fragmentsLabel;
        private System.Windows.Forms.Label samplesLabel;
        private System.Windows.Forms.Button clearBlankButton;
        private System.Windows.Forms.NumericUpDown fragmentsCount;
        private System.Windows.Forms.NumericUpDown samplesCount;
        private System.Windows.Forms.Button loadInstanceButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button generateAndSaveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownErrorCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownMFragments;
        private System.Windows.Forms.NumericUpDown numericUpDownNSamples;
        private System.Windows.Forms.CheckBox toSaveCheckBox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label generatedInstanceLabel;
        private System.Windows.Forms.Panel panel5;
    }
}