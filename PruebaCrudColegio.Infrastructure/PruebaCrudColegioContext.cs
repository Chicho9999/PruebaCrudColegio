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

            var college1 = new College
            {
                Id = Guid.Parse("9cbea81b-aada-4f31-8250-467bb3a5c0aa"),
                Name = "Normal",
                Address = "Tucuman 868"
            };

            var college2 = new College
            {
                Id = Guid.Parse("5f85a554-16c7-4780-96aa-7dad227fb974"),
                Name = "Privada",
                Address = "Buenos Aires 80"
            };

            var professor1 = new Professor
            {
                Id = Guid.Parse("a0327b17-49d7-499f-97e1-cfd28df1b094"),
                FirstName = "Alejandro",
                LastName = "Lopez",
                CollegeId = college1.Id
            };

            var professor2 = new Professor
            {
                Id = Guid.Parse("9ba804fb-e068-4c49-8754-4beb6437de51"),
                FirstName = "Angel",
                LastName = "Perez",
                CollegeId = college1.Id
            };

            var student = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = "Lisandro",
                LastName = "Test Description",
                CollegeId = college1.Id,
                ProfessorId = professor1.Id,
            };

            modelBuilder.Entity<College>().HasData(college1);
            modelBuilder.Entity<College>().HasData(college2);
            modelBuilder.Entity<Professor>().HasData(professor1);
            modelBuilder.Entity<Professor>().HasData(professor2);
            modelBuilder.Entity<Student>().HasData(student);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
