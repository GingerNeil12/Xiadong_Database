using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFront.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string PhoneNumber { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public ICollection<Note> Notes { get; set; }

        public Contact() : this(0, "", "", "", "", 0)
        {

        }

        public Contact(int id, string firstName, string lastName, 
            string email, string phoneNumber, int companyId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            CompanyId = companyId;
            Company = new Company();
            Notes = new List<Note>();
        }
    }
}