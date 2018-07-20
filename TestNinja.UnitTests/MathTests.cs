using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        // SetUp
        //TearDown

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumArguments()
        {
            //act
            var result = _math.Add(1, 2);

            //assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_WhenFirstArgumentIsGreater_ReturnFirstArgument()
        {
            var result = _math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_WhenSecondArgumentIsGreater_ReturnSecondArgument()
        {
            var result = _math.Max(1, 2);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSecondArgument()
        {
            var result = _math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
