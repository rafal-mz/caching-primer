namespace FibonacciCaching;

public static class FiboMemoization
{
    public static int GetFibonacci(int index)
    {
        return GetFibonacciImpl(index, index > 1 ? new int?[index] : Array.Empty<int?>());
    }

    private static int GetFibonacciImpl(int fiboIndex, int?[] memo)
    {
        if (fiboIndex < 0)
        {
            return -1;
        }

        if (fiboIndex == 0 || fiboIndex == 1)
        {
            return fiboIndex;
        }

        var arrIndex = fiboIndex - 1;

        if (memo[arrIndex] != null)
        {
            return memo[arrIndex]!.Value;
        }

        if (memo[arrIndex] == null)
        {
            memo[arrIndex] = GetFibonacciImpl(fiboIndex - 1, memo);
        }

        if (memo[arrIndex - 1] == null)
        {
            memo[arrIndex - 1] = GetFibonacciImpl(fiboIndex - 2, memo);
        }

        return memo[arrIndex]!.Value + memo[arrIndex - 1]!.Value;
    }
}
