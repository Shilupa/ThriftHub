using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public override string Id
        //{
        //    get { return base.Id.ToUpper(); } // Custom logic here
        //    set { base.Id = value; }
        //}

        [Required]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Street Address")]
        public string? StreetAddress { get; set; }

        public string? City { get; set; }
        public string? State { get; set; }
        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; }
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}