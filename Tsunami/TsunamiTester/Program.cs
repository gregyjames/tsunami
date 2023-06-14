using System.Diagnostics;
using ConsoleTables;
using Tsunami;

double CalculatePercentageSmaller(double largerNumber, double smallerNumber)
{
    var difference = largerNumber - smallerNumber;
    var percentage = (difference / largerNumber) * 100;
    return percentage;
}

IEnumerable<int> AddLists(IEnumerable<int> list1, IEnumerable<int> list2)
{
    int maxLength = Math.Max(list1.Count(), list2.Count());

    // Extend the shorter list with default values (zeros)
    if (list1.Count() < maxLength)
    {
        int diff = maxLength - list1.Count();
        //list1.AddRange(new int[diff]);
        list1.Concat(new int[diff]);
    }
    else if (list2.Count() < maxLength)
    {
        int diff = maxLength - list2.Count();
        list2.Concat(new int[diff]);
    }

    return list1.Zip(list2, (i, i1) => i + i1);

}

void prettyPrint(IEnumerable<int> source)
{
    Console.Write("\n");
    foreach (var e in source)
    {
        Console.Write(e + " -> ");
    }
}

var sizes = new[] {
    10_000,
    100_000,
    1_000,000,
    10_000_000,
    100_000_000
};

var table = new ConsoleTable("Count", "Tsunami", "Normal", "Equal?", "% Diff");

Thread.Sleep(5000);
foreach (var size in sizes)
{
    var x = Enumerable.Range(0, size).ToList();
    var y = Enumerable.Range(0, size).ToList();
    var watch = new Stopwatch();
    watch.Start();
    var l = Tsunami<int>.DoOperations(x, y, Operations.Add);
    watch.Stop();
    var elapsed1 = watch.Elapsed.TotalMilliseconds;
    var sss = ($"{elapsed1} ms");
    watch.Reset();
    
    watch.Start();
    var ll = AddLists(x, y);
    watch.Stop();
    var elapsed2 = watch.Elapsed.TotalMilliseconds;
    var ttt = ($"{elapsed2} ms");
    table.AddRow(size, sss, ttt, l.SequenceEqual(ll), CalculatePercentageSmaller(elapsed2, elapsed1));
}

table.Write(Format.Minimal);

