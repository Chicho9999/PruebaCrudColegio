
using System.ComponentModel.DataAnnotations;

namespace PruebaCrudColegio.Core.Model
{
    public class College : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public List<Student> Students { get; set; }

    }
}
