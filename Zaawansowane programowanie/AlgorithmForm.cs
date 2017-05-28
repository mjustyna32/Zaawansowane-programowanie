﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Zaawansowane_programowanie
{
    public partial class AlgorithmForm : Form
    {
        private bool terminate = false;
        private int iterations;
        private int populationSize;
        private List<Individual> populationOfSolutions;
        private List<Column> allInstanceColumns;
        private List<int> columnsIndexes;
        private List<int> onesInRows;
        private int crossingSizeFactor = 4;
        private float bestIndividualParticipanceFactor = (float) 0.1;
        private float crossingIntervalFactor =(float) 0.5;
        private float mutationCountFactor = (float)0.2;
        private float mutationPowerFactor = (float)0.2;
        private volatile Individual bestIndividual = null;
        private bool exterminationCycle=false;
        private float exterminationFactor = (float)0.5;
        private float percentOfIterationCycle = (float)0.1;
        private float percentOfSolutionLenCycle = (float)0.4;
        private int lastChartRefresh = 0;
        public bool CyclesEnabled
        {
            get { return exterminationCycle; }
            set { exterminationCycle = value; }
        }
        public Individual BestIndividual
        {
            get { return bestIndividual; }
        }

        public int CycleIterationPercent
        {
            get { return Convert.ToInt32(percentOfIterationCycle * 100); }
            set { percentOfIterationCycle = (float)value / 100; }
        }
        public int CycleSolutionLenPercent
        {
            get { return Convert.ToInt32(percentOfSolutionLenCycle * 100); }
            set { percentOfSolutionLenCycle = (float)value / 100; }
        }

        private delegate void InvokeDelegate(Individual i);
        private delegate void InvokeProgressBar(int i);
        private delegate void InvokeChart();
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
        public AlgorithmForm(List<Column> columns, int iter, int popSize, int crossSize, int bestsParticipant,int crossInterval, int mutationCount, int mutationPower, string text = "Algorytm", float extermFactor = (float)0.5)
        {
            InitializeComponent();
            allInstanceColumns = CloneColumnsList(columns);
            columnsIndexes = GetColumnsIndexes(allInstanceColumns);
            onesInRows = SumRows(allInstanceColumns);
            populationOfSolutions = new List<Individual>();
            iterations = iter;
            populationSize = popSize;
            crossingSizeFactor = crossSize;
            bestIndividualParticipanceFactor = (float)bestsParticipant /100;
            crossingIntervalFactor = (float)crossInterval / 100;
            mutationCountFactor = (float)mutationCount /100;
            mutationPowerFactor = (float)mutationPower /100;
            exterminationFactor = extermFactor;
            this.Text = text;
        }
       
        private List<int> SumRows(List<Column> allInstanceColumns)
        {
            int rowCount = GetColumnObjectAt(0).GetRowsCount;
            List<int> onesCount = new List<int>();
            for(int row=0; row<rowCount; row++)
            {
                int sum = 0;
                foreach(Column col in allInstanceColumns)
                {
                    if (col.GetRowValueAt(row))
                        sum += 1;
                }
                onesCount.Add(sum);
            }
            return onesCount;
        }

        public int GetOnesCountInRow(int row)
        {
            return onesInRows.ElementAt(row);
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

            Application.DoEvents();
            PrepareBasicPopulation();
            int bestSolutionValue = -1;
            int lastBestFound = 0;
            Individual currentBest;
            for (int i = 0; i < iterations && !terminate && bestSolutionValue != 0; i++)
            {
                populationOfSolutions = Crossing();
                CountSolutionsValues();
                populationOfSolutions = Selection();
                currentBest = GetBestIndividual();
                if (SaveBestIndividual(currentBest))
                    lastBestFound = i;
                bestSolutionValue = bestIndividual.SolutionValue;
                
                if (CyclesEnabled && IterationElapsed(lastBestFound, i))
                {
                    lastBestFound = i;
                    Extermination();
                }
                else
                    InsertMutations();

                try
                {
                    int percent = (i * 100) / iterations;
                    UpdateValuesOnBarAndChart(percent); // poprawić odświeżanie
                }
                catch(Exception e)
                {
                    //MessageBox.Show(e.StackTrace);
                    break;
                }
            }
            /*
            if (bestIndividual.SolutionValue == 0)
            {
                bestIndividual.CheckSolution();
            }
            */
            UpdateProgrssBar(100); //ewentualnie do usuniecia
        }

        private void CountSolutionsValues()
        {
            foreach(Individual i in populationOfSolutions)
            {
                i.CheckSolution();
            }
        }

        private void TestsSaver()
        {
            string line = iterations.ToString() + ", " + bestIndividual.SolutionValue;
            string fileName = "plik.txt";
            System.IO.StreamWriter wr = new System.IO.StreamWriter(fileName);
            wr.WriteLine(line);
            wr.Close();
        }
        /*
        private void Extermination()
        {
            Random rand = new Random();   
            foreach(Individual i in populationOfSolutions)
            {
                int individualLength = i.Columns.Count;
                int mutatedIntervalSize = individualLength*CycleSolutionLenPercent/100;
                int startingPosition = rand.Next(individualLength - mutatedIntervalSize);
                i.MutateFragment(startingPosition, mutatedIntervalSize);
            }
        }
        */
        private void Extermination()
        {
            float prevMutationCount = mutationCountFactor;
            float prevMutationPower = mutationPowerFactor;
            mutationCountFactor = 1;
            mutationPowerFactor = (float)0.5;
            InsertMutations();
            mutationCountFactor = prevMutationCount;
            mutationPowerFactor = prevMutationPower;
        }

        private bool IterationElapsed(int lastBestFound, int i)
        {
            int interval = Convert.ToInt32(iterations * percentOfIterationCycle);
            if (i - lastBestFound > interval)
                return true;
            else
                return false;
        }

        private Individual GetBestIndividual()
        {
            Individual bestFound = populationOfSolutions.ElementAt(0);
            foreach (Individual i in populationOfSolutions)
            {
                if (i.SolutionValue < bestFound.SolutionValue)
                {
                    bestFound = i;
                }
            }
            return bestFound;
        }

        private bool SaveBestIndividual(Individual currentBest)
        {
            bool decision = false;
            if (bestIndividual == null)
            {
                bestIndividual = currentBest;
                decision = true;
            }
            else if (currentBest.SolutionValue < bestIndividual.SolutionValue)
            {
                bestIndividual = currentBest.GetObjectCopy();
                bestIndividual.CheckSolution();
                decision=true;
            }
            return decision;
        }

        private void UpdateValuesOnBarAndChart(int percent)
        {
            UpdateProgrssBar(percent);
            UpdateChart();
        }

        private void UpdateChart()
        {
            int currentSecond = DateTime.Now.Second;

            if (this.InvokeRequired)
            {
                InvokeChart ic= new InvokeChart(UpdateChart);
                this.Invoke(ic);
            }
            else
            {
                chart1.Series[0].Points.AddY(bestIndividual.SolutionValue);
            }
            if (currentSecond - lastChartRefresh == 1)
            {
                lastChartRefresh = currentSecond;
                chart1.Update();
            }
        }
        private void UpdateProgrssBar(int percent)
        {
            if (this.progressBar1.InvokeRequired)
            {
                InvokeProgressBar invokeDel = new InvokeProgressBar(UpdateProgrssBar);
                this.Invoke(invokeDel, percent);
            }
            else
            {
                progressBar1.Value = percent;
            }
        }

        private void PrintIndividual(Individual individual)
        {
            string outStr= "";
            string toDelete = "";
            foreach(int element in individual.Columns)
            {
                outStr += " " + element;
            }
            foreach (int element in individual.ColumnsToDelete)
            {
                toDelete += " " + element;
            }
            if (this.textBox1.InvokeRequired)
            {
                InvokeDelegate invokeDel = new InvokeDelegate(PrintIndividual);
                this.Invoke(invokeDel, individual);
            }
            else
            {
                textBox1.AppendText(individual.SolutionValue.ToString()+" -> "+toDelete+Environment.NewLine+outStr + Environment.NewLine);
                string outLine = "";
                for(int row =0; row< allInstanceColumns.ElementAt(0).GetRowsCount; row++)
                {
                   foreach(int col in bestIndividual.Columns)
                    {
                       outLine+= GetColumnObjectAt(col).GetRowValueAtInt(row) + " ";
                    }
                    outLine += Environment.NewLine;

                }
                textBox1.AppendText(outLine);
                
            }
           
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
            /* Selekcja
             * Daną mamy listę wszystkich osobników w populacji
             * Listę mieszamy w sposób losowy
             * Następnie iterujemy po parach osobników i zwracamy do populacji wyjściowej lepszy osobnik z pary
             * Powtarzamy to tak długo, aż uzyskamy żądany rozmiar populacji wyjściowej.             *
             */
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
            new CollectionActions().Shuffle(ref populationOfSolutions); //zmniejszamy ryzyko wylosowania dwa razy tych samych
            for(int i=0; i<populationOfSolutions.Count-2 && afterSelection.Count < outSize; i+=2) //porównujemy pary
            {
                afterSelection.Add(GetSelectedIndividual(i, i+1));
            }
        }

        private Individual GetSelectedIndividual(int index1, int index2)
        {
            Individual ind1 = populationOfSolutions.ElementAt(index1);
            Individual ind2 = populationOfSolutions.ElementAt(index2);
            return ind1.SolutionValue <= ind2.SolutionValue ? ind1 : ind2;
        }

        private void PrepareBasicPopulation()
        {
            for (int i = 0; i<populationSize; i++)
            {
                List<int> clonedIndexes = CloneIndexesList(columnsIndexes);
                new CollectionActions().Shuffle(ref clonedIndexes);
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
            //KRZYŻOWANIE Z CZĘŚCIOWYM ODWZOROWANIEM
            Random rand = new Random();
            List<Individual> afterCorssing = new List<Individual>();
            int averageValue = GetAverageIndividualValue();
            int outPopulationSize = populationOfSolutions.Count * crossingSizeFactor;
            int bestIndCount = Convert.ToInt32(outPopulationSize * bestIndividualParticipanceFactor);



            //DO POPRAWY, DODAWAĆ KOPIE NAJLEPSZEGO
            //zabezpieczyc na wypadek gdyby bylo zbyt malo ponizej sredniej
            AddBestCopies(ref afterCorssing, bestIndCount);
            //MakeCrossedPopulation(ref afterCorssing, averageValue, bestIndCount);
            MakeCrossedPopulation(ref afterCorssing, averageValue*2, outPopulationSize); //*2 zrobic jako parametr
            return afterCorssing;
        }

        private void AddBestCopies(ref List<Individual> afterCorssing, int bestIndCount)
        {
            if(bestIndividual == null)
            {
                return;
            }
            while (bestIndCount > 0)
            {
                afterCorssing.Add(bestIndividual.GetObjectCopy());
                bestIndCount--;
            }
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
                    AddCrossedPair(ind1, ind2, ref afterCorssing);
                }
            }

            return afterCorssing;
        }

        private void AddCrossedPair(Individual ind1, Individual ind2, ref List<Individual> afterCorssing)
        {
            Random rand = new Random();
            List<int> ind1ColumnsPerm = ind1.Columns;
            List<int> ind1Child = new List<int>();
            List<int> ind2ColumnsPerm = ind2.Columns;
            List<int> ind2Child = new List<int>();
            int crossingIntervalLength = Convert.ToInt32(ind1ColumnsPerm.Count * crossingIntervalFactor);
            int commonPartPosition = rand.Next(ind1ColumnsPerm.Count - crossingIntervalLength);
            List<int> ind1SwapPart = ind1ColumnsPerm.GetRange(commonPartPosition, crossingIntervalLength).ToList();
            List<int> ind2SwapPart = ind2ColumnsPerm.GetRange(commonPartPosition, crossingIntervalLength).ToList();
            //dodaje te elementy, ktore mialy zostac
            Dictionary<int, int> swapImage = MakeSwapImage(ind2SwapPart, ind1SwapPart);
            AddElementsToChild(ref ind1Child, ref ind1ColumnsPerm, ref ind1SwapPart, ref ind2SwapPart, swapImage); //WSTAWIA TAKZE ZE SWAPOW I JEST ZA DUZO
            swapImage = MakeSwapImage(ind1SwapPart, ind2SwapPart);
            AddElementsToChild(ref ind2Child, ref ind2ColumnsPerm, ref ind2SwapPart, ref ind1SwapPart,swapImage);
            //Wstawia bloki wymiany
            InsertSwap(ind1Child, ind2SwapPart, commonPartPosition);
            InsertSwap(ind2Child, ind1SwapPart, commonPartPosition);
            afterCorssing.Add(new Individual(ind1Child, this));
            afterCorssing.Add(new Individual(ind2Child, this));
        }

        private Dictionary<int, int> MakeSwapImage(List<int> ind1SwapPart, List<int> ind2SwapPart)
        {
            Dictionary<int, int> outDic = new Dictionary<int, int>();
            for(int i=0; i<ind1SwapPart.Count; i++)
            {

                outDic.Add(ind1SwapPart.ElementAt(i), ind2SwapPart.ElementAt(i));
            }
            return outDic;

        }

        
        private void AddElementsToChild(ref List<int> child,ref List<int> parent1, ref List<int> parent1Swap, ref List<int> parent2Swap, Dictionary<int, int> swapImage)
        {
            
            foreach (int column in parent1)
            {
                if (parent2Swap.Contains(column) && !parent1Swap.Contains(column)) //jeżeli dodawany element znajduje się już we fragmencie, który uległ wymianie
                {
                    int exchangeElement = GetImagedValue(column, swapImage);
                    child.Add(exchangeElement);
                }
                else if(!parent1Swap.Contains(column))
                {
                    child.Add(column);
                }
            }
        }

        private int GetImagedValue(int value, Dictionary<int, int> swapImage)
        {
            int outValue = swapImage[value];
            if (swapImage.ContainsKey(outValue))
                return GetImagedValue(outValue, swapImage);
            else
                return outValue;
        }

        private void InsertSwap(List<int> child, List<int> swapPart, int commonPartPosition)
        {
            for(int i=0; i<swapPart.Count; i++)
            {
                child.Insert(commonPartPosition + i, swapPart.ElementAt(i));
            }
        }

        private int GetAverageIndividualValue()
        {
            int sum = 0;
            foreach(Individual i in populationOfSolutions)
            {
                sum += i.CheckSolution();
            }
            return sum / populationOfSolutions.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            terminate = true;
            this.Close();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["resultPage"])
            {
                PrintIndividual(bestIndividual); //REFRESH
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            terminate = true;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            PrintIndividual(bestIndividual);
        }

        private void AlgorithmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            terminate = true;
            e.Cancel = true;
            this.Hide();
        }
    }
}
