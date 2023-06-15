namespace TsunamiTests;

public class OperatorTests
{
    private const int size = 10;
    static IEnumerable<int> DoListOps(List<int> list1, List<int> list2, Func<int, int, int> op)
    {
        var length = Math.Min(list1.Count, list2.Count);
        var ret = new List<int>(length);

        for (int i = 0; i < length; i++)
        {
            ret.Add(op(list1[i], list2[i]));
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
    
    public static bool AreEqualContents<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2)
    {
        var enumerator1 = sequence1.GetEnumerator();
        var enumerator2 = sequence2.GetEnumerator();

        bool hasNext1 = enumerator1.MoveNext();
        bool hasNext2 = enumerator2.MoveNext();

        while (hasNext1 && hasNext2)
        {
            if (!EqualityComparer<T>.Default.Equals(enumerator1.Current, enumerator2.Current))
                return false;

            hasNext1 = enumerator1.MoveNext();
            hasNext2 = enumerator2.MoveNext();
        }

        // If both enumerators reached the end, the sequences are equal
        return !hasNext1 && !hasNext2;
    }

    
    private List<int> x;
    private List<int> y;
    
    [SetUp]
    public void Setup()
    {
        x = Enumerable.Range(0, size).ToList();
        y = Enumerable.Range(0, size).ToList();
    }
    
    [Test]
    public void AddTest()
    {
        var res = DoListOps(x, y, (i, i1) => i + i1);
        var res2 = Tsunami<int>.DoOperations(x, y, Operations.Add);
        
        prettyPrint(res);
        prettyPrint(res2);
        Assert.That(AreEqualContents(res, res2));
    }
    
    [Test]
    public void SubTest()
    {
        var res = DoListOps(x, y, (i, i1) => i - i1);
        var res2 = Tsunami<int>.DoOperations(x, y, Operations.Subtract);
        prettyPrint(res);
        prettyPrint(res2);
        
        Assert.That(AreEqualContents(res, res2));
    }
    
    [Test]
    public void MultTest()
    {
        var res = DoListOps(x, y, (i, i1) => i * i1);
        var res2 = Tsunami<int>.DoOperations(x, y, Operations.Multiply);
        prettyPrint(res);
        prettyPrint(res2);
        
        Assert.That(AreEqualContents(res, res2));
    }
}