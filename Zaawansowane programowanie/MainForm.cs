using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Zaawansowane_programowanie
{
    public partial class MainForm : Form
    {
        private string filePath;
        public static List<Column> allColumns;
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            /*
            openFileDialog1.Filter = "Pliki tesktowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(filePath);
                ReadFile(sr);
                labelFileName.Text = filePath;
                startButton.Enabled = true;
                sr.Close();
            }
            */
            //C:\Users\Marek\Documents\tescik.txt
            string fileName = "C:\\Users\\Marek\\Documents\\tescik.txt";
            StreamReader sr = new StreamReader(fileName);
            ReadFile(sr, fileName);
            sr.Close();
        }

        private void ReadFile(StreamReader reader, string source)
        {
            string allFile = reader.ReadToEnd();
            string[] lines = allFile.Split('\n');
            //zakładamy, że w liniach sa zapisane kolumny, a nie wiersze
            MakeColumnObjects(lines, source);
        }

        public void MakeColumnObjects(string[] lines, string source)
        {
            int columnIndex = 0;
            allColumns = new List<Column>();
            foreach (string line in lines)
            {
                if (!isEmpty(line))
                    allColumns.Add(GetColumnObject(line, ref columnIndex));
            }
            labelFileName.Text = source;
            startButton.Enabled = true;
        }

        private bool isEmpty(string s)
        {
            if (s.Trim().Length > 0)
                return false;
            else
                return true;
        }
        private Column GetColumnObject(string column, ref int index)
        {
            Column currentColumn = new Column(index++);
            foreach (string value in column.Split(' '))
            {
                currentColumn.AddRow(value);
            }
            return currentColumn;
        }

        private void generatorFormButton_Click(object sender, EventArgs e)
        {
            GeneratorForm gen = new GeneratorForm(this);
            gen.Show();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            AlgorithmForm algorithmForm = new AlgorithmForm(allColumns, 
                Convert.ToInt32(numericUpDownIteration.Value), Convert.ToInt32(numericUpDownPopulationSize.Value), 
                Convert.ToInt32(numericUpDownCrossFactor.Value), Convert.ToInt32(numericUpDownBests.Value), 
                Convert.ToInt32(numericUpDownCrossInterval.Value), Convert.ToInt32(numericUpDownMutationCount.Value), 
                Convert.ToInt32(numericUpDownMutationPower.Value), Thread.CurrentThread);
            ThreadStart startingThreadDelegate = new ThreadStart(algorithmForm.RunAlgorithm);
            Thread algorithmThread = new Thread(startingThreadDelegate);
            algorithmForm.Show();
            algorithmThread.IsBackground = true;
            algorithmThread.Start();
        }
    }
}
