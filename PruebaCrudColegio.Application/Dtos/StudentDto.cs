namespace PruebaCrudColegio.Application.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid CollegeId { get; set; }

    }
}
