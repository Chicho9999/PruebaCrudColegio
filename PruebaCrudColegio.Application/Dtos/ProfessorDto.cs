namespace PruebaCrudColegio.Application.Dtos
{
    public class ProfessorDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public char Gender { get; set; }
    }
}
