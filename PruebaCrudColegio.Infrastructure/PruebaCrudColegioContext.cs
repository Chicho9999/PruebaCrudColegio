using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Enums;

namespace PruebaCrudColegio.Infrastructure
{
    public class PruebaCrudColegioContext : DbContext
    {
        private readonly string connectionString;

        public PruebaCrudColegioContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades  { get; set; }
        public DbSet<Professor> Professors  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .HasOne(e => e.Professor)
                .WithMany(e => e.Grades)
                .HasForeignKey(e => e.ProfessorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Grades)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .HasMany(e => e.Grades)
                .WithOne(e => e.Professor)
                .HasForeignKey(e => e.ProfessorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<StudentGrade>()
            .HasKey(t => new { t.StudentId, t.GradeId });

            modelBuilder.Entity<StudentGrade>()
                .HasOne(pt => pt.Student)
                .WithMany(p => p.Grades)
                .HasForeignKey(pt => pt.StudentId);

            modelBuilder.Entity<StudentGrade>()
                .HasOne(pt => pt.Grade)
                .WithMany(p => p.Students)
                .HasForeignKey(pt => pt.GradeId);


            var professor1 = new Professor
            {
                Id = Guid.Parse("a0327b17-49d7-499f-97e1-cfd28df1b094"),
                FirstName = "Alejandro",
                LastName = "Lopez",
                Gender = GenderEnum.Masculino
            };

            var professor2 = new Professor
            {
                Id = Guid.Parse("9ba804fb-e068-4c49-8754-4beb6437de51"),
                FirstName = "Angela",
                LastName = "Perez",
                Gender = GenderEnum.Femenino
            };

            var grade1 = new Grade
            {
                Id = Guid.Parse("9cbea81b-aada-4f31-8250-467bb3a5c0aa"),
                Name = "Normal",
                ProfessorId = professor1.Id,
            };

            var grade2 = new Grade
            {
                Id = Guid.Parse("5f85a554-16c7-4780-96aa-7dad227fb974"),
                Name = "Privada",
                ProfessorId = professor2.Id,
            };

            var student1 = new Student()
            {
                Id = Guid.Parse("0b6682c4-0841-4612-b1fd-4a9d565543e2"),
                FirstName = "Carlos",
                LastName = "Chichi",
                Gender = GenderEnum.Masculino,
                BirthDay = DateTime.Parse("01/01/1995")
            };

            var student2 = new Student()
            {
                Id = Guid.Parse("f4e9bc25-f21e-473a-bdd3-cee5cacbdf2e"),
                FirstName = "Antonella",
                LastName = "Perez",
                Gender = GenderEnum.Femenino,
                BirthDay = DateTime.Parse("05/02/1993")
            };

            var studentGrade1 = new StudentGrade
            {
                Id = Guid.NewGuid(),
                GradeId = grade1.Id,
                StudentId = student1.Id,
                Section = 1
            };


            var studentGrade2 = new StudentGrade
            {
                Id = Guid.NewGuid(),
                GradeId = grade2.Id,
                StudentId = student1.Id,
                Section = 2
            };

            modelBuilder.Entity<Grade>().HasData(grade1);
            modelBuilder.Entity<Grade>().HasData(grade2);
            modelBuilder.Entity<Professor>().HasData(professor1);
            modelBuilder.Entity<Professor>().HasData(professor2);
            modelBuilder.Entity<Student>().HasData(student1);
            modelBuilder.Entity<Student>().HasData(student2);
            modelBuilder.Entity<StudentGrade>().HasData(studentGrade1);
            modelBuilder.Entity<StudentGrade>().HasData(studentGrade2);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
