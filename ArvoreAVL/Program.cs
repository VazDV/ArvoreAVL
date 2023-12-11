using ArvoreAVL;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        AVLTree avlTree = new AVLTree();

        Stopwatch stopwatchSetAVL = new Stopwatch();
        Stopwatch stopwatchPrintAVL = new Stopwatch();
        Stopwatch stopwatchTotalAVL = new Stopwatch();
        
        Stopwatch stopwatchSetMG = new Stopwatch();
        Stopwatch stopwatchPrintMG = new Stopwatch();
        Stopwatch stopwatchTotalMG = new Stopwatch();

        stopwatchTotalAVL.Start();
        stopwatchSetAVL.Start();

        avlTree.InsertDataFromFile("D:\\ArvoreAVL\\ArvoreAVL\\dados100_mil.txt");

        stopwatchSetAVL.Stop();

        stopwatchPrintAVL.Start();

        avlTree.PrintInOrder();
        
        stopwatchPrintAVL.Stop();
        
        stopwatchTotalAVL.Stop();


        //SEGUNDA PARTE
        string content = File.ReadAllText("D:\\ArvoreAVL\\ArvoreAVL\\dados100_mil.txt");
        int[] numbers = content
            .Trim('[', ']')
            .Split(',')
            .Select(s => int.Parse(s.Trim()))
            .ToArray();

        stopwatchTotalMG.Start();
        stopwatchSetMG.Start();

        MergeSort.Sort(numbers, 0, numbers.Length - 1);

        stopwatchSetMG.Stop();

        stopwatchPrintMG.Start();
        Console.WriteLine("Dados ordenados:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        stopwatchPrintMG.Stop();
        stopwatchTotalMG.Stop();


        Console.WriteLine("\n\nTempo para inserir dados: " + stopwatchSetAVL.ElapsedMilliseconds + " ms");
        Console.WriteLine("Tempo para imprimir dados: " + stopwatchPrintAVL.ElapsedMilliseconds + " ms");
        Console.WriteLine("Tempo de execução: " + stopwatchTotalAVL.ElapsedMilliseconds + " ms");
        Console.WriteLine("\n\nTempo para ordenar dados usando Merge Sort: " + stopwatchSetMG.ElapsedMilliseconds + " ms");
        Console.WriteLine("Tempo para imprimir dados: " + stopwatchPrintMG.ElapsedMilliseconds + " ms");
        Console.WriteLine("Tempo de execução: " + stopwatchTotalMG.ElapsedMilliseconds + " ms");
    }
}