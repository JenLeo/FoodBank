using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
   public interface ISupplierRepository
    {
        IEnumerable<Supplier> Suppliers { get; }
    }
}
