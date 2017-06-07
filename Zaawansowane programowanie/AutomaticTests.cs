using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Zaawansowane_programowanie
{
    class AutomaticTests:MainForm
    {
        int samples = 10;
        int fragments = 10;
        int iter = 400;
        int errorCount = 0;
        string errors = "errors";
        bool cycles = false;
        int repeats = 10;
        public void Run()
        {
            errors += errorCount;
            GeneratorForm gen = new GeneratorForm(this);
            ThreadStart test1 = new ThreadStart(Test1);
            ThreadStart test6 = new ThreadStart(Test6);
            ThreadStart test2 = new ThreadStart(Test2);
            ThreadStart test3 = new ThreadStart(Test3);
            ThreadStart test4 = new ThreadStart(Test4);
            ThreadStart test0 = new ThreadStart(Test0);
            Thread thr0 = new Thread(test0);
            Thread thr6 = new Thread(test6);
            Thread thr1 = new Thread(test1);
            Thread thr2 = new Thread(test2);
            Thread thr3 = new Thread(test3);
            Thread thr4 = new Thread(test4);
            thr0.IsBackground = true;
            thr6.IsBackground = true;
            thr1.IsBackground = true;
            thr2.IsBackground = true;
            thr3.IsBackground = true;
            thr4.IsBackground = true;
            //thr0.Start();
            //thr6.Start();
            //thr1.Start();
            //thr2.Start();
            //thr3.Start();
            thr4.Start();
        }


        private void Test0()
        {
            // Liczba wierszy
            int frag = 10;
            int fragBegin = 10;
            int fragEnd = 50;
            int step = 5;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 40;
            int mutationCount = 20;
            int mutationPower = 10;

            int cyclesIterationPercent = 10;
            int cyclesSolutionLength = 40;

            //string file = "ExtermFact" + iterBegin + "_" + iterEnd+"_size"+fragments+"x"+samples+"_"+exterminationFact+".csv";
            string file = "IterResult" + fragEnd + "_" + fragEnd + "_size" + fragments + "x" + samples + "_" + iter + ".csv";
            List<List<int>> summaryResults = new List<List<int>>();
            for (frag = fragBegin; frag <= fragEnd; frag += step)
            {
                List<int> iterationResults = new List<int>();
                for (int i = 0; i < repeats; i++)
                {
                    AutomaticTests at = new AutomaticTests();
                    GeneratorForm gen = new GeneratorForm(at);
                    gen.TestsGenerator(frag,samples, errorCount);
                    AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                    iter, popSize, crossSize, bestParticipant, crossInterval,
                    mutationCount, mutationPower, "Result-> " + frag + " T1| " + i + "/" + repeats);
                    algorithmForm.CyclesEnabled = cycles;
                    algorithmForm.CycleIterationPercent = cyclesIterationPercent;
                    algorithmForm.CycleSolutionLenPercent = cyclesSolutionLength;
                    algorithmForm.Show();
                    Stopwatch watch = Stopwatch.StartNew();
                    algorithmForm.RunAlgorithm();
                    watch.Stop();
                    iterationResults.Add(algorithmForm.BestIndividual.SolutionValue);
                    //iterationResults.Add(Convert.ToInt32(watch.ElapsedMilliseconds/1000));
                    algorithmForm.Close();
                    algorithmForm.Dispose();
                    gen.Dispose();
                    at.Dispose();
                }
                summaryResults.Add(iterationResults);
            }
            SaveResults(file, summaryResults, fragBegin, fragEnd, step);
        }

        private void Test1()
        {
            // Liczba wierszy
            int frag = 10;
            int fragBegin = 10;
            int fragEnd = 50;
            int step = 5;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 40;
            int mutationCount = 20;
            int mutationPower = 10;

            int cyclesIterationPercent = 10;
            int cyclesSolutionLength = 40;

            //string file = "ExtermFact" + iterBegin + "_" + iterEnd+"_size"+fragments+"x"+samples+"_"+exterminationFact+".csv";
            string file = "Sampless" + fragEnd + "_" + fragEnd + "_size" + fragments + "x" + samples + "_" + iter + ".csv";
            List<List<int>> summaryResults = new List<List<int>>();
            for (frag = fragBegin; frag <= fragEnd; frag += step)
            {
                List<int> iterationResults = new List<int>();
                for (int i = 0; i < repeats; i++)
                {
                    AutomaticTests at = new AutomaticTests();
                    GeneratorForm gen = new GeneratorForm(at);
                    gen.TestsGenerator(fragments, frag, errorCount);
                    AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                    iter, popSize, crossSize, bestParticipant, crossInterval,
                    mutationCount, mutationPower, "Result-> " + frag + " T1| " + i + "/" + repeats);
                    algorithmForm.CyclesEnabled = cycles;
                    algorithmForm.CycleIterationPercent = cyclesIterationPercent;
                    algorithmForm.CycleSolutionLenPercent = cyclesSolutionLength;
                    algorithmForm.Show();
                    Stopwatch watch = Stopwatch.StartNew();
                    algorithmForm.RunAlgorithm();
                    watch.Stop();
                    //iterationResults.Add(algorithmForm.BestIndividual.SolutionValue);
                    iterationResults.Add(Convert.ToInt32(watch.ElapsedMilliseconds/1000));
                    algorithmForm.Close();
                    algorithmForm.Dispose();
                    gen.Dispose();
                    at.Dispose();
                }
                summaryResults.Add(iterationResults);
            }
            SaveResults(file, summaryResults, fragBegin, fragEnd, step);
        }
        private void Test6()
        {
            //Cykle zagłady
            int iterations = 5000;
            int cyclesLengthBegin = 10;
            int cyclesLengthEnd = 100;
            int step = 10;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 40;
            int mutationCount = 20;
            int mutationPower = 10;

            int cyclesIterationPercent = 10;
            int cyclesSolutionLength = 40;

            //string file = "ExtermFact" + iterBegin + "_" + iterEnd+"_size"+fragments+"x"+samples+"_"+exterminationFact+".csv";
            string file = "CyclesLength" +  cyclesLengthBegin + "_" + cyclesLengthEnd + "_size" + fragments + "x" + samples + "_" + iterations + ".csv";
            List<List<int>> summaryResults = new List<List<int>>();
            for (cyclesSolutionLength = cyclesLengthBegin; cyclesSolutionLength <= cyclesLengthEnd; cyclesSolutionLength += step)
            {
                List<int> iterationResults = new List<int>();
                for (int i = 0; i < repeats; i++)
                {
                    AutomaticTests at = new AutomaticTests();
                    GeneratorForm gen = new GeneratorForm(at);
                    gen.TestsGenerator(fragments, samples, errorCount);
                    AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                    iterations, popSize, crossSize, bestParticipant, crossInterval,
                    mutationCount, mutationPower, "ExtermLength -> " + mutationPower + " T6| " + i + "/" + repeats);
                    algorithmForm.CyclesEnabled = !cycles;
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
            SaveResults(file, summaryResults, cyclesLengthBegin, cyclesLengthEnd, step);
        }

        private void Test2()
        {
            int iterBegin = 6000;
            int iterEnd = 10000;
            int step = 1000;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 40;
            int mutationCount = 20;
            int mutationPower = 10;
            int increase = 20;
            int cyclesIterationPercent = 10;
            int cyclesSolutionLength = 40;
            for (int error = 0; error <= 0; error+=8)
            {
                int frag = fragments + increase;
                string file = "Iter" + error + iterBegin + "_" + iterEnd + "_size" + frag + "x" + samples + "_" + iterEnd + ".csv";
                List<List<int>> summaryResults = new List<List<int>>();
                for (int iterations = iterBegin; iterations <= iterEnd; iterations += step)
                {
                    List<int> iterationResults = new List<int>();
                    for (int i = 0; i < repeats; i++)
                    {
                        AutomaticTests at = new AutomaticTests();
                        GeneratorForm gen = new GeneratorForm(at);
                        gen.TestsGenerator(fragments + increase, samples, error);
                        AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                        iterations, popSize, crossSize, bestParticipant, crossInterval,
                        mutationCount, mutationPower, "iter40 -> " + error + " T4| " + i + "/" + repeats);
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
        }

        private void Test3()
        {
            int iterBegin = 100;
            int iterEnd = 8000;
            int step = 100;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 40;
            int mutationCount = 20;
            int mutationPower = 10;
            int increase = 10;
            int cyclesIterationPercent = 25;
            int cyclesSolutionLength = 80;
            for (int error = 0; error <= 0; error+=5)
            {
                int frag = fragments + increase;
                string file = "2IterErr" + error + iterBegin + "_" + iterEnd + "_size" + frag + "x" + samples + "_" + ".csv";
                List<List<int>> summaryResults = new List<List<int>>();
                for (int iterations = iterBegin; iterations <= iterEnd; iterations += step)
                {
                    List<int> iterationResults = new List<int>();
                    for (int i = 0; i < repeats; i++)
                    {
                        AutomaticTests at = new AutomaticTests();
                        GeneratorForm gen = new GeneratorForm(at);
                        gen.TestsGenerator(fragments+increase, samples, error);
                        AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                        iterations, popSize, crossSize, bestParticipant, crossInterval,
                        mutationCount, mutationPower, "iter30 -> " + error + " T4| " + i + "/" + repeats);
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
        }

        private void Test4()
        {
            //Iteracje
            int iterBegin = 300;
            int iterEnd = 1000;
            int step = 100;
            int popSize = 50;
            int crossSize = 4;
            int bestParticipant = 10;
            int crossInterval = 30;
            int mutationCount = 20;
            int mutationPower = 10;
            int cyclesIterationPercent = 25;
            int cyclesSolutionLength = 80;
            for (int error = 0; error <= 6; error+=2)
            {
                string file = "Iter" + error + iterBegin + "_" + iterEnd + "_size" + fragments + "x" + samples + "_" +iterEnd+ ".csv";
                List<List<int>> summaryResults = new List<List<int>>();
                for (int iterations = iterBegin; iterations <= iterEnd; iterations += step)
                {
                    List<int> iterationResults = new List<int>();
                    for (int i = 0; i < repeats; i++)
                    {
                        AutomaticTests at = new AutomaticTests();
                        GeneratorForm gen = new GeneratorForm(at);
                        gen.TestsGenerator(fragments, samples, error);
                        AlgorithmForm algorithmForm = new AlgorithmForm(at.allColumns,
                        iterations, popSize, crossSize, bestParticipant, crossInterval,
                        mutationCount, mutationPower, "iter20 -> " + iterations + " T4| " + i + "/" + repeats);
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
