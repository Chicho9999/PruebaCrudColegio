
using System.ComponentModel.DataAnnotations;

namespace PruebaCrudColegio.Core.Model
{
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
