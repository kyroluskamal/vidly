using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name="Name")]
        public string name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Types")]
        public byte MembershipTypeId { get; set; }

        [Display(Name ="Birth Date")]
        public String BirthDate { get; set; }

    }
}