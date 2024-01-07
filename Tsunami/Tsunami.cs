using System.Numerics;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using Tsunami.Instructions;

namespace Tsunami;

public static class Tsunami<T> where T : struct
{
	/*
	public static T[] DoOperations(T one, List<T> rightList, Operations operation)
	{
		var count = Vector<T>.Count;
		var max_array_size = rightList.Count;
		var maxLength = Helpers.CalculateLCM(rightList.Count,count);
		rightList.Resize(maxLength);
		
		var spanTwo = CollectionsMarshal.AsSpan(rightList);

		var arr = new T[maxLength];
		var arrSpan = arr.AsSpan();
		Vector<T> vectorResult;
	    
		for (var i = 0; i < rightList.Count; i += count)
		{
			var t = new Vector<T>(spanTwo.Slice(i, count));
			vectorResult = DoScalarOperation(one, t, operation);
			vectorResult.CopyTo(arrSpan.Slice(i, count));
		}

		return arr[new Range(0, max_array_size)];
	}
	*/

	#region Generic
	public static IEnumerable<T> DoOperation(List<T> leftList, List<T> rightList, Operations operation)
    {
	    var count = Vector<T>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);
	    var old_gc = GCSettings.LatencyMode;
	    GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
	    
	    rightList.Resize(maxLength);
	    leftList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList); 
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new T[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<T, Vector<T>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<T, Vector<T>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<T, Vector<T>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = GENERIC<T>.DoVectorOperation_VectorReturn_GENERIC(ref inputVectors1[i], ref inputVectors2[i], operation);
	    }
        
	    GCSettings.LatencyMode = old_gc;
	    return arr.ResizeArray(maxArraySize);
    }
	public static IEnumerable<T> DoOperation(T leftScalar, List<T> rightList, Operations operation)
	{
		var count = Vector<T>.Count;
		var maxArraySize = rightList.Count;
		var maxLength = Helpers.CalculateLCM(maxArraySize,count);
		var old_gc = GCSettings.LatencyMode;
		GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
	    
		rightList.Resize(maxLength);
		var spanTwo = CollectionsMarshal.AsSpan(rightList);

		var arr = new T[maxLength];
        
		var resultVectors = MemoryMarshal.Cast<T, Vector<T>>(arr);
		var inputVectors2 = MemoryMarshal.Cast<T, Vector<T>>(spanTwo);
        
		for(var i = 0; i < inputVectors2.Length; i++)
		{
			resultVectors[i] = GENERIC<T>.DoScalarOperation_VectorReturn_GENERIC(ref leftScalar, ref inputVectors2[i], operation);
		}
        
		GCSettings.LatencyMode = old_gc;
		return arr.ResizeArray(maxArraySize);
	}
	#endregion
	
    #region NEON
    public static IEnumerable<int> DoOperation_NEON(List<int> leftList, List<int> rightList, Operations operation)
    {
	    var count = Vector128<int>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);
		
	    var old_gc = GCSettings.LatencyMode;
	    GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
	    
	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new int[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<int, Vector128<int>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<int, Vector128<int>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<int, Vector128<int>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = NEON.DoVectorOperation_VectorReturn_NEON(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }

	    GCSettings.LatencyMode = old_gc;
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<float> DoOperation_NEON(List<float> leftList, List<float> rightList, Operations operation)
    {
	    var count = Vector128<int>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new float[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<float, Vector128<float>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<float, Vector128<float>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<float, Vector128<float>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = NEON.DoVectorOperation_VectorReturn_NEON(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<uint> DoOperation_NEON(List<uint> leftList, List<uint> rightList, Operations operation)
    {
	    var count = Vector128<uint>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new uint[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<uint, Vector128<uint>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<uint, Vector128<uint>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<uint, Vector128<uint>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = NEON.DoVectorOperation_VectorReturn_NEON(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<double> DoOperation_NEON(List<double> leftList, List<double> rightList, Operations operation)
    {
	    var count = Vector128<double>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new double[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<double, Vector128<double>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<double, Vector128<double>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<double, Vector128<double>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = NEON.DoVectorOperation_VectorReturn_NEON(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    #endregion
    
    #region AVX2
	
    public static IEnumerable<uint> DoOperation_AVX2(List<uint> leftList, List<uint> rightList, Operations operation)
    {
	    var count = Vector256<uint>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new uint[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<uint, Vector256<uint>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<uint, Vector256<uint>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<uint, Vector256<uint>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = AVX2.DoVectorOperation_VectorReturn_AVX2(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<int> DoOperation_AVX2(List<int> leftList, List<int> rightList, Operations operation)
    {
	    var count = Vector256<int>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new int[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<int, Vector256<int>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<int, Vector256<int>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<int, Vector256<int>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = AVX2.DoVectorOperation_VectorReturn_AVX2(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }

    public static IEnumerable<float> DoOperation_AVX2(List<float> leftList, List<float> rightList, Operations operation)
    {
	    var count = Vector256<float>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new float[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<float, Vector256<float>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<float, Vector256<float>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<float, Vector256<float>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = AVX2.DoVectorOperation_VectorReturn_AVX2(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }

    public static IEnumerable<double> DoOperation_AVX2(List<double> leftList, List<double> rightList, Operations operation)
    {
	    var count = Vector256<double>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new double[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<double, Vector256<double>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<double, Vector256<double>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<double, Vector256<double>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = AVX2.DoVectorOperation_VectorReturn_AVX2(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    
    #endregion

    #region SSE3
    public static IEnumerable<int> DoOperation_SSE3(List<int> leftList, List<int> rightList, Operations operation)
    {
	    var count = Vector128<int>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new int[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<int, Vector128<int>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<int, Vector128<int>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<int, Vector128<int>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE3.DoVectorOperation_VectorReturn_Sse3(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<double> DoOperation_SSE3(List<double> leftList, List<double> rightList, Operations operation)
    {
	    var count = Vector128<double>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new double[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<double, Vector128<double>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<double, Vector128<double>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<double, Vector128<double>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE3.DoVectorOperation_VectorReturn_Sse3(ref inputVectors1[i],ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<float> DoOperation_SSE3(List<float> leftList, List<float> rightList, Operations operation)
    {
	    var count = Vector128<float>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new float[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<float, Vector128<float>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<float, Vector128<float>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<float, Vector128<float>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE3.DoVectorOperation_VectorReturn_Sse3(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<uint> DoOperation_SSE3(List<uint> leftList, List<uint> rightList, Operations operation)
    {
	    var count = Vector128<uint>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new uint[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<uint, Vector128<uint>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<uint, Vector128<uint>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<uint, Vector128<uint>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE3.DoVectorOperation_VectorReturn_Sse3(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    
    #endregion
    
    #region SSE41
    public static IEnumerable<int> DoOperation_SSE41(List<int> leftList, List<int> rightList, Operations operation)
    {
	    var count = Vector128<int>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new int[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<int, Vector128<int>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<int, Vector128<int>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<int, Vector128<int>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE41.DoVectorOperation_VectorReturn_Sse41(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<double> DoOperation_SSE41(List<double> leftList, List<double> rightList, Operations operation)
    {
	    var count = Vector128<double>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new double[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<double, Vector128<double>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<double, Vector128<double>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<double, Vector128<double>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE41.DoVectorOperation_VectorReturn_Sse41(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<float> DoOperation_SSE41(List<float> leftList, List<float> rightList, Operations operation)
    {
	    var count = Vector128<float>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new float[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<float, Vector128<float>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<float, Vector128<float>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<float, Vector128<float>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE41.DoVectorOperation_VectorReturn_Sse41(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<uint> DoOperation_SSE41(List<uint> leftList, List<uint> rightList, Operations operation)
    {
	    var count = Vector128<uint>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new uint[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<uint, Vector128<uint>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<uint, Vector128<uint>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<uint, Vector128<uint>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE41.DoVectorOperation_VectorReturn_Sse41(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    
    #endregion
    
    #region SSE42
    public static IEnumerable<int> DoOperation_SSE42(List<int> leftList, List<int> rightList, Operations operation)
    {
	    var count = Vector128<int>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new int[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<int, Vector128<int>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<int, Vector128<int>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<int, Vector128<int>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE42.DoVectorOperation_VectorReturn_Sse42(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<double> DoOperation_SSE42(List<double> leftList, List<double> rightList, Operations operation)
    {
	    var count = Vector128<double>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new double[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<double, Vector128<double>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<double, Vector128<double>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<double, Vector128<double>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE42.DoVectorOperation_VectorReturn_Sse42(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<float> DoOperation_SSE42(List<float> leftList, List<float> rightList, Operations operation)
    {
	    var count = Vector128<float>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new float[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<float, Vector128<float>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<float, Vector128<float>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<float, Vector128<float>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE42.DoVectorOperation_VectorReturn_Sse42(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    public static IEnumerable<uint> DoOperation_SSE42(List<uint> leftList, List<uint> rightList, Operations operation)
    {
	    var count = Vector128<uint>.Count;
	    var maxArraySize = Math.Max(leftList.Count, rightList.Count);
	    var maxLength = Helpers.CalculateLCM(maxArraySize,count);

	    leftList.Resize(maxLength);
	    rightList.Resize(maxLength);
	    
	    var spanOne = CollectionsMarshal.AsSpan(leftList);
	    var spanTwo = CollectionsMarshal.AsSpan(rightList);

	    var arr = new uint[maxLength];
        
	    var resultVectors = MemoryMarshal.Cast<uint, Vector128<uint>>(arr);
	    var inputVectors1 = MemoryMarshal.Cast<uint, Vector128<uint>>(spanOne);
	    var inputVectors2 = MemoryMarshal.Cast<uint, Vector128<uint>>(spanTwo);
        
	    for(var i = 0; i < inputVectors1.Length; i++)
	    {
		    resultVectors[i] = SSE42.DoVectorOperation_VectorReturn_Sse42(ref inputVectors1[i], ref inputVectors2[i], ref operation);
	    }
	    
	    return arr.ResizeArray(maxArraySize);
    }
    
    #endregion
}