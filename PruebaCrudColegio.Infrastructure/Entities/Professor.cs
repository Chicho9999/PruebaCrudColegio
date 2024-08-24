using System.ComponentModel.DataAnnotations;

namespace PruebaCrudColegio.Core.Model
{
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
