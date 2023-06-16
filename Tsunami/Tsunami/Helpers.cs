namespace Tsunami;

internal static class Helpers
{
    internal static int CalculateLCM(int num1, int num2)
    {
        var gcd = CalculateGCD(num1, num2);
        var lcm = (num1 * num2) / gcd;
        return lcm;
    }

    private static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}

internal static class ListExtensions
{
    public static void Resize<T>(this List<T?> list, int newSize)
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

internal static class ArrayExtensions
{
    public static T[] ResizeArray<T>(this T[] oldArray, int newSize)
    {
        Array.Resize(ref oldArray, newSize);
        return oldArray;
    }
}