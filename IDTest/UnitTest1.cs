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

        
    }
}