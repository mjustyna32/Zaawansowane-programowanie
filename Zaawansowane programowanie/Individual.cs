using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaawansowane_programowanie
{
    public class Individual
    {
        private List<int> columnsPermutation;
        private List<int> columnsToDelete;
        private AlgorithmForm algorithmObject;
        public int SolutionValue
        {
            get { return columnsToDelete.Count; }
            set { }
        }
        public List<int> ColumnsToDelete
        {
            get { return columnsToDelete; }
        }
        public List<int> Columns
        {
            get { return columnsPermutation; }
        }
        public Individual(List<int> columnsIndexes, AlgorithmForm obj)
        {
            columnsPermutation = columnsIndexes;
            columnsToDelete = new List<int>();
            algorithmObject = obj;
        }

        public bool areConsecutiveColumns(Column col1, Column col2)
        {
            List<bool> column1Rows = col1.GetRows;
            List<bool> column2Rows = col2.GetRows;
            for(int i=0; i<column1Rows.Count; i++)
            {
                if(column1Rows[i] == true && column2Rows[i] == true)
                {
                    return true;
                }
            }
            return false;
        }

        public int CheckSolution()
        {
            int rowCount = algorithmObject.GetColumnObjectAt(0).GetRowsCount;
            for(int rowIndex =0; rowIndex<rowCount; rowIndex++)
            {
                RemoveColumnsFromRow(rowIndex);
            }
            return SolutionValue;
        }

        private void RemoveColumnsFromRow(int rowIndex)
        {
            bool onesStarted = false; //określa, czy napotkano juz pierwszą jedynkę w macierzy
            //policzyc ile jest jedynek w wierszu
            int onesInRow = algorithmObject.GetOnesCountInRow(rowIndex);
            foreach (int columnIndex in columnsPermutation)
            {
                Column column = algorithmObject.GetColumnObjectAt(columnIndex);
                if (!onesStarted && column.getRowValueAt(rowIndex))
                {
                    onesStarted = true;
                }
                else if (onesStarted && !column.getRowValueAt(rowIndex) && !columnsToDelete.Contains(columnIndex) && onesInRow>0) 
                {
                    columnsToDelete.Add(columnIndex);
                }
                if (column.getRowValueAt(rowIndex))
                {
                    onesInRow--;
                }
            }
        }

        internal void Mutate(float mutationPower)
        {
            Random rand = new Random();
            int numberOfMutations = Convert.ToInt32(columnsPermutation.Count * mutationPower);
            for(int i=0; i<numberOfMutations; i++)
            {
                int index1 = 0;
                int index2 = 0;
                while (index1 == index2)
                {
                    index1 = rand.Next(columnsPermutation.Count);
                    index2 = rand.Next(columnsPermutation.Count);
                }
                CollectionActions.Swap(columnsPermutation, index1, index2);
            }
        }

        internal void MutateFragment(int startingPosition, int mutatedIntervalSize)
        {
            List<int> mutatedColumns = columnsPermutation.GetRange(startingPosition, mutatedIntervalSize);
            CollectionActions.Shuffle(mutatedColumns);
            List<int> newPermutation = new List<int>();
            for(int i =0; i<columnsPermutation.Count; i++)
            {
                if (i >= startingPosition && i < startingPosition + mutatedIntervalSize)
                {
                    newPermutation.Add(mutatedColumns.ElementAt(i-startingPosition));
                } else
                    newPermutation.Add(columnsPermutation.ElementAt(i));
            }
            columnsPermutation = newPermutation;
        }

        /*
        public int CheckSolution()
        {
            //sprawdzenie consecutive ones
            for(int i =0; i<columnsPermutation.Count - 1; i++) //porownujemy i-ty oraz i+1 element
            {
                Column column1 =algorithmObject.GetColumnObjectAt(columnsPermutation[i]);
                Column column2 = algorithmObject.GetColumnObjectAt(columnsPermutation[i+1]);
                int secColIndex = columnsPermutation[i + 1];
                if(!areConsecutiveColumns(column1, column2))
                {
                    CheckThirdColumn(i, column1, column2);
                }

            }
            return SolutionValue;
        }
        
        private void CheckThirdColumn(int i, Column column1, Column column2)
        {
            /*Jeżeli nie ma przejścia z kolumny a do b to sprawdzamy, czy jest przejście 
             * z kolumny b do c i z a do c, żeby móc wybrać, czy usunąć kolumnę, a, b czy obie. 
             *
             */
        /*
                    Column column3;
                    try
                    {
                        column3 = algorithmObject.GetColumnObjectAt(columnsPermutation[i + 2]);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    if (areConsecutiveColumns(column1, column3))
                    {
                        columnsToDelete.Add(i + 1); //Kolumna 2
                    }
                    else if (areConsecutiveColumns(column2, column3))
                    {
                        columnsToDelete.Add(i);
                    }
                    else //Czy na pewno usunac obie???
                    {
                        columnsToDelete.Add(i);
                        columnsToDelete.Add(i + 1);
                    }
                }
            */

    }
}
