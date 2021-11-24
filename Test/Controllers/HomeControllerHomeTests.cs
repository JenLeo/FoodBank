using Microsoft.VisualStudio.TestTools.UnitTesting;
using ID.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using ID.Models;
using Microsoft.AspNetCore.Hosting;

namespace ID.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerHomeTests
    {

        private readonly Mock<ILogger<HomeController>> _mockLogger;

        [TestMethod()]
        public void IndexTest()
        {
            //arrange
            HomeController controller = new HomeController(logger: null);

            //act
            IActionResult result = controller.Index();

            //assert
            Assert.IsNotNull(result);
        }
    }
        [TestClass()]
        class PackageControllerTest
        {
            //private readonly Mock<IPackageRepository> service;
            //private readonly Mock<AppDbContext> _mockContext;
            //private readonly Mock<IWebHostEnvironment> _mockHost;


            [TestMethod()]
            public void PackageIndexTest()
            {
                //arrange
                PackageController controller = new PackageController(packageRepository: null, Context: null,
                    webHostEnv: null);

                //act
                IActionResult result = controller.Index(searchString: null, sortOrder: null,
                    currentFilter: null, pageNumber: null) as IActionResult;

                //assert
                Assert.IsNotNull(result);
            }
        }
}