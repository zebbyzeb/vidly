using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.ViewModels;

namespace Vidly.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var viewModel = (NewCustomerViewModel)validationContext.ObjectInstance;
            if (viewModel.MembershipTypeId == null || viewModel.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (viewModel.Birthdate == null && (viewModel.MembershipTypeId != 1 && viewModel.MembershipTypeId != null))
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - viewModel.Birthdate.Value.Year; 
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Must be 18years or older");
        }
    }
}