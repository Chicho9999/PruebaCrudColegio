using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaCrudColegio.Core.Model
{
    [Table("Student")]
    public class Student : BaseEntity
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        [MaxLength(1)]
        public required char Gender { get; set; }

        public required DateTime BirthDay { get; set; }

        public List<StudentGrade> Grades { get; set; }
    }
}
