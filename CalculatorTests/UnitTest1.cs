
using Calculator;
using NUnit.Framework;

namespace Calculator.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyStringReturnsZero()
        {
            //Given
            string input = "";
            int expected = 0;

            //When
            int result = Calculator.Calculate(input);

            //Then
            NUnit.Framework.Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SingleNumberReturnsValue()
        {
            // Given
            int input = 5;
            int expected = 5;

            // When
            int result = Calculator.Calculate(input.ToString());

            // Then
            NUnit.Framework.Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TwoNumbersCommaDelimitedReturnsSum()
        {
            // Given
            string input = "1,2";
            int expected = 3;

            // When
            int result = Calculator.Calculate(input);

            // Then
            NUnit.Framework.Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TwoNumbersNewlineDelimitedReturnsSum()
        {
            // Given
            string input = "1\n2";
            int expected = 3;

            // When
            int result = Calculator.Calculate(input);

            // Then
            NUnit.Framework.Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ThreeNumbersDelimitedEitherWayReturnsSum()
        {
            // Given
            string input = "1\n2,3";
            int expected = 1 + 2 + 3;

            // When
            int result = Calculator.Calculate(input);

            // Then
            NUnit.Framework.Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void NegativeNumbersThrowException()
        {
            // Given
            string input = "-1,1,2";

            // When & Then
            NUnit.Framework.Assert.Throws<ArgumentException>(() => Calculator.Calculate(input));
        }

        [Test]
        public void NumbersGreaterThan1000Ignored()
        {
            // Given
            string input = "1,1001,2,3";
            int expected = 1 + 2 + 3;

            // When
            int result = Calculator.Calculate(input);

            // Then
            NUnit.Framework.Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SingleCharLineDelimiterCanBeDefinedOnFirstLine()
        {
            // Given
            string input = "//$1$1001$2$3$5";
            int expected = 1 + 2 + 3 + 5;

            // When
            int result = Calculator.Calculate(input);

            // Then
            NUnit.Framework.Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MultiCharDelimiterCanBeDefinedOnFirstLine()
        {
            // Given
            string input = "//[$$]1$$1001$$2$$3$$5";
            int expected = 1 + 2 + 3 + 5;

            // When
            int result = Calculator.Calculate(input);

            Console.WriteLine(result);
            // Then
            NUnit.Framework.Assert.That(result, Is.EqualTo(expected));
        }

        // [Test]
        // public void ManySingleOrMultiLineDelimitersCanBeDefinedOnFirstLine()
        // {
        //     // Given
        //     string input = "//[$$][*][&&&]1$$1001*2$$3$$5&&&6";
        //     int expected = 1+2+3+5+6;
        //     
        //     // When
        //     int result = Calculator.Calculate(input);
        //     
        //     // Then
        //     Assert.That(result, Is.EqualTo(expected));
        // }
    }

}