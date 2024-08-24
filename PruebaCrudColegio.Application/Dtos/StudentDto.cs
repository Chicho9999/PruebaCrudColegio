namespace PruebaCrudColegio.Application.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? CollegeName { get; set; }
        public string? ProfessorName { get; set; }
        public Guid CollegeId { get; set; }
        public Guid ProfessorId { get; set; }
    }
}
