
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaCrudColegio.Core.Model
{
    [Table("College")]
    public class College : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Address { get; set; }

        public List<Student>? Students { get; set; }

        public List<Professor>? Professors { get; set; }

    }
}
