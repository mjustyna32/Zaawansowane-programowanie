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
            CollectionActions.Shuffle(columnsPermutation);
            algorithmObject = obj;
        }

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

    }
}
