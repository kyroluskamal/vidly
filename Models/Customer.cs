using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace vidly.Models
{
    public class Customer
    {
        public int id { get; set; }
        //[Required]
        
        [Required(ErrorMessage ="Please Enter Your Name.")]
        [StringLength(255)]
        [Display(Name="Name")]
        public string name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Please Choose your membership Type")]
        [Display(Name = "Membership Types")]
        public byte MembershipTypeId { get; set; }
        [Min18Years]
        [Display(Name ="Birth Date")]
        public DateTime? BirthDate { get; set; }

        public readonly int newCustomerId = 0;
    }
}