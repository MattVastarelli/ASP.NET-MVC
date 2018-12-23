using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsLetter { get; set; }
       
        //relation from customer to membership type
        public MembershipType MembershipType { get; set; }

        //membership FK
        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; }

        //display name
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}