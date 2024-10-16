using Microsoft.EntityFrameworkCore;
using ResumeApp.Data.Models;

namespace ResumeApp.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
        public DbSet<Candidate> candidate {  get; set; }
        public DbSet<Degree> degree { get; set; }
    }
}
