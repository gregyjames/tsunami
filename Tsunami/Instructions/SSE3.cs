using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Tsunami.Instructions;

public class SSE3
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector128<int> DoVectorOperation_VectorReturn_Sse3(ref Vector128<int> leftVector, ref Vector128<int> rightVector, ref Operations operation)
    {
        return operation switch
        {
            Operations.Add => Sse3.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Sse3.And(leftVector, rightVector),
            Operations.BitwiseOr => Sse3.Or(leftVector, rightVector),
            Operations.Subtract => Sse3.Subtract(leftVector, rightVector),
            Operations.Xor => Sse3.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector128<uint> DoVectorOperation_VectorReturn_Sse3(ref Vector128<uint> leftVector, ref Vector128<uint> rightVector, ref Operations operation)
    {
        return operation switch
        {
            Operations.Add => Sse3.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Sse3.And(leftVector, rightVector),
            Operations.BitwiseOr => Sse3.Or(leftVector, rightVector),
            Operations.Subtract => Sse3.Subtract(leftVector, rightVector),
            Operations.Xor => Sse3.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector128<float> DoVectorOperation_VectorReturn_Sse3(ref Vector128<float> leftVector, ref Vector128<float> rightVector, ref Operations operation)
    {
        return operation switch
        {
            Operations.Add => Sse3.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Sse3.And(leftVector, rightVector),
            Operations.BitwiseOr => Sse3.Or(leftVector, rightVector),
            Operations.Divide => Sse3.Divide(leftVector, rightVector),
            Operations.Max => Sse3.Max(leftVector, rightVector),
            Operations.Min => Sse3.Min(leftVector, rightVector),
            Operations.Multiply => Sse3.Multiply(leftVector, rightVector),
            Operations.Subtract => Sse3.Subtract(leftVector, rightVector),
            Operations.Xor => Sse3.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector128<double> DoVectorOperation_VectorReturn_Sse3(ref Vector128<double> leftVector, ref Vector128<double> rightVector, ref Operations operation)
    {
        return operation switch
        {
            Operations.Add => Sse3.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Sse3.And(leftVector, rightVector),
            Operations.BitwiseOr => Sse3.Or(leftVector, rightVector),
            Operations.Max => Sse3.Max(leftVector, rightVector),
            Operations.Min => Sse3.Min(leftVector, rightVector),
            Operations.Multiply => Sse3.Multiply(leftVector, rightVector),
            Operations.Subtract => Sse3.Subtract(leftVector, rightVector),
            Operations.Divide => Sse3.Divide(leftVector, rightVector),
            Operations.Xor => Sse3.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
}