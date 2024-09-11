namespace PruebaCrudColegio.Application.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public char Gender { get; set; }
        public string BirthDay { get; set; }
        public List<StudentGradeDto> Grades { get; set; }
    }
}
