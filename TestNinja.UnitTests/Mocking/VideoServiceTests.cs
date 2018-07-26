using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            //use moq only for external dependencies
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            #region old
            //var service = new VideoService(new FakeFileReader());
            //service.FileReader = new FakeFileReader();
            //var result = service.ReadVideoTitle(new FakeFileReader());
            //var result = service.ReadVideoTitle();
            //Assert.That(result, Does.Contain("error").IgnoreCase);
            #endregion

            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);

        }
    }
}
