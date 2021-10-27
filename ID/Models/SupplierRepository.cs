using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _appDbContext;

        public SupplierRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Supplier> Suppliers => _appDbContext.Suppliers;
    }
}
