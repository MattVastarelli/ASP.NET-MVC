using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class MinMemberAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeID == MembershipType.Unknown || 
                customer.MembershipTypeID == MembershipType.PayAsYouGo)
            {
                return  ValidationResult.Success;
            }
            else if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required");
            }
            else
            {
                var age = DateTime.Today.Year - customer.BirthDate.Value.Year;


                return (age >= 18) 
                    ? ValidationResult.Success 
                    : new ValidationResult("Customer must be 18 to be on a membership.");
            }
        }
    }
}