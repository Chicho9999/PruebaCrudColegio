using PruebaCrudColegio.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace PruebaCrudColegio.Infrastructure.Entities
{
    public class StudentGrade : BaseEntity
    {
        public Guid? GradeId { get; set; }

        public Guid? StudentId { get; set; }

        public Student? Student { get; set; }

        public Grade? Grade { get; set; }

        public required int Section { get; set; }
    }
}
