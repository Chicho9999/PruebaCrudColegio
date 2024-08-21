using System.ComponentModel.DataAnnotations;

namespace PruebaCrudColegio.Core.Model
{
    public class Student : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Guid CollegeId { get; set; }

        public College College { get; set; }

    }
}
