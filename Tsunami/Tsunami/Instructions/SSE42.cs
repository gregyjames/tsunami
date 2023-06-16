using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Tsunami.Instructions;

public class SSE42
{
    internal static Vector128<int> DoVectorOperation_VectorReturn_Sse42(Vector128<int> leftVector, Vector128<int> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => Sse42.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Sse42.And(leftVector, rightVector),
            Operations.BitwiseOr => Sse42.Or(leftVector, rightVector),
            Operations.Subtract => Sse42.Subtract(leftVector, rightVector),
            Operations.Xor => Sse42.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    internal static Vector128<uint> DoVectorOperation_VectorReturn_Sse42(Vector128<uint> leftVector, Vector128<uint> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => Sse42.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Sse42.And(leftVector, rightVector),
            Operations.BitwiseOr => Sse42.Or(leftVector, rightVector),
            Operations.Subtract => Sse42.Subtract(leftVector, rightVector),
            Operations.Xor => Sse42.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    internal static Vector128<float> DoVectorOperation_VectorReturn_Sse42(Vector128<float> leftVector, Vector128<float> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => Sse42.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Sse42.And(leftVector, rightVector),
            Operations.BitwiseOr => Sse42.Or(leftVector, rightVector),
            Operations.Divide => Sse42.Divide(leftVector, rightVector),
            Operations.Max => Sse42.Max(leftVector, rightVector),
            Operations.Min => Sse42.Min(leftVector, rightVector),
            Operations.Multiply => Sse42.Multiply(leftVector, rightVector),
            Operations.Subtract => Sse42.Subtract(leftVector, rightVector),
            Operations.Xor => Sse42.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    internal static Vector128<double> DoVectorOperation_VectorReturn_Sse42(Vector128<double> leftVector, Vector128<double> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => Sse42.Add(leftVector, rightVector),
            Operations.BitwiseAnd => Sse42.And(leftVector, rightVector),
            Operations.BitwiseOr => Sse42.Or(leftVector, rightVector),
            Operations.Max => Sse42.Max(leftVector, rightVector),
            Operations.Min => Sse42.Min(leftVector, rightVector),
            Operations.Multiply => Sse42.Multiply(leftVector, rightVector),
            Operations.Subtract => Sse42.Subtract(leftVector, rightVector),
            Operations.Divide => Sse42.Divide(leftVector, rightVector),
            Operations.Xor => Sse42.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
}