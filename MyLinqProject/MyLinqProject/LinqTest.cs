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

        [Fact]
        public void SelectManyElementsFromAnEnumerationAndReturnSpecificSelection()
        {
            PetOwner[] petOwners =
                   {
                        new PetOwner
                    {
                         Name = "Higa, Sidney",
                         Pets = new List<string> { "Scruffy", "Sam" }
                    },
                        new PetOwner
                     {
                         Name = "Ashkenazi, Ronen",
                         Pets = new List<string> { "Walker", "Sugar" }
                     }
                   };

            var compare = new List<string> { "Scruffy", "Sam", "Walker", "Sugar" };

            IEnumerable<string> result = petOwners.SelectMany(petOwner => petOwner.Pets);

            Assert.Equal(compare, result);
        }

        [Fact]
        public void WhereMethodReturnsElementsWhoSatisfyTheCondition()
        {
            List<string> fruits =
                    new List<string>
                    {
                        "apple", "passionfruit", "banana", "mango",
                        "orange", "blueberry", "grape", "strawberry"
                    };

            IEnumerable<string> result = fruits.Where(fruit => fruit.Length < 6);

            List<string> answer = new List<string> { "apple", "mango", "grape" };

            Assert.Equal(answer, result);
        }

        [Fact]
        public void ToDictionaryReturnsADictionaryOfAnEnumeration()
        {
            List<Delivery> packages =
        new List<Delivery>
            {
              new Delivery { Company = "Coho Vineyard", TrackingNumber = 1 },
              new Delivery { Company = "Lucerne Publishing", TrackingNumber = 2 },
              new Delivery { Company = "Wingtip Toys", TrackingNumber = 3 },
              new Delivery { Company = "Adventure Works", TrackingNumber = 4 }
            };

            Dictionary<int, string> dictionary =
                packages.ToDictionary(key => key.TrackingNumber, element => element.Company);

            Dictionary<int, string> toCompare = new Dictionary<int, string>
            {
                { 1, "Coho Vineyard" },
                { 2, "Lucerne Publishing" },
                { 3, "Wingtip Toys" },
                { 4, "Adventure Works" }
            };

            Assert.Equal(toCompare, dictionary);
        }

        [Fact]
        public void ZipMethodReturnsCorespondingEnumeration()
        {
            int[] numbers = { 1, 2, 3 };
            string[] words = { "one", "two", "three", "four" };

            object[] result = { "1 one", "2 two", "3 three" };

            Assert.Equal(result, numbers.Zip(words, (first, second) => first + " " + second));
        }

        [Fact]
        public void AgreggateMethodApliedOnNUmbersArrayReturnsHowManyEvenNumbersAre()
        {
            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };

            int numEven = ints.Aggregate(0, (total, next) =>
                                                next % 2 == 0 ? total + 1 : total);

            Assert.Equal(6, numEven);
        }
    }
}
