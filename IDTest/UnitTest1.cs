using ID;
using ID.Controllers;
using ID.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IDTest
{
    public class PackageControllerTest
    {
        private readonly Mock<IPackageRepository> service;
        private readonly Mock<AppDbContext> _mockContext;
        private readonly Mock<IWebHostEnvironment> _mockHost;
        public PackageControllerTest()
        {
            service = new Mock<IPackageRepository>();
        }

        [Fact]
        //naming convention MethodName_expectedBehavior_StateUnderTest
        public void GetPackage_ListOfPackage_PackageExistsInRepo()
        {
            //arrange
            var package = GetSamplePackage();
            service.Setup(x => x.GetPackage())
                .Returns(GetSamplePackage);
            var controller = new PackageController(service.Object, _mockContext.Object, _mockHost.Object);

            //act
            var actionResult = controller.Index(searchString: null, sortOrder: null, currentFilter: null,
                pageNumber: null);
            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<Package>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(GetSamplePackage().Count(), actual.Count());
        }

        private List<Package> GetSamplePackage()
        {
            List<Package> output = new List<Package>
        {
            new Package
                    {
                        PackageId = Guid.NewGuid().ToString(),
                        PackageNameId = "Fruit Frenzy",
                        PackageDetail = "Description",
                        PackageType = "Perishable",
                        PackagePrice = 7,
                        Pic = "",
                        SupplierId = "1234"

                    },

                    new Package
                    {
                        PackageId = Guid.NewGuid().ToString(),
                        PackageNameId = "Fruit Frenzy",
                        PackageDetail = "Description",
                        PackageType = "Perishable",
                        PackagePrice = 7,
                        Pic = "",
                        SupplierId = "1234"
                    }
        };
            return output;
        }
        

    }
}
