
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ID.Models
{

    public partial class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order ID: ")]
        public string OrderId { get; set; }
        public List<OrderDetail> OrderLines { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name: ")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name: ")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(100)]
        [Display(Name = "Address: ")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2: ")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number: ")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [Display(Name = "Order Date: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Status: ")]
        [DisplayFormat(NullDisplayText = "Pending")]
        public string OrderStatus { get; set; }

        [ForeignKey("Organisation ")]
        [Display(Name = "Organisation: ")]
        public string OrganisationId { get; set; }
        public Organisation Organisation { get; set; }

        [ForeignKey("Cart")]
        [Display(Name = "Cart: ")]
        public string CartId { get; set; }
        public Cart Cart { get; set; }
        

    }
}