using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    
    public class Organisation 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Organisation ID: ")]
        public string OrganisationId { get; set; }

        [Display(Name = "Name: ")]
        public string OrganisationName { get; set; }

        [Display(Name = "Location: ")]
        public string OrganisationAddress { get; set; }

        [Display(Name = " ")]
        public string Pic { get; set; }

        public ICollection<Order> Orders { get; set; }



    }
}
