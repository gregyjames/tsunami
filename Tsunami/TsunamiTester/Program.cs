using System.Diagnostics;
using ConsoleTables;
using Tsunami;

double CalculatePercentageSmaller(double largerNumber, double smallerNumber)
{
    var difference = largerNumber - smallerNumber;
    var percentage = (difference / largerNumber) * 100;
    return percentage;
}

static IEnumerable<int> AddLists(List<int> list1, List<int> list2)
{
    var length = Math.Min(list1.Count, list2.Count);
    var ret = new List<int>(length);

    for (int i = 0; i < length; i++)
    {
        ret.Add(list1[i] + list2[i]);
    }

    return ret;
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
    1_000_000,
    10_000_000,
    100_000_000,
    250_000_000,
    500_000_000
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
    
    table.AddRow(size, sss, ttt, l.SequenceEqual(ll), CalculatePercentageSmaller(Math.Max(elapsed1, elapsed2), Math.Min(elapsed1,elapsed2)));
}

table.Write(Format.Minimal);

