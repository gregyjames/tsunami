using System.Buffers;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Tsunami;

public static class Tsunami<T> where T : struct, IComparable
{
    private static Vector<T> DoOperation(Vector<T> a, Vector<T> b, Operations op)
    {
        return op switch
        {
            Operations.Add => Vector.Add(a, b),
            Operations.Max => Vector.Max(a, b),
            Operations.Min => Vector.Min(a, b),
            Operations.Multiply => Vector.Multiply(a, b),
            Operations.Subtract => Vector.Subtract(a, b),
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };
    }

    private static readonly ArrayPool<T> _pool = ArrayPool<T>.Shared;
    private static IEnumerable<T> Vec2List(Vector<T> a)
    {
        var count = Vector<T>.Count;
        var tmp = _pool.Rent(count);
        try
        {
            a.CopyTo(tmp);
            for (var i = 0; i < count; i++)
            {
                yield return tmp[i];
            }
        }
        finally
        {
            _pool.Return(tmp);
        }
    }
    
    static int CalculateLCM(int num1, int num2)
    {
        var gcd = CalculateGCD(num1, num2);
        var lcm = (num1 * num2) / gcd;
        return lcm;
    }

    static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
    
    public static T[] DoOperations(List<T> one, List<T> two, Operations op)
    {
        var count = Vector<T>.Count;
        var maxLength = CalculateLCM(Math.Max(one.Count, two.Count),count);
        one.Resize(maxLength);
        two.Resize(maxLength);
        
        var spanOne = CollectionsMarshal.AsSpan(one);
        var spanTwo = CollectionsMarshal.AsSpan(two);

        var arr = new T[maxLength];
        var arrSpan = arr.AsSpan();
        var vectorResult = Vector<T>.Zero;
        
        for (var i = 0; i < Math.Max(one.Count, two.Count); i += count)
        {
            var s = new Vector<T>(spanOne.Slice(i, count));
            var t = new Vector<T>(spanTwo.Slice(i, count));
            vectorResult = DoOperation(s, t, op);
            vectorResult.CopyTo(arrSpan.Slice(i, count));
        }

        return arr;
    }
}

public static class ListExtensions
{
    public static void Resize<T>(this List<T> list, int newSize)
    {
        var count = list.Count;
        if (newSize > count)
        {
            list.Capacity = newSize;
            var defaultValue = default(T);
            for (var i = count; i < newSize; i++)
            {
                list.Add(defaultValue);
            }
        }
        else // newSize < count
        {
            list.RemoveRange(newSize, count - newSize);
        }
    }


}