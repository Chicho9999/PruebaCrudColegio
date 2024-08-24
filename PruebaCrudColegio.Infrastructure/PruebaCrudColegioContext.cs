using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaCrudColegio.Core.Model;

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
        public DbSet<College> Colleges  { get; set; }
        public DbSet<Professor> Professors  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<College>()
                .HasMany(e => e.Students)
                .WithOne(e => e.College)
                .HasForeignKey(e => e.CollegeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<College>()
                .HasMany(e => e.Professors)
                .WithOne(e => e.College)
                .HasForeignKey(e => e.CollegeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasOne(e => e.College)
                .WithMany(e => e.Students)
                .HasForeignKey(e => e.CollegeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasOne(e => e.Professor)
                .WithMany(e => e.Students)
                .HasForeignKey(e => e.ProfessorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .HasMany(e => e.Students)
                .WithOne(e => e.Professor)
                .HasForeignKey(e => e.ProfessorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .HasOne(e => e.College)
                .WithMany(e => e.Professors)
                .HasForeignKey(e => e.CollegeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            var college = new College
            {
                Id = Guid.Parse("9cbea81b-aada-4f31-8250-467bb3a5c0aa"),
                Name = "Normal",
                Address = "Tucuman 868"
            };
            var professor = new Professor
            {
                Id = Guid.Parse("a0327b17-49d7-499f-97e1-cfd28df1b094"),
                FirstName = "Alejandro",
                LastName = "Lopez",
                CollegeId = college.Id
            };
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = "Lisandro",
                LastName = "Test Description",
                CollegeId = college.Id,
                ProfessorId = professor.Id,
            };

            modelBuilder.Entity<College>().HasData(college);
            modelBuilder.Entity<Professor>().HasData(professor);
            modelBuilder.Entity<Student>().HasData(student);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
