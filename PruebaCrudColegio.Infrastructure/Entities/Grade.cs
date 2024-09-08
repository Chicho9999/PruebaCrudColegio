using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaCrudColegio.Core.Model
{
    [Table("Grade")]
    public class Grade : BaseEntity
    {
        public required string Name { get; set; }

        public required Guid ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public List<StudentGrade> Students { get; set; }
    }
}
