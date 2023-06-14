using System.Numerics;
using System.Linq.Expressions;

namespace Tsunami;

public static class Tsunami<T> where T : struct, IComparable
{
    private static Func<T, T, T> DoOperationNonVect<T>(T a, T b, Operations op)
    {
        var paramA = Expression.Parameter(typeof(T), "a");
        var paramB = Expression.Parameter(typeof(T), "b");

        var addExpression = Expression.Add(paramA, paramB);
        var subtractExpression = Expression.Subtract(paramA, paramB);
        var multExpression = Expression.Multiply(paramA, paramB);
        var maxExpression = Expression.Condition(Expression.GreaterThan(paramA, paramB), paramA, paramB);
        var minExpression = Expression.Condition(Expression.LessThan(paramA, paramB), paramA, paramB);

        Expression<Func<T, T, T>> lambdaExpression;

        switch (op)
        {
            case Operations.Add:
                lambdaExpression = Expression.Lambda<Func<T, T, T>>(addExpression, paramA, paramB);
                break;
            case Operations.Subtract:
                lambdaExpression = Expression.Lambda<Func<T, T, T>>(subtractExpression, paramA, paramB);
                break;
            case Operations.Multiply:
                lambdaExpression = Expression.Lambda<Func<T, T, T>>(multExpression, paramA, paramB);
                break;
            case Operations.Max:
                lambdaExpression = Expression.Lambda<Func<T, T, T>>(maxExpression, paramA, paramB);
                break;
            case Operations.Min:
                lambdaExpression = Expression.Lambda<Func<T, T, T>>(minExpression, paramA, paramB);
                break;
            default:
                throw new ArgumentException("Unsupported operation");
        }

        Func<T, T, T> operationFunc = lambdaExpression.Compile();

        return operationFunc;
    }
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
    private static IEnumerable<T> Vec2List(Vector<T> a)
    {
        var count = Vector<T>.Count;
        var tmp = new T[count];
        a.CopyTo(tmp);
        return tmp;
    }
    private static IEnumerable<T> DoOperationsEqualLength(IEnumerable<T> one, IEnumerable<T> two, Operations op)
    {
        var count = Vector<T>.Count;
        var oneC = one
            .Chunk(count)
            .Select(x => new Vector<T>(x));
        var twoC = two
            .Chunk(count)
            .Select(x => new Vector<T>(x));
        var zipped = oneC
            .Zip(
                twoC,
                (vector, vector1) => Vec2List(
                    DoOperation(vector, vector1, op))
            );
        return zipped.SelectMany(x => x);

    }

    private static void PopulateSimd<T>(T[] array, T value) where T : struct
    {
        var vector = new Vector<T>(value);
        var i = 0;
        var s = Vector<T>.Count;
        var l = array.Length & ~(s - 1);
        for (; i < l; i += s) vector.CopyTo(array, i);
        for (; i < array.Length; i++) array[i] = value;
    }
    public static IEnumerable<T> DoOperations(IEnumerable<T> one, IEnumerable<T> two, Operations op)
    {
        var count = Vector<T>.Count;
        var one_count = one.Count();
        var two_count = two.Count();
        var fill = default(T);

        var paddingOneCount = 0;
        var paddingTwoCount = 0;
        
        if (one_count > two_count)
        {
            paddingOneCount = count - one_count % count;
            var paddingOne = new T[paddingOneCount];
            PopulateSimd(paddingOne, fill);
            one = one.Concat(paddingOne);

            paddingTwoCount = one.Count() - (two_count % count);
            var paddingTwo = new T[paddingTwoCount];
            PopulateSimd(paddingTwo, fill);
            two = two.Concat(paddingTwo);
            
        }
        else if (two_count > one_count)
        {
            paddingTwoCount = count - two_count % count;
            var paddingTwo = new T[paddingTwoCount];
            PopulateSimd(paddingTwo, fill);
            two = two.Concat(paddingTwo);

            paddingOneCount = two.Count() - (one_count % count);
            var paddingOne = new T[paddingOneCount];
            PopulateSimd(paddingOne, fill);
            one = one.Concat(paddingOne);
        }

        return DoOperationsEqualLength(one, two, op).Take(
            Math.Max(one_count, two_count)
            );
    }
}