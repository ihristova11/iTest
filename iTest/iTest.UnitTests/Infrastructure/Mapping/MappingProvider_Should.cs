using AutoMapper;
using iTest.Data.Models;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace iTest.UnitTests.Infrastructure.Mapping
{
    [TestClass]
    public class MappingProvider_Should
    {
        [TestMethod]
        public void CallMethodMap()
        {
            //Arrange
            var test = new Test();
            var category = new Category();

            var mapperMock = new Mock<IMapper>();

            mapperMock.Setup(m => m.Map<TestDTO>(It.IsAny<Test>())).Verifiable();
            mapperMock.Setup(m => m.Map<CategoryDTO>(It.IsAny<Category>())).Verifiable();

            var mapperProvider = new MappingProvider(mapperMock.Object);

            //Act
            var testDTO = mapperProvider.MapTo<TestDTO>(test);
            var categoryDTO = mapperProvider.MapTo<CategoryDTO>(test);

            //Assert
            mapperMock.Verify(x => x.Map<TestDTO>(test), Times.Once);
            mapperMock.Verify(x => x.Map<CategoryDTO>(test), Times.Once);
        }
    }
}
