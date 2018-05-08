//using iTest.Data.Models;
//using iTest.Infrastructure.Providers;
//using iTest.Services.Data.User.Contracts;
//using iTest.Web.Areas.Users.Controllers;
//using iTest.Web.Areas.Users.Models.Dashboard;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace iTest.UnitTests.Controllers.Users.DashboardControllerTests
//{
//    [TestClass]
//    public class Should_Return_ViewModel
//    {
//        [TestMethod]
//        public void UserDashboard()
//        {
//            // Arrange
//            var categoriesServiceMock = new Mock<IUserCategoryService>();
//            var userTestServiceMock = new Mock<IUserTestService>();
//            var mappingProviderMock = new Mock<IMappingProvider>();
//            var userManagerMock = new Mock<UserManager<User>>(MockBehavior.Default);

//            var controller = new DashboardController(userTestServiceMock.Object, categoriesServiceMock.Object, mappingProviderMock.Object, userManagerMock.Object);

//            var userDashboardViewModelMock = new Mock<UserDashboardViewModel>().Object;

//            // Act
//            var result = controller.Index();

//            // Assert
//        }
//    }
//}
