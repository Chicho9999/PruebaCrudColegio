using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaCrudColegio.Core.Model
{
    [Table("Student")]
    public class Student : BaseEntity
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required Guid CollegeId { get; set; }

        public College College { get; set; }

        [Required]
        public required Guid ProfessorId { get; set; }

        public Professor Professor { get; set; }

    }
}
