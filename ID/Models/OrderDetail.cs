using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ID.Models
{
    public enum OrderStatusOptions
    {
        Pending,
        Accepted,
        Cancelled,
        Completed
    }
    public class OrderDetail
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderDetailId { get; set; }
        
        public string OrderId { get; set; }
        public string PackageId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Status: ")]
        [DisplayFormat(NullDisplayText = "Pending")]
        public string OrderStatus { get; set; }

        public virtual Package Packages { get; set; }
        public virtual Order Order { get; set; }
    }
}