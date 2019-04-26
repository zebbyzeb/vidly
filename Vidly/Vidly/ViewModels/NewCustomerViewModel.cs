using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        //public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public int? MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

    }
}