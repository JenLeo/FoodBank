using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class PackageIndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public PackageIndexModel(AppDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Package> Packages { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";

            IQueryable<Package> pks = from p in _context.Packages
                                             select p;

            switch (sortOrder)
            {
                case "name_desc":
                    pks = pks.OrderByDescending(p => p.PackageNameId);
                    break;
                case "Type":
                    pks = pks.OrderBy(p => p.PackageType);
                    break;
                case "type_desc":
                    pks = pks.OrderByDescending(p => p.PackageType);
                    break;
                case "Price":
                    pks = pks.OrderBy(p => p.PackagePrice);
                    break;
                case "price_desc":
                    pks = pks.OrderByDescending(p => p.PackagePrice);
                    break;
                default:
                    pks = pks.OrderBy(p => p.PackagePrice);
                    break;
            }

            Packages = await pks.AsNoTracking().ToListAsync();
        }
    }
}
