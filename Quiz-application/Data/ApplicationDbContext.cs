using Microsoft.EntityFrameworkCore;
using Quiz_application.Models.Entities;

namespace Quiz_application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        
    }
}
