using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

namespace Tsunami.Instructions;

internal static class NEON
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector128<int> DoVectorOperation_VectorReturn_NEON(ref Vector128<int> leftVector, ref Vector128<int> rightVector, ref Operations operation)
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector128<float> DoVectorOperation_VectorReturn_NEON(ref Vector128<float> leftVector, ref Vector128<float> rightVector, ref Operations operation)
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector128<uint> DoVectorOperation_VectorReturn_NEON(ref Vector128<uint> leftVector, ref Vector128<uint> rightVector, ref Operations operation)
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector128<double> DoVectorOperation_VectorReturn_NEON(ref Vector128<double> leftVector, ref Vector128<double> rightVector, ref Operations operation)
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