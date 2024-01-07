using System.Numerics;
using System.Runtime.CompilerServices;

namespace Tsunami.Instructions;

internal static class GENERIC<T> where T : struct
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector<T> DoVectorOperation_VectorReturn_GENERIC(ref Vector<T> leftVector, ref Vector<T> rightVector, Operations operation)
    {
        return rightVector != null
            ? operation switch
            {
                Operations.Add => Vector.Add(leftVector, rightVector),
                Operations.AndNot => Vector.AndNot(leftVector, rightVector),
                Operations.BitwiseAnd => Vector.BitwiseAnd(leftVector, rightVector),
                Operations.BitwiseOr => Vector.BitwiseOr(leftVector, rightVector),
                Operations.Divide => Vector.Divide(leftVector, rightVector),
                Operations.Max => Vector.Max(leftVector, rightVector),
                Operations.Min => Vector.Min(leftVector, rightVector),
                Operations.Multiply => Vector.Multiply(leftVector, rightVector),
                Operations.Subtract => Vector.Subtract(leftVector, rightVector),
                Operations.Xor => Vector.Xor(leftVector, rightVector),
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            }
            : operation switch
            {
                Operations.SquareRoot => Vector.SquareRoot(leftVector),
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector<T> DoScalarOperation_VectorReturn_GENERIC(ref T a, ref Vector<T> b, Operations op)
    {
        return op switch
        {
            Operations.MultScalar => Vector.Multiply(a, b),
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };
    }
}