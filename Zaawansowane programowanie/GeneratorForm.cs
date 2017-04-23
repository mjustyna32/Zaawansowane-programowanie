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
        public GeneratorForm()
        {
            InitializeComponent();
        }

        private void GenerateAndSave_Click(object sender, EventArgs e)
        {
            //wygeneruj instancje
            if (toSaveCheckBox.Checked)
                Save();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            saveFileDialog1.Filter = "Plik tekstowy (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName);
                file.WriteLine(GetTransponedMatrix());
                file.Close();

            }
            saveFileDialog1.FileName = "";
        }
        private string GetTransponedMatrix()
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

            CollectionActions.Shuffle(columns); //Losowe mieszanie kolumn
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
            int index = 1;
            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable; //wylaczenie sortowania kolumn
                column.HeaderText = "" + index++;
            }
            index = 1;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = "" + index++;
            }
            
        }
               
    }
}
