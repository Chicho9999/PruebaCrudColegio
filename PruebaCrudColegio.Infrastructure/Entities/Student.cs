using PruebaCrudColegio.Infrastructure.Entities;
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
        [MaxLength(1)]
        public required char Gender { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        public List<StudentGrade> Grades { get; set; }
    }
}
