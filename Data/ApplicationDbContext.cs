using Microsoft.EntityFrameworkCore;
using PublicNotes.Models;

namespace PublicNotes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // This tells EF Core "We want a table for our 'Note' model"
        public DbSet<Note> Notes { get; set; }
    }
}