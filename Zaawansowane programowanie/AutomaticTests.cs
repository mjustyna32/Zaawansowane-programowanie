using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Zaawansowane_programowanie
{
    class AutomaticTests:MainForm
    {
        int samples = 10;
        int fragments = 20;
        int errSamplesPerc = 0;
        int errFragmentPerc = 0;
        bool cycles = false;
        int repeats = 10;
        public void Run()
        {
            GeneratorForm gen = new GeneratorForm(this);
            ThreadStart test1 = new ThreadStart(Test1);
            ThreadStart test2 = new ThreadStart(Test2);
            ThreadStart test3 = new ThreadStart(Test3);
            ThreadStart test4 = new ThreadStart(Test4);
            Thread thr1 = new Thread(test1);
            Thread thr2 = new Thread(test2);
            Thread thr3 = new Thread(test3);
            Thread thr4 = new Thread(test4);
            thr1.IsBackground = true;
            thr2.IsBackground = true;
            thr3.IsBackground = true;
            thr4.IsBackground = true;
            thr1.Start();
            thr2.Start();
            thr3.Start();
            thr4.Start();

            //Test1();
            //Test2();
            //Test3();
        }


        private void Test0()
        {
            //mutation Count
            //Siła 30%
            int iterations = 400;
            int mutationBegin = 10;
            int mutationCount = mutationBegin;
            int mutationPower = 30;
            int mutationEnd = 100;
            int step = 10;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 40;

            int cyclesIterationPercent = 10;
            int cyclesSolutionLength = 40;
            float exterminationFact = (float)0.4;

            //string file = "ExtermFact" + iterBegin + "_" + iterEnd+"_size"+fragments+"x"+samples+"_"+exterminationFact+".csv";
            string file = "MutationCount" + mutationCount + "_" + mutationEnd + "_size" + fragments + "x" + samples + ".csv";
            List<List<int>> summaryResults = new List<List<int>>();
            for (; mutationCount <= mutationEnd; mutationCount += step)
            {
                List<int> iterationResults = new List<int>();
                for (int i = 0; i < repeats; i++)
                {
                    AutomaticTests at = new AutomaticTests();
                    GeneratorForm gen = new GeneratorForm(at);
                    gen.TestsGenerator(fragments, samples, errSamplesPerc, errFragmentPerc);
                    AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                    iterations, popSize, crossSize, bestParticipant, crossInterval,
                    mutationCount, mutationPower, "MutCount -> " + mutationCount + " T0| " + i + "/" + repeats, exterminationFact);
                    algorithmForm.CyclesEnabled = cycles;
                    algorithmForm.CycleIterationPercent = cyclesIterationPercent;
                    algorithmForm.CycleSolutionLenPercent = cyclesSolutionLength;
                    algorithmForm.Show();
                    algorithmForm.RunAlgorithm();
                    iterationResults.Add(algorithmForm.BestIndividual.SolutionValue);
                    algorithmForm.Close();
                    algorithmForm.Dispose();
                    gen.Dispose();
                    at.Dispose();
                }
                summaryResults.Add(iterationResults);
            }
            SaveResults(file, summaryResults, mutationBegin, mutationEnd, step);
        }


        //Macierz 20x10 - bez błędów
        private void Test1()
        {
            //Mutation Power //30%populacji
            int iterations = 400;
            int mutationBegin = 10;
            int mutationCount = 30;
            int mutationPower = mutationBegin;
            int mutationEnd = 100;
            int step = 10;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 40;
           
            int cyclesIterationPercent = 10;
            int cyclesSolutionLength = 40;
            float exterminationFact = (float)0.4;

            //string file = "ExtermFact" + iterBegin + "_" + iterEnd+"_size"+fragments+"x"+samples+"_"+exterminationFact+".csv";
            string file = "MutationPower" + mutationPower + "_" + mutationEnd + "_size" + fragments + "x" + samples + ".csv";
            List<List<int>> summaryResults = new List<List<int>>();
            for(; mutationPower<=mutationEnd; mutationPower += step)
            {
                List<int> iterationResults = new List<int>();
                for (int i = 0; i < repeats; i++)
                {
                    AutomaticTests at = new AutomaticTests();
                    GeneratorForm gen = new GeneratorForm(at);
                    gen.TestsGenerator(fragments, samples, errSamplesPerc, errFragmentPerc);
                    AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                    iterations, popSize, crossSize, bestParticipant, crossInterval, 
                    mutationCount, mutationPower, "iter -> " + mutationPower + " T1| " + i + "/" + repeats, exterminationFact);
                    algorithmForm.CyclesEnabled = cycles;
                    algorithmForm.CycleIterationPercent = cyclesIterationPercent;
                    algorithmForm.CycleSolutionLenPercent = cyclesSolutionLength;
                    algorithmForm.Show();
                    algorithmForm.RunAlgorithm();
                    iterationResults.Add(algorithmForm.BestIndividual.SolutionValue);
                    algorithmForm.Close();
                    algorithmForm.Dispose();
                    gen.Dispose();
                    at.Dispose();
                }
                summaryResults.Add(iterationResults);
            }
            SaveResults(file, summaryResults, mutationBegin, mutationEnd, step);
        }

        private void Test2()
        {
            //wspolczynnik krzyzowania
            int crossBegin = 2;
            int crossSize = crossBegin;
            int crossEnd = 12;
            int step = 1;
            int iterations = 400;
            int popSize = 50;
            int bestParticipant = 10;
            int crossInterval = 40;
            int mutationCount = 20;
            int mutationPower = 10;
            int cyclesIterationPercent = 10;
            int cyclesSolutionLength = 40;
            float exterminationFact = (float)0.5;

            string file = "CrossFactor" + crossBegin+ "_" + crossEnd+ "_size" + fragments + "x" + samples + ".csv";
            List<List<int>> summaryResults = new List<List<int>>();
            for (;crossSize<=crossEnd; crossSize+= step)
            {
                List<int> iterationResults = new List<int>();
                for (int i = 0; i < repeats; i++)
                {
                    AutomaticTests at = new AutomaticTests();
                    GeneratorForm gen = new GeneratorForm(at);
                    gen.TestsGenerator(fragments, samples, errSamplesPerc, errFragmentPerc);
                    AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                    iterations, popSize, crossSize, bestParticipant, crossInterval,
                    mutationCount, mutationPower, "CrossSize -> " + crossSize + " T2| " + i + "/" + repeats, exterminationFact);
                    algorithmForm.CyclesEnabled = cycles;
                    algorithmForm.CycleIterationPercent = cyclesIterationPercent;
                    algorithmForm.CycleSolutionLenPercent = cyclesSolutionLength;
                    algorithmForm.Show();
                    algorithmForm.RunAlgorithm();
                    iterationResults.Add(algorithmForm.BestIndividual.SolutionValue);
                    algorithmForm.Close();
                    algorithmForm.Dispose();
                    gen.Dispose();
                    at.Dispose();
                }
                summaryResults.Add(iterationResults);
            }
            SaveResults(file, summaryResults, crossBegin, crossEnd, step);
        }

        private void Test3()
        {
            //rozmiar przedzialu krzyzowania
            int iterBegin = 300;
            int iterEnd = 3000;
            int step = 300;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 40;
            int mutationCount = 20;
            int mutationPower = 10;
            int cyclesIterationPercent = 10;
            int cyclesSolutionLength = 40;
            float exterminationFact = (float)0.6;

            string file = "ExtermFact" + iterBegin + "_" + iterEnd + "_size" + fragments + "x" + samples + "_" + exterminationFact + ".csv";
            List<List<int>> summaryResults = new List<List<int>>();
            for (int iterations = iterBegin; iterations <= iterEnd; iterations += step)
            {
                List<int> iterationResults = new List<int>();
                for (int i = 0; i < repeats; i++)
                {
                    AutomaticTests at = new AutomaticTests();
                    GeneratorForm gen = new GeneratorForm(at);
                    gen.TestsGenerator(fragments, samples, errSamplesPerc, errFragmentPerc);
                    AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                    iterations, popSize, crossSize, bestParticipant, crossInterval,
                    mutationCount, mutationPower, "iter -> " + iterations + " T3| " + i + "/" + repeats, exterminationFact);
                    algorithmForm.CyclesEnabled = cycles;
                    algorithmForm.CycleIterationPercent = cyclesIterationPercent;
                    algorithmForm.CycleSolutionLenPercent = cyclesSolutionLength;
                    algorithmForm.Show();
                    algorithmForm.RunAlgorithm();
                    iterationResults.Add(algorithmForm.BestIndividual.SolutionValue);
                    algorithmForm.Close();
                    algorithmForm.Dispose();
                    gen.Dispose();
                    at.Dispose();
                }
                summaryResults.Add(iterationResults);
            }
            SaveResults(file, summaryResults, iterBegin, iterEnd, step);
        }

        private void Test4()
        {
            //udzial najlepszych
            int iterBegin = 300;
            int iterEnd = 3000;
            int step = 300;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 40;
            int mutationCount = 20;
            int mutationPower = 10;
            int cyclesIterationPercent = 10;
            int cyclesSolutionLength = 40;
            float exterminationFact = (float)0.7;

            string file = "ExtermFact" + iterBegin + "_" + iterEnd + "_size" + fragments + "x" + samples + "_" + exterminationFact + ".csv";
            List<List<int>> summaryResults = new List<List<int>>();
            for (int iterations = iterBegin; iterations <= iterEnd; iterations += step)
            {
                List<int> iterationResults = new List<int>();
                for (int i = 0; i < repeats; i++)
                {
                    AutomaticTests at = new AutomaticTests();
                    GeneratorForm gen = new GeneratorForm(at);
                    gen.TestsGenerator(fragments, samples, errSamplesPerc, errFragmentPerc);
                    AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                    iterations, popSize, crossSize, bestParticipant, crossInterval,
                    mutationCount, mutationPower, "iter -> " + iterations + " T4| " + i + "/" + repeats, exterminationFact);
                    algorithmForm.CyclesEnabled = cycles;
                    algorithmForm.CycleIterationPercent = cyclesIterationPercent;
                    algorithmForm.CycleSolutionLenPercent = cyclesSolutionLength;
                    algorithmForm.Show();
                    algorithmForm.RunAlgorithm();
                    iterationResults.Add(algorithmForm.BestIndividual.SolutionValue);
                    algorithmForm.Close();
                    algorithmForm.Dispose();
                    gen.Dispose();
                    at.Dispose();
                }
                summaryResults.Add(iterationResults);
            }
            SaveResults(file, summaryResults, iterBegin, iterEnd, step);

        }
        public void SaveResults(string file, List<List<int>> results, int headerBegin, int headerEnd, int step)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\Users\\Marek\\Documents\\Testy_ZP\\"+file);
            SaveHeader(sw, headerBegin, headerEnd, step);
            string table = "";
            for(int row = 0; row< results.ElementAt(0).Count; row++)
            {
                for(int col=0; col<results.Count; col++)
                {
                    int value = results.ElementAt(col).ElementAt(row);
                    table += value + ",";

                }
                table += Environment.NewLine;
            }
            sw.WriteLine(table);
            sw.Close();
            
        }
        private void SaveHeader(System.IO.StreamWriter file, int headerBegin, int headerEnd, int step)
        {
            string header = "";
            for(int i=headerBegin; i<=headerEnd; i += step)
            {
                header += i + ",";
            }
            file.WriteLine(header);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AutomaticTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(886, 441);
            this.Name = "AutomaticTests";
            this.ResumeLayout(false);

        }
    }
}
