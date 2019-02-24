using Microsoft.EntityFrameworkCore;
using UltraBugTracker.API.Models;

namespace UltraBugTracker.API.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Bug> Bugs { get; set; }
    }
}