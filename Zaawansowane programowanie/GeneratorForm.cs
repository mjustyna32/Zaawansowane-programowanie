using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaawansowane_programowanie
{
    public partial class GeneratorForm : Form
    {
        Random rand = new Random();
        MainForm mainForm;
        private List<string> instance;
        private float randomLengthFactor = (float)0.5;
        public GeneratorForm(MainForm obj)
        { 
            InitializeComponent();
            mainForm = obj;
        }

        private void GenerateAndSave_Click(object sender, EventArgs e)
        {
            //wygeneruj instancje
            instance = Generate(Convert.ToInt32(numericUpDownMFragments.Value), Convert.ToInt32(numericUpDownNSamples.Value), Convert.ToInt32(numericUpDownErrorCount.Value), Convert.ToInt32(numericUpDownMutationPower.Value));
            if (toSaveCheckBox.Checked)
                //zrobić zapis string'ów instance
                SaveGeneratedInstance();
            else
                AddInstanceToMainForm(); //laduje do mainForm
            generatedInstanceLabel.Text = "Wygenerowano instancję";
        }
        private void SaveGeneratedInstance()
        {
            saveFileDialog1.Filter = "Plik tekstowy (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            string outputInstance = "";
            new CollectionActions().Shuffle(ref instance);
            foreach(string s in GetTransponedStringList(instance))
            {
                outputInstance += s + Environment.NewLine;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName);
                file.WriteLine(outputInstance);
                file.Close();

            }
            saveFileDialog1.FileName = "";
        }
        private void AddInstanceToMainForm()
        {
            //zrobic listę obiektów typu column
            List<string> columns = GetTransponedStringList(instance);
            new CollectionActions().Shuffle(ref columns);
            mainForm.MakeColumnObjects(columns.ToArray(), "Wygenerowany obiekt");
            //przeslac ja do
            //MainForm.allColumns = kolumny
        }
        private List<string> GetTransponedStringList(List<string> list)
        {
            List<string> columns = new List<string>();
            int rowLength = list.ElementAt(0).Length;
            for(int columnIndex = 0; columnIndex < rowLength; columnIndex++)
            {
                string column = "";
                foreach(string row in list)
                {
                    column += row.ElementAt(columnIndex).ToString()+' ';
                }
                columns.Add(column);
            }

            return columns;
        }
        public void TestsGenerator(int fragments, int samples, int mutationCount, int mutationPower)
        {
            instance = Generate(fragments, samples, mutationCount, mutationPower);
            AddInstanceToMainForm();
        }
        private List<string> Generate(int fragments, int samples, int mutationCount, int mutationPower)
        {
            /* Co najmniej jeden ciag musi sie zaczynac od 0.
             * Co najmniej jeden musi isc do samego konca.
             * Ciagi wewnetrzne musza się łączyć, aby nie było przerw -> zapisywac indeksy kolumn do
             * listy i sprawdzac, czy zachowana jest ciaglosc
             * 
             * Wiersz zaczynajacy sie od zera - losowy
             * wiersz konczacy - takze losowy
             * 
             * najpierw losowac pulę miejsc rozpoczecia i długości (co najmniej szer/dlugosc + np. 10%)
             * nastepnie wypelniac dlugoscia -> max(wylosowana, nastPozycja) i dopelniac
             * Zapisać do listy, a potem shuffle na wierszach
             * 
             * Wprowadzanie błędów - zamiana na wartosc przeciwna. Unikać
             * miejsc granicznych, bo zmiana wartości w tych miejscach nie jest błędem
             */
            /*Podzielic na rowne czesci, po kolei wypelniac, wszedzie tak samo, potem przemieszac
             * wiersze
             * 
             * 
             */
            int consOnesLength = Math.Max((int)Math.Round((decimal)fragments / samples, 0),1);
            int previousOnes = 0;
            List<string> instance = new List<string>();
            for (int i = 0; i < samples; i++)
            {
                string sample = "";
                int maxLength = Convert.ToInt32(randomLengthFactor * fragments);
                maxLength = Math.Max(maxLength, consOnesLength + 1);
                int randomLength = rand.Next(consOnesLength+1, maxLength);
                if(previousOnes >= fragments)
                {
                    previousOnes = 0;
                }
                for (int j = 0; j < fragments; j++)
                {
                    if (j >= previousOnes && j <= previousOnes + randomLength)
                    {
                        sample += "1";
                    }
                    else
                    {
                        sample += "0";
                    }
                }
                previousOnes += consOnesLength;
                instance.Add(sample);
            }
            //poniższa linijke przenisc do zapisu! lub w ogole usunac, bo nie jest to potrzebne
            //CollectionActions.Shuffle(instance);
            InsertMutations(ref instance, mutationCount, mutationPower);
            return instance;
        }

        private void InsertMutations(ref List<string> instance, int mutationCount, int mutationPower)
        {
            int numberOfMutations = (mutationCount * instance.Count)/100;
            List<int> mutatedSamples = new List<int>();
            for(int i=0; i<numberOfMutations; i++)
            {
                mutatedSamples.Add(rand.Next(instance.Count));
            }
            foreach(int sampleNum in mutatedSamples)
            {
                string sample = instance.ElementAt(sampleNum);
                instance.RemoveAt(sampleNum);
                Mutate(ref sample, mutationPower);
                instance.Insert(sampleNum, sample);
            }
        }

        private void Mutate(ref string sample, int mutationPower)
        {
            int numberOfMutations = (mutationPower*sample.Length)/100;
            StringBuilder sampleBuilder = new StringBuilder(sample);
            while (numberOfMutations > 0)
            {
                int position = GetMutationPosition(sample);
                if (sampleBuilder[position] == '1')
                {
                    sampleBuilder[position] = '0';
                }
                else
                {
                    sampleBuilder[position] = '1';
                }
                numberOfMutations--;
            }
            sample = sampleBuilder.ToString();
        }

        private int GetMutationPosition(string sample)
        { 
            int oneBegin =0, oneEnd = sample.Length;
            bool oneMet = false;
            for(int i=0; i<sample.Length; i++)
            {
                if(!oneMet && sample[i] == '1')
                {
                    oneMet = true;
                    oneBegin = i;
                }else if(oneMet && sample[i] == '0')
                {
                    oneEnd = i;
                    break;
                }
            }
            int position = rand.Next(1, sample.Length - 1);
            while(position!=oneBegin-2 && position != oneEnd + 2)
            {
                position = rand.Next(1, sample.Length - 1);
            }
            return position;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveDataGridView();
        }

        private void SaveDataGridView()
        {
            saveFileDialog1.Filter = "Plik tekstowy (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName);
                file.WriteLine(GetTransponedDataGridView());
                file.Close();

            }
            saveFileDialog1.FileName = "";
        }
        private string GetTransponedDataGridView()
        {
            List<string> columns = new List<string>();
            string outLine = "";
            for (int column = 0; column < dataGridView1.Columns.Count; column++)
            {
                string outColumn = "";
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    outColumn += ValueInCell(column, row) + " ";
                }
                columns.Add(outColumn);
            }

            new CollectionActions().Shuffle(ref columns); //Losowe mieszanie kolumn
            foreach(string col in columns)
            {
                outLine += col + Environment.NewLine;
            }
            return outLine;
        }

        private string ValueInCell(int column, int row)
        {
            string cellValue = ""+ dataGridView1[column,row].Value;
            if (IsEmpty(cellValue))
            {
                return ""+0;
            }else
            {
                return ""+1;
            }

        }
        private bool IsEmpty(string cell)
        {
            if(cell==" " || cell == "" || cell=="0")
            {
                return true;
            }else
            {
                return false;
            }
        }
        private void ClearBlankButton_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = Convert.ToInt32(samplesCount.Value);
            dataGridView1.RowCount = Convert.ToInt32(fragmentsCount.Value);            
            SetHeaderValues();
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                for (int column = 0; column < dataGridView1.ColumnCount; column++)
                {
                    dataGridView1[column, row].Value = "";
                }
            }

        }

        private void SetHeaderValues()
        {
            int index = 1;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable; //wylaczenie sortowania kolumn
                column.HeaderText = "" + index++;
            }
            index = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = "" + index++;
            }
        }

        private void loadInstanceButton_Click(object sender, EventArgs e)
        {
            if (instance == null)
            {
                MessageBox.Show("Nie wygenerowano jeszcze żadnej instancji.");
                return;
            }
            dataGridView1.RowCount = instance.Count;
            dataGridView1.ColumnCount = instance.ElementAt(0).Length;
            for(int row=0; row< instance.Count; row++)
            { 
                for (int column=0; column<instance.ElementAt(row).Length; column++)
                {
                    //wypelnianie datagridview
                    string cellValue = instance.ElementAt(row).ElementAt(column).ToString();
                    dataGridView1[column, row].Value = cellValue;
                }
            }
            SetHeaderValues();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
