using Microsoft.EntityFrameworkCore;
using MVC_EF1.Models;

namespace MVC_EF1
{
    public class StudentsDBContext : DbContext
    {
        public StudentsDBContext(DbContextOptions<StudentsDBContext> options) : base(options)
        {

        }

        public DbSet<StudentDBModel> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDBModel>().ToTable("Students");
        }

    }
}
