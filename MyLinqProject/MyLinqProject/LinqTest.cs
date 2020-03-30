using Xunit;

namespace MyLinqProject
{
    public class LinqTest
    {
        [Fact]
        public void CheckIfNumbersAreEven()
        {
            int[] evenNumbers = { 2, 4, 6, 8 };
            bool IsEven(int element) => element % 2 == 0;

            Assert.True(evenNumbers.All(IsEven));
        }
    }
}
