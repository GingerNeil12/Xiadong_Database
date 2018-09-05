using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFront.Models
{
    [Table("Note")]
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Reason { get; set; }

        [Required]
        [MaxLength(256)]
        public string Details { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateOfNote { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public Note() : this(0, "", "", DateTime.Now, 0)
        {

        }

        public Note(int id, string reason, string details, DateTime dateOfNote, int contactId)
        {
            Id = id;
            Reason = reason;
            Details = details;
            DateOfNote = dateOfNote;
            ContactId = contactId;
        }
    }
}