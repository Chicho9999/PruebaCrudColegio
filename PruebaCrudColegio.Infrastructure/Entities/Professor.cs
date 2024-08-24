using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaCrudColegio.Core.Model
{
    [Table("Professor")]
    public class Professor : BaseEntity
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required Guid CollegeId { get; set; }

        public College College { get; set; }
        public List<Student>? Students { get; set; }

    }
}
