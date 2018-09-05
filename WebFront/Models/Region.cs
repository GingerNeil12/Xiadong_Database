using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFront.Models
{
    [Table("Region")]
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Country { get; set; }

        public ICollection<Company> Companies { get; set; }

        public Region() : this(0, "", "")
        {
        }

        public Region(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
            Companies = new List<Company>();
        }
    }
}