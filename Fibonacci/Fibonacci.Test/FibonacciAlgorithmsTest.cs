using FibonacciCaching;
using Xunit;

namespace Fibonacci.Test
{
    public class FibonacciAlgorithmsTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(8, 21)]
        [InlineData(9, 34)]
        [InlineData(10, 55)]
        [InlineData(20, 6765)]
        public void Fibonacci_Register_Numbers_Are_Generated_Correctly(int fiboIndex, int expectedValue)
        {
            Assert.Equal(FiboRegister.GetFibonacci(fiboIndex), expectedValue);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(8, 21)]
        [InlineData(9, 34)]
        [InlineData(10, 55)]
        [InlineData(20, 6765)]
        public void Fibonacci_Memoization_Numbers_Are_Generated_Correctly(int fiboIndex, int expectedValue)
        {
            Assert.Equal(FiboMemoization.GetFibonacci(fiboIndex), expectedValue);
        }

        [Fact]
        public void Fibonacci_Functions_Return_Minus_One_For_Negative_Input()
        {
            var negativeNumber = -10;

            Assert.Equal(-1, FiboMemoization.GetFibonacci(negativeNumber));
            Assert.Equal(-1, FiboRegister.GetFibonacci(negativeNumber));
            Assert.Equal(-1, FiboRecursive.GetFibonacci(negativeNumber));
        }
    }
}