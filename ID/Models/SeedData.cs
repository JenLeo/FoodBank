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
                if (context.Packages.Any())
                {
                    return;   // DB has been seeded
                }

                context.Packages.AddRange(
                    new Package
                    {
                        PackageId = Guid.NewGuid().ToString(),
                        PackageNameId = "Fruit Frenzy",
                        PackageDetail = "Description",
                        PackageType = "Perishable",
                        PackagePrice = 7,
                        Pic = ""

                    },

                    new Package
                    {
                        PackageId = Guid.NewGuid().ToString(),
                        PackageNameId = "Fruit Frenzy",
                        PackageDetail = "Description",
                        PackageType = "Perishable",
                        PackagePrice = 7,
                        Pic = ""
                    },

                    new Package
                    {
                        PackageId = Guid.NewGuid().ToString(),
                        PackageNameId = "Fruit Frenzy",
                        PackageDetail = "Description",
                        PackageType = "Perishable",
                        PackagePrice = 7,
                        Pic = ""
                    },

                    new Package
                    {
                        PackageId = Guid.NewGuid().ToString(),
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
