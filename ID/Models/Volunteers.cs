using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    [Keyless]
    public class Volunteers
    {
        [Display(Name = "Volunteer ID: ")]
        public int VolunteerId { get; set; }

        [Display(Name = "Volunteer Last Name: ")]
        public string VolLName { get; set; }

        [Display(Name = "Volunteer First Name: ")]
        public string VolFName { get; set; }
       
    }
}
