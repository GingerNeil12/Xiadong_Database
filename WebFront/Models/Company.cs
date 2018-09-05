using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFront.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Address { get; set; }

        [Required]
        [MaxLength(256)]
        public string City { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public Company() : this(0, "", "", "", 0)
        {
        }
        public Company(int id, string name, string address, string city, int regionId)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            RegionId = regionId;
            Region = new Region();
            Contacts = new List<Contact>();
        }
    }
}