
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            //specific assertion
            //this test should not too specific but, in this case is advisable
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase); 

            //more general
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase); //too general
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }
    }
}
