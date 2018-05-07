using AutoMapper;
using iTest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace iTest.UnitTests.Infrastructure.Mapping
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenMapperParameterIsNotNull()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();

            // Act
            var mapperProvider = new MappingProvider(mapperMock.Object);

            // Assert
            Assert.IsNotNull(mapperProvider);
            Assert.IsInstanceOfType(mapperProvider, typeof(IMappingProvider));
        }
    }
}
