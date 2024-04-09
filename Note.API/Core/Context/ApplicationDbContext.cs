using Microsoft.EntityFrameworkCore;
using Note.API.Core.Entities;


namespace Note.API.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        public DbSet<NoteEntity> Notes { get; set; }
    }
}
