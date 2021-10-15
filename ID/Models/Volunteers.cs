using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    
    public class Volunteers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Volunteer ID: ")]
        public string VolunteerId { get; set; }

        [Display(Name = "Volunteer Last Name: ")]
        public string VolLName { get; set; }

        [Display(Name = "Volunteer First Name: ")]
        public string VolFName { get; set; }
       
    }
}
