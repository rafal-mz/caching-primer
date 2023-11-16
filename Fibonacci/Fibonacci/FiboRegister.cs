namespace FibonacciCaching;

public static class FiboRegister
{
    public static int GetFibonacci(int index)
    {
        if (index < 0)
        {
            return -1;
        }

        if (index == 0 || index == 1)
        {
            return index;
        }

        var first = 0;
        var second = 1;
        var current = first + second;
        var i = 2;

        while (i <= index)
        {
            current = first + second;

            first = second;
            second = current;
            i++;
        }

        return current;
    }
}
