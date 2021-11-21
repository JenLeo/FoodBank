using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class PackageIndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration Configuration;

        public PackageIndexModel(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Package> Packages { get; set; }

        public async Task OnGetAsync(string sortOrder, 
            string currentFilter, 
            string searchString,
            int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Package> pks = from p in _context.Packages
                                      .Include(s => s.Supplier)
                                             select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pks = pks.Where(p => p.PackageNameId.ToUpper().Contains(searchString) || p.PackageDetail.ToUpper().Contains(searchString)
                || p.PackageType.ToUpper().Contains(searchString));
            }

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
            var pageSize = Configuration.GetValue("PageSize", 4);
            Packages = await PaginatedList<Package>.CreateAsync(
                pks
                .Include(s => s.Supplier)
                .AsNoTracking(), pageIndex ?? 1, pageSize);
    
        }
    }
}
