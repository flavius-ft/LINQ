using System;
using System.Collections.Generic;
using Xunit;

namespace MyLinqProject
{
    public class LinqTest
    {
        [Fact]
        public void AllMethodNumbersAreEvenReturnTrue()
        {
            int[] evenNumbers = { 2, 4, 6, 8 };
            bool IsEven(int element) => element % 2 == 0;

            Assert.True(evenNumbers.All(IsEven));
        }

        [Fact]
        public void AllMethodNumbersAreNotEvenReturnFalse()
        {
            int[] evenNumbers = { 2, 4, 6, 9 };
            bool IsEven(int element) => element % 2 == 0;

            Assert.False(evenNumbers.All(IsEven));
        }

        [Fact]
        public void ArgumentNullExceptionWhenTheArrayAndPredicatAreNull()
        {
            string[] elements = null;
            bool IsEven(string element) => element == null;

            Assert.Throws<ArgumentNullException>(() => elements.All(IsEven));
        }

        [Fact]
        public void AnyElementRespectTheConditionReturnTrue()
        {
            int[] elements = { 1, 4, 5, 9 };

            bool IsEven(int element) => element % 2 == 0;

            Assert.True(elements.Any(IsEven));
        }

        [Fact]
        public void AnyElementDoNotRespectTheConditionReturnFalse()
        {
            int[] elements = { 1, 3, 5, 9 };

            bool IsEven(int element) => element % 2 == 0;

            Assert.False(elements.Any(IsEven));
        }

        [Fact]
        public void ArgumentNullExceptionOnAnyMethodWhenTheArrayAndPredicatAreNull()
        {
            string[] elements = null;
            bool IsEven(string element) => element == null;

            Assert.Throws<ArgumentNullException>(() => elements.Any(IsEven));
        }

        [Fact]
        public void FirstMethodReturnsTheElementWhoIsEven()
        {
            int[] evenNumbers = { 1, 4, 5, 8 };
            bool IsEven(int element) => element % 2 == 0;

            Assert.Equal(4, evenNumbers.First(IsEven));
        }

        [Fact]
        public void ArgumentNullExceptionOnFirstMethodWhenTheArrayAndPredicatAreNull()
        {
            string[] elements = null;
            bool IsEven(string element) => element == null;

            Assert.Throws<ArgumentNullException>(() => elements.First(IsEven));
        }

        [Fact]
        public void FirstElementThrowsInvlaidOperationExceptionWhenNoElementIsEven()
        {
            int[] evenNumbers = { 1, 3, 5, 9 };
            bool IsEven(int element) => element % 2 == 0;

            Assert.Throws<InvalidOperationException>(() => evenNumbers.First(IsEven));
        }

        [Fact]
        public void SelectElementsFromAnEnumerationIntoAnOtherForm()
        {
            int[] numbers = { 3, 5 };

            IEnumerable<int> result = numbers.Select(x => x * 2);
            bool AreEven(int element) => element % 2 == 0;

            Assert.True(result.All(AreEven));
        }
    }
}
