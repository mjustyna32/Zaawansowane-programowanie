using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Zaawansowane_programowanie
{
    public partial class AlgorithmForm : Form
    {
        private int iterations;
        private int populationSize;
        private List<Individual> populationOfSolutions;
        private List<Column> allInstanceColumns;
        private List<int> columnsIndexes;
        private Thread currentThread;
        private int crossingSizeFactor = 4;
        private float bestIndividualParticipanceFactor = (float) 0.1;
        private float crossingIntervalFactor =(float) 0.5;

        //Deprecated
        public List<Column> ColumnTable
        {
            get { return allInstanceColumns; }
        }


        public int Iterations
        {
            get { return iterations; }
        }
        public int PopulationSize
        {
            get { return PopulationSize; }
        }
        public AlgorithmForm(List<Column> columns, int iter, int popSize, Thread currThread )
        {
            iterations = iter;
            populationSize = popSize;
            InitializeComponent();
            allInstanceColumns = CloneColumnsList(columns);
            columnsIndexes = GetColumnsIndexes(allInstanceColumns);
            populationOfSolutions = new List<Individual>();
            currentThread = currThread;
        }
        public static List<int> GetColumnsIndexes(List<Column> columns)
        {
            List<int> indexesList = new List<int>();
            foreach(Column col in columns)
            {
                indexesList.Add(col.ColumnIndex);
            }
            return indexesList;
        }
        public static List<Column> CloneColumnsList(List<Column> source)
        {
            List<Column> clonedList = new List<Column>();
            foreach(Column col in source)
            {
                Column clonedColumn = new Column(col.ColumnIndex);
                clonedColumn.CloneObject(col);
                clonedList.Add(clonedColumn);
            }
            return clonedList;
        }

        public static List<int> CloneIndexesList(List<int> source)
        {
            List<int> outList = new List<int>();
            foreach(int value in source)
            {
                outList.Add(value);
            }
            return outList;
        }
        public Column GetColumnObjectAt(int index)
        {
            return allInstanceColumns[index];
        }
        public void RunAlgorithm()
        {
            PrepareBasicPopulation();
            for(int i=0; i<iterations; i++)
            {
                //krzyzowanie
                //Crossing();
                //selekcja
                //Selection();
                //mutacja / "cykl zagłady"
                //InsertMutations();
                ;
            }
        }

        private void PrepareBasicPopulation()
        {
            for(int i = 0; i<populationSize; i++)
            {
                List<int> clonedIndexes = CloneIndexesList(columnsIndexes);
                CollectionActions.Shuffle(clonedIndexes);
                populationOfSolutions.Add(new Individual(clonedIndexes, this));

            }
        }

        private void Crossing()
        {
            //TODO
            //obliczyć średnią wartość dla wszystkich osobników (??)
            //jeżeli obliczymy, to wtedy te, których wartość rozwiązania jest lepsza od średniej
            //dają więcej potomstwa niż te, które mają słabsze (lub zamiast dawać więcej potomsta
            //mają większą szansę na bycie wylosowanym do krzyżowania)

            //krzyzowanie osobniko gdzie wartosc jednego z nich <= srednia daje 2 potomkow, pp. jednego.
            // X% poniżej średniej
            Random rand = new Random();
            List<Individual> afterCorssing = new List<Individual>();
            int averageValue = getAverageIndividualValue();
            int outPopulationSize = populationOfSolutions.Count * crossingSizeFactor;
            int bestIndCount = Convert.ToInt32(outPopulationSize * bestIndividualParticipanceFactor);
            //zabezpieczyc na wypadek gdyby bylo zbyt malo ponizej sredniej
            while (afterCorssing.Count < bestIndCount)
            {
                int ind1Index = rand.Next(afterCorssing.Count);
                int ind2Index = rand.Next(afterCorssing.Count);
                Individual ind1 = populationOfSolutions.ElementAt(ind1Index);
                Individual ind2 = populationOfSolutions.ElementAt(ind2Index);
                if ((ind1 != ind2) && (ind1.SolutionValue <= averageValue || ind2.SolutionValue <= averageValue))
                {
                    addCrossedPair(ind1, ind2, afterCorssing);
                }
            }

        }

        private void addCrossedPair(Individual ind1, Individual ind2, List<Individual> afterCorssing)
        {
            Random rand = new Random();
            List<int> ind1ColumnsPerm = ind1.Columns;
            List<int> ind1Child = new List<int>();
            List<int> ind2ColumnsPerm = ind2.Columns;
            List<int> ind2Child = new List<int>();
            int crossingIntervalLength = Convert.ToInt32(ind1ColumnsPerm.Count * crossingIntervalFactor);
            int commonPartPosition = rand.Next(ind1ColumnsPerm.Count / 2);
            List<int> ind1SwapPart = ind1ColumnsPerm.GetRange(commonPartPosition, crossingIntervalLength);
            List<int> ind2SwapPart = ind2ColumnsPerm.GetRange(commonPartPosition, crossingIntervalLength);

            foreach (int column in ind1ColumnsPerm)
            {
                if (ind2SwapPart.Contains(column))
                {

                }
            }
        }

        private int getAverageIndividualValue()
        {
            int sum = 0;
            foreach(Individual i in populationOfSolutions)
            {
                sum += i.SolutionValue;
            }
            return sum / populationOfSolutions.Count;
        }
    }
}
