using System.Numerics;

namespace Tsunami.Instructions;

internal static class GENERIC<T> where T : struct
{
    internal static Vector<T> DoVectorOperation_VectorReturn_GENERIC(Vector<T> leftVector, Vector<T>? rightVector, Operations operation)
    {
        return rightVector.HasValue
            ? operation switch
            {
                Operations.Add => Vector.Add(leftVector, rightVector.Value),
                Operations.AndNot => Vector.AndNot(leftVector, rightVector.Value),
                Operations.BitwiseAnd => Vector.BitwiseAnd(leftVector, rightVector.Value),
                Operations.BitwiseOr => Vector.BitwiseOr(leftVector, rightVector.Value),
                Operations.Divide => Vector.Divide(leftVector, rightVector.Value),
                Operations.Max => Vector.Max(leftVector, rightVector.Value),
                Operations.Min => Vector.Min(leftVector, rightVector.Value),
                Operations.Multiply => Vector.Multiply(leftVector, rightVector.Value),
                Operations.Subtract => Vector.Subtract(leftVector, rightVector.Value),
                Operations.Xor => Vector.Xor(leftVector, rightVector.Value),
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            }
            : operation switch
            {
                Operations.SquareRoot => Vector.SquareRoot(leftVector),
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };
    }
}