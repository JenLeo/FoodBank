using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                // Look for any.
                if (context.Package1.Any())
                {
                    return;   // DB has been seeded
                }

                context.Package1.AddRange(
                    new Packages
                    {
                        PackageID = Guid.NewGuid().ToString(),
                        PackageNameId = "Fruit Frenzy",
                        PackageDetail = "Description",
                        PackageType = "Perishable",
                        PackagePrice = 7,
                        Pic = ""

                    },

                    new Packages
                    {
                        PackageID = Guid.NewGuid().ToString(),
                        PackageNameId = "Fruit Frenzy",
                        PackageDetail = "Description",
                        PackageType = "Perishable",
                        PackagePrice = 7,
                        Pic = ""
                    },

                    new Packages
                    {
                        PackageID = Guid.NewGuid().ToString(),
                        PackageNameId = "Fruit Frenzy",
                        PackageDetail = "Description",
                        PackageType = "Perishable",
                        PackagePrice = 7,
                        Pic = ""
                    },

                    new Packages
                    {
                        PackageID = Guid.NewGuid().ToString(),
                        PackageNameId = "Fruit Frenzy",
                        PackageDetail = "Description",
                        PackageType = "Perishable",
                        PackagePrice = 7,
                        Pic = ""
                    }
                );
                context.SaveChanges();
            }
           
        }
    }

}
