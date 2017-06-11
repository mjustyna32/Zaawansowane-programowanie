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
            get {
                return columnsToDelete.Count;
            }
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
            algorithmObject = obj;
        }

        public Individual GetObjectCopy()
        {
            List<int> columns = new List<int>();
            foreach (int col in columnsPermutation)
            {
                columns.Add(col);
            }
            Individual ind = new Individual(columns, algorithmObject);
            ind.CheckSolution();
            return ind;
        }
        public int CheckSolution()
        {
            columnsToDelete = new List<int>();
            int rowCount = algorithmObject.GetColumnObjectAt(0).GetRowsCount;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
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
            RemoveSingleOnes(rowIndex, onesInRow);
            foreach (int columnIndex in columnsPermutation)
            {
                Column column = algorithmObject.GetColumnObjectAt(columnIndex);
                if (!onesStarted && column.GetRowValueAt(rowIndex) && !columnsToDelete.Contains(columnIndex))
                {
                    onesStarted = true;
                }
                else if (onesStarted && !column.GetRowValueAt(rowIndex) && !columnsToDelete.Contains(columnIndex) && onesInRow > 0)
                {
                    columnsToDelete.Add(columnIndex);
                }
                if (column.GetRowValueAt(rowIndex))
                {
                    onesInRow--;
                }
            }
        }

        private void RemoveSingleOnes(int rowIndex, int onesInRow)
        {
            List<int> singleOnesPositions = new List<int>();
            List<int> startingOnesPosition = new List<int>();
            List<int> endingOnesPosition = new List<int>();
            GetStartingBlocksList(rowIndex, ref startingOnesPosition, ref endingOnesPosition);
            bool previousOne = false;
            for(int index =0; index<columnsPermutation.Count-1; index++)
            {
                int column1Index = columnsPermutation.ElementAt(index);
                int column2Index = columnsPermutation.ElementAt(index + 1);
                Column column1 = algorithmObject.GetColumnObjectAt(column1Index);
                Column column2 = algorithmObject.GetColumnObjectAt(column2Index);
                if (IsSingleOne(rowIndex, onesInRow, startingOnesPosition, endingOnesPosition, previousOne, column1Index, column1, column2)) //wyklucza usunięcie wszystkich jedynek z wiersza
                {
                    singleOnesPositions.Add(column1Index);
                }

                if (column1.GetRowValueAt(rowIndex))
                {
                    previousOne = true;
                    onesInRow--;
                }
                else
                    previousOne = false;
            }
            foreach(int one in singleOnesPositions)
            {
                if (!columnsToDelete.Contains(one))
                {
                    columnsToDelete.Add(one);
                }
            }
        }

        private bool IsSingleOne(int rowIndex, int onesInRow, List<int> startingOnesPosition, List<int> endingOnesPosition, bool previousOne, int column1Index, Column column1, Column column2)
        {
            return column1.GetRowValueAt(rowIndex) && !column2.GetRowValueAt(rowIndex) && !previousOne && !AfterOrBeforeBlock(column1Index, startingOnesPosition, endingOnesPosition) && onesInRow > 1;
        }

        private bool AfterOrBeforeBlock(int column1Index, List<int> startingOnesPosition, List<int> endingOnesPosition)
        {
            int indexOfColumn = columnsPermutation.IndexOf(column1Index);
            if (startingOnesPosition.Contains(indexOfColumn + 2) || endingOnesPosition.Contains(indexOfColumn - 2))
                return true;
            else
                return false;
        }

        private void GetStartingBlocksList(int rowIndex, ref List<int> start, ref List<int> end)
        {
            int ones = 0;
            for(int i=0; i<columnsPermutation.Count; i++)
            {
                int columnNumber = columnsPermutation.ElementAt(i);
                Column column = algorithmObject.GetColumnObjectAt(columnNumber);
                if (column.GetRowValueAt(rowIndex)){
                    ones++;
                } else if (ones >= 2)
                {
                    start.Add(i - ones);
                    end.Add(i);
                    ones = 0;
                } else
                    ones = 0;
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
                new CollectionActions().Swap(ref columnsPermutation, index1, index2);
            }
        }

        internal void MutateFragment(int startingPosition, int mutatedIntervalSize)
        {
            List<int> mutatedColumns = columnsPermutation.GetRange(startingPosition, mutatedIntervalSize);
            new CollectionActions().Shuffle(ref mutatedColumns);
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

    }
}
