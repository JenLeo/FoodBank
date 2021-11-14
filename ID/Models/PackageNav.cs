using System.ComponentModel.DataAnnotations;

namespace ID.Models
{
    public class PackageNav
    {
        
        public string SupplierId { get; set; }
       
        public string PackageId { get; set; }
        public Supplier Supplier { get; set; }
        public Package Package { get; set; }
    }
}