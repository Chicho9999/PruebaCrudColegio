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
        [MaxLength(1)]
        public required char Gender { get; set; }

        public List<Grade> Grades { get; set; }

    }
}
