
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
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

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            //NotFound object
            Assert.That(result, Is.TypeOf<NotFound>());

            //NotFound object or one of its derivatives
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {

        }
    }
}
