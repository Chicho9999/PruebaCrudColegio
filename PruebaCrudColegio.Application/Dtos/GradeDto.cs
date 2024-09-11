namespace PruebaCrudColegio.Application.Dtos
{
    public class GradeDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? ProfessorName { get; set; }
        public Guid ProfessorId { get; set; }
    }
}
