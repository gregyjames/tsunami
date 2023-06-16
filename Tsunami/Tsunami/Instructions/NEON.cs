using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

namespace Tsunami.Instructions;

internal static class NEON
{
    internal static Vector128<int> DoVectorOperation_VectorReturn_NEON(Vector128<int> leftVector, Vector128<int> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => AdvSimd.Add(leftVector, rightVector),
            Operations.BitwiseAnd => AdvSimd.And(leftVector, rightVector),
            Operations.BitwiseOr => AdvSimd.Or(leftVector, rightVector),
            Operations.Max => AdvSimd.Max(leftVector, rightVector),
            Operations.Min => AdvSimd.Min(leftVector, rightVector),
            Operations.Multiply => AdvSimd.Multiply(leftVector, rightVector),
            Operations.Subtract => AdvSimd.Subtract(leftVector, rightVector),
            Operations.Xor => AdvSimd.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    internal static Vector128<float> DoVectorOperation_VectorReturn_NEON(Vector128<float> leftVector, Vector128<float> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => AdvSimd.Add(leftVector, rightVector),
            Operations.BitwiseAnd => AdvSimd.And(leftVector, rightVector),
            Operations.BitwiseOr => AdvSimd.Or(leftVector, rightVector),
            Operations.Max => AdvSimd.Max(leftVector, rightVector),
            Operations.Min => AdvSimd.Min(leftVector, rightVector),
            Operations.Multiply => AdvSimd.Multiply(leftVector, rightVector),
            Operations.Subtract => AdvSimd.Subtract(leftVector, rightVector),
            Operations.Xor => AdvSimd.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    internal static Vector128<uint> DoVectorOperation_VectorReturn_NEON(Vector128<uint> leftVector, Vector128<uint> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.Add => AdvSimd.Add(leftVector, rightVector),
            Operations.BitwiseAnd => AdvSimd.And(leftVector, rightVector),
            Operations.BitwiseOr => AdvSimd.Or(leftVector, rightVector),
            Operations.Max => AdvSimd.Max(leftVector, rightVector),
            Operations.Min => AdvSimd.Min(leftVector, rightVector),
            Operations.Multiply => AdvSimd.Multiply(leftVector, rightVector),
            Operations.Subtract => AdvSimd.Subtract(leftVector, rightVector),
            Operations.Xor => AdvSimd.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    internal static Vector128<double> DoVectorOperation_VectorReturn_NEON(Vector128<double> leftVector, Vector128<double> rightVector, Operations operation)
    {
        return operation switch
        {
            Operations.BitwiseAnd => AdvSimd.And(leftVector, rightVector),
            Operations.BitwiseOr => AdvSimd.Or(leftVector, rightVector),
            Operations.Xor => AdvSimd.Xor(leftVector, rightVector),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
}