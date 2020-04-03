using NUnit.Framework;
using System;
using System.Web.Mvc;

using wholewellness.Controllers;

namespace wholewellness.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        // TODO: test fails
        [Test]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            var expectedVersion = mvcName.Version.Major + "." + mvcName.Version.Minor;
            var expectedRuntime = isMono ? "Mono" : ".NET";

            // Assert
            Assert.AreEqual(expectedRuntime, result.ViewData["Runtime"]);
        }

    }
}
