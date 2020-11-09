using Furny.FileHandlerFeature.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class FileHandlerTest : TestBase
    {
        private readonly IFileHandlerService _fileHandlerService;

        public FileHandlerTest()
        {
            _fileHandlerService = serviceProvider.GetService<IFileHandlerService>();
        }

        [Fact]
        public async Task UploadDownloadTest()
        {
            var fileMock = new Mock<IFormFile>();

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;

            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var fileId = await _fileHandlerService.UploadFileAsync(fileMock.Object);

            var file = await _fileHandlerService.DownloadFileAsync(fileId);

            Assert.NotNull(file);
            Assert.True(file.Length == fileMock.Object.Length);
        }
    }
}
