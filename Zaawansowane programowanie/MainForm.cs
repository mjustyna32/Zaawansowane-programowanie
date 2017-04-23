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
        private List<Column> allColumns;
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pliki tesktowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(filePath);
                ReadFile(sr);

                sr.Close();
            }
        }

        private void ReadFile(StreamReader reader)
        {
            string allFile = reader.ReadToEnd();
            string[] lines = allFile.Split('\n');
            //zakładamy, że w liniach sa zapisane kolumny, a nie wiersze
            int columnIndex = 0;
            allColumns = new List<Column>();
            foreach(string line in lines)
            {
                if(!isEmpty(line))
                    allColumns.Add(GetColumnObject(line, ref columnIndex));
            }
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
            GeneratorForm gen = new GeneratorForm();
            gen.Show();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            AlgorithmForm algorithmForm = new AlgorithmForm(allColumns, 5, 5, Thread.CurrentThread);
            ThreadStart startingThreadDelegate = new ThreadStart(algorithmForm.RunAlgorithm);
            Thread algorithmThread = new Thread(startingThreadDelegate);
            algorithmForm.Show();
            algorithmThread.Start();
        }
    }
}
