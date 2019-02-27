using System;
using Microsoft.EntityFrameworkCore;
using UltraBugTracker.API.Models;

namespace UltraBugTracker.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Bug> Bugs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bug>().HasData(new[]
            {
                new Bug()
                {
                    Id = 1,
                    AreaId = 0,
                    AuthorId = 0,
                    CreateDate = new DateTime(2000,1,1),
                    Description = "Ultra bug new",
                    Status = BugStatus.New
                },
                new Bug()
                {
                    Id = 2,
                    AreaId = 0,
                    AuthorId = 0,
                    CreateDate = new DateTime(2000,2,1),
                    Description = "Ultra bug in progress",
                    Status = BugStatus.InProgress
                },
                new Bug()
                {
                    Id = 3,
                    AreaId = 0,
                    AuthorId = 0,
                    CreateDate = new DateTime(2000,3,1),
                    CloseDate = new DateTime(2020,3,1),
                    Description = "Ultra bug closed",
                    Status = BugStatus.Closed
                },
            });
        }
    }
}