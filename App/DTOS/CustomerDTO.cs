using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using App.Models;

namespace App.DTOS
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsLetter { get; set; }
       
        //membership FK
        public byte MembershipTypeID { get; set; }

        //display name
        //[MinMemberAge]
        public DateTime? BirthDate { get; set; }
    }
}