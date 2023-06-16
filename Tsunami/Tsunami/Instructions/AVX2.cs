using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Tsunami.Instructions;

public class AVX2
{
    internal static Vector256<int> DoVectorOperation_VectorReturn_AVX2(Vector256<int> leftVector, Vector256<int> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => Avx2.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Avx2.And(leftVector, rightVector),
            Operations.BitwiseOr => Avx2.Or(leftVector, rightVector),
            Operations.Max => Avx2.Max(leftVector, rightVector),
            Operations.Min => Avx2.Min(leftVector, rightVector),
            Operations.Subtract => Avx2.Subtract(leftVector, rightVector),
            Operations.Xor => Avx2.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    internal static Vector256<uint> DoVectorOperation_VectorReturn_AVX2(Vector256<uint> leftVector, Vector256<uint> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => Avx2.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Avx2.And(leftVector, rightVector),
            Operations.BitwiseOr => Avx2.Or(leftVector, rightVector),
            Operations.Max => Avx2.Max(leftVector, rightVector),
            Operations.Min => Avx2.Min(leftVector, rightVector),
            Operations.Subtract => Avx2.Subtract(leftVector, rightVector),
            Operations.Xor => Avx2.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    internal static Vector256<float> DoVectorOperation_VectorReturn_AVX2(Vector256<float> leftVector, Vector256<float> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => Avx2.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Avx2.And(leftVector, rightVector),
            Operations.BitwiseOr => Avx2.Or(leftVector, rightVector),
            Operations.Divide => Avx2.Divide(leftVector, rightVector),
            Operations.Max => Avx2.Max(leftVector, rightVector),
            Operations.Min => Avx2.Min(leftVector, rightVector),
            Operations.Multiply => Avx2.Multiply(leftVector, rightVector),
            Operations.Subtract => Avx2.Subtract(leftVector, rightVector),
            Operations.Xor => Avx2.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    internal static Vector256<double> DoVectorOperation_VectorReturn_AVX2(Vector256<double> leftVector, Vector256<double> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => Avx2.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Avx2.And(leftVector, rightVector),
            Operations.BitwiseOr => Avx2.Or(leftVector, rightVector),
            Operations.Max => Avx2.Max(leftVector, rightVector),
            Operations.Min => Avx2.Min(leftVector, rightVector),
            Operations.Multiply => Avx2.Multiply(leftVector, rightVector),
            Operations.Subtract => Avx2.Subtract(leftVector, rightVector),
            Operations.Divide => Avx2.Divide(leftVector, rightVector),
            Operations.Xor => Avx2.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }

}