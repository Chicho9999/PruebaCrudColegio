namespace PruebaCrudColegio.Application.Dtos
{
    public class StudentGradeDto
    {
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? GradeId { get; set; }
        public Guid? ProfessorId { get; set; }
        public string? GradeName { get; set; }
        public string? StudentName { get; set; }
        public string? ProfessorName { get; set; }
        public int Section { get; set; }
    }
}
