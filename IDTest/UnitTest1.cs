using ID;
using ID.Controllers;
using ID.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace IDTest
{
    public class PackageControllerTest
    {
        private readonly Mock<IPackageRepository> _mockRepo;
        private readonly Mock<AppDbContext> _mockContext;
        private readonly Mock<IWebHostEnvironment> _mockHost;
        private readonly PackageController _controller;

        public PackageControllerTest()
        {
            _mockRepo = new Mock<IPackageRepository>();
            //_mockContext = new Mock<AppDbContext>();
            //_mockHost = new Mock<IWebHostEnvironment>();
            _controller = new PackageController(_mockRepo.Object, _mockContext.Object, _mockHost.Object);
        }
        [Fact]
        public async Task Index_ReturnsView_ListOfPackages()
        {
            


        }
        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _controller.Create();

            Assert.IsType<View>(result);
        }
    }
}
