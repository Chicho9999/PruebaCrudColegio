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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<College>()
                .HasMany(e => e.Students)
                .WithOne(e => e.College)
                .HasForeignKey(e => e.CollegeId)
                .IsRequired();

            modelBuilder.Entity<College>().HasData(new College { Id = Guid.Parse("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), Name = "Normal", Address = "Tucuman 868"});
            modelBuilder.Entity<Student>().HasData(new Student { Id = Guid.NewGuid(), FirstName = "Lisandro", LastName = "Test Description", CollegeId = Guid.Parse("9cbea81b-aada-4f31-8250-467bb3a5c0aa") });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
