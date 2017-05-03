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
        private float mutationCountFactor = (float)0.2;
        private float mutationPowerFactor = (float)0.2;
        private Individual bestIndividual = null;

        //Deprecated
        public List<Column> GetColumnTable
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
        public AlgorithmForm(List<Column> columns, int iter, int popSize, int crossSize, int bestsParticipant,int crossInterval, int mutationCount, int mutationPower,  Thread currThread )
        {
            InitializeComponent();
            allInstanceColumns = CloneColumnsList(columns);
            columnsIndexes = GetColumnsIndexes(allInstanceColumns);
            populationOfSolutions = new List<Individual>();
            iterations = iter;
            populationSize = popSize;
            crossingSizeFactor = crossSize;
            bestIndividualParticipanceFactor = bestsParticipant /100;
            crossingIntervalFactor = crossInterval / 100;
            mutationCountFactor = mutationCount /100;
            mutationPowerFactor = mutationPower /100;
            currentThread = currThread;
        }

        public List<int> GetColumnsIndexes(List<Column> columns)
        {
            List<int> indexesList = new List<int>();
            foreach(Column col in columns)
            {
                indexesList.Add(col.ColumnIndex);
            }
            return indexesList;
        }
        public List<Column> CloneColumnsList(List<Column> source)
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

        public List<int> CloneIndexesList(List<int> source)
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
                populationOfSolutions = Crossing();
                //selekcja
                populationOfSolutions = Selection();
                bestIndividual = GetBestIndividual();
                //mutacja / "cykl zagłady" //DODAC CYKLE ZAGLADY
                InsertMutations();                
            }
        }

        private Individual GetBestIndividual()
        {
            Individual bestFound = populationOfSolutions.ElementAt(0);
            bestFound.CheckSolution();
            foreach(Individual i in populationOfSolutions){ //do optymalizacji
                if (i.CheckSolution() < bestFound.SolutionValue)
                {
                    bestFound = i;
                }
            }
            return bestFound;
        }

        private void InsertMutations()
        {
            Random rand = new Random();
            int individualMutationCount = Convert.ToInt32(populationOfSolutions.Count * mutationCountFactor);
            for (int i = 0; i < individualMutationCount; i++)
            {
                int individualIndex = rand.Next(populationOfSolutions.Count);
                populationOfSolutions.ElementAt(individualIndex).Mutate(mutationPowerFactor);
            }

        }

        private List<Individual> Selection()
        {
            List<Individual> afterSelection = new List<Individual>();
            int outSize = populationOfSolutions.Count / crossingSizeFactor;
            while (afterSelection.Count < outSize)
            {
                TournamentSelection(ref afterSelection, outSize);
            }
            return afterSelection;
        }

        private void TournamentSelection(ref List<Individual> afterSelection, int outSize)
        {
            CollectionActions.Shuffle(populationOfSolutions); //zmniejszamy ryzyko wylosowania dwa razy tych samych
            for(int i=0; i<populationOfSolutions.Count-2 && afterSelection.Count < outSize; i+=2) //porównujemy pary
            {
                afterSelection.Add(GetSelectedIndividual(i, i+1));
            }
        }

        private Individual GetSelectedIndividual(int index1, int index2)
        {
            Individual ind1 = populationOfSolutions.ElementAt(index1);
            Individual ind2 = populationOfSolutions.ElementAt(index2);
            return ind1.CheckSolution() <= ind2.CheckSolution() ? ind1 : ind2;
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

        private List<Individual> Crossing()
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
            MakeCrossedPopulation(ref afterCorssing, averageValue, bestIndCount);
            MakeCrossedPopulation(ref afterCorssing, averageValue*2, outPopulationSize); //*2 zrobic jako parametr
            return afterCorssing;
        }

        private List<Individual> MakeCrossedPopulation(ref List<Individual> afterCorssing, int averageValue, int outPopulationThreshold)
        {
            Random rand = new Random();
            while (afterCorssing.Count < outPopulationThreshold)
            {
                int ind1Index = rand.Next(populationOfSolutions.Count);
                int ind2Index = rand.Next(populationOfSolutions.Count);
                Individual ind1 = populationOfSolutions.ElementAt(ind1Index);
                Individual ind2 = populationOfSolutions.ElementAt(ind2Index);
                if ((ind1 != ind2) && (ind1.SolutionValue <= averageValue || ind2.SolutionValue <= averageValue))
                {
                    addCrossedPair(ind1, ind2, ref afterCorssing);
                }
            }

            return afterCorssing;
        }

        private void addCrossedPair(Individual ind1, Individual ind2, ref List<Individual> afterCorssing)
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

            //dodaje te elementy, ktore mialy zostac
            AddElementsToChild(ref ind1Child, ref ind1ColumnsPerm, ref ind1SwapPart, ref ind2SwapPart);
            AddElementsToChild(ref ind2Child, ref ind2ColumnsPerm, ref ind2SwapPart, ref ind1SwapPart);
            //Wstawia bloki wymiany
            InsertSwap(ind1Child, ind2SwapPart, commonPartPosition);
            InsertSwap(ind2Child, ind1SwapPart, commonPartPosition);
            afterCorssing.Add(new Individual(ind1Child, this));
            afterCorssing.Add(new Individual(ind2Child, this));
        }

        private void AddElementsToChild(ref List<int> child,ref List<int> parent1, ref List<int> parent1Swap, ref List<int> parent2Swap)
        {
            foreach (int column in parent1)
            {
                if (parent2Swap.Contains(column)) //jeżeli dodawany element znajduje się już we fragmencie, który uległ wymianie
                {
                    int exchageElement = parent2Swap.IndexOf(column);
                    exchageElement = parent1Swap.ElementAt(exchageElement);
                    child.Add(exchageElement);
                }
                else
                {
                    child.Add(column);
                }
            }
        }

        private void InsertSwap(List<int> child, List<int> swapPart, int commonPartPosition)
        {
            for(int i=0; i<swapPart.Count; i++)
            {
                child.Insert(commonPartPosition + i, swapPart.ElementAt(i));
            }
        }

        private int getAverageIndividualValue()
        {
            int sum = 0;
            foreach(Individual i in populationOfSolutions)
            {
                sum += i.CheckSolution();
            }
            return sum / populationOfSolutions.Count;
        }


        private void AlgorithmForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
