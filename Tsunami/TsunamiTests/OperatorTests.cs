namespace TsunamiTests;

public class OperatorTests
{
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

    private List<int> x;
    private List<int> y;
    
    [SetUp]
    public void Setup()
    {
        x = Enumerable.Range(0, 100).ToList();
        y = Enumerable.Range(0, 100).ToList();
    }
    
    [Test]
    public void AddTest()
    {
        var res = DoListOps(x, y, (i, i1) => i + i1);
        var res2 = Tsunami<int>.DoOperations(x, y, Operations.Add);
        
        Assert.That(res.SequenceEqual(res2));
    }
    
    [Test]
    public void SubTest()
    {
        var res = DoListOps(x, y, (i, i1) => i - i1);
        var res2 = Tsunami<int>.DoOperations(x, y, Operations.Subtract);
        
        Assert.That(res.SequenceEqual(res2));
    }
    
    [Test]
    public void MultTest()
    {
        var res = DoListOps(x, y, (i, i1) => i * i1);
        var res2 = Tsunami<int>.DoOperations(x, y, Operations.Multiply);
        
        Assert.That(res.SequenceEqual(res2));
    }
}