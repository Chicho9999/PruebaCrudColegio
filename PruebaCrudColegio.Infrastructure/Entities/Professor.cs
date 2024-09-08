using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaCrudColegio.Core.Model
{
    [Table("Professor")]
    public class Professor : BaseEntity
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        [MaxLength(1)]
        public required char Gender { get; set; }

        public List<Grade> Grades { get; set; }

    }
}
