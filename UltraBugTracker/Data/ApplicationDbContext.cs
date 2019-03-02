using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UBT.Common.API.Models;
using UBT.Common.Authentication;
using UBT.Common.Authentication.Models;

namespace UBT.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        #region Constructor
        readonly IPasswordHasher<User> _passHasher;
        public ApplicationDbContext(DbContextOptions options, IPasswordHasher<User> passHasher) : base(options)
        {
            _passHasher = passHasher;
        }
        #endregion

        #region Entities
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        #region Seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Default roles
            var adminRole = new IdentityRole { Id = Defaults.AdminRoleId, Name = Defaults.AdminRoleName };
            var userRole = new IdentityRole { Id = Defaults.UserRoleId, Name = Defaults.UserRoleName };
            modelBuilder.Entity<IdentityRole>().HasData(adminRole, userRole);

            // Admin user
            var adminUser = new User
            {
                Id = Defaults.AdminId,
                UserName = Defaults.AdminName,
                NormalizedUserName = Defaults.AdminName,
                Email = "some-email@nonce.fake",
                NormalizedEmail = "some-email@nonce.fake",
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };
            adminUser.PasswordHash = _passHasher.HashPassword(adminUser, Defaults.Password);
            modelBuilder.Entity<User>().HasData(adminUser);
            var adminUserRole = new IdentityUserRole<string>() { UserId = adminUser.Id, RoleId = adminRole.Id };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);

            // Test user
            var testUser = new User
            {
                Id = Defaults.TestUserId,
                UserName = Defaults.TestUserName,
                NormalizedUserName = Defaults.TestUserName,
                Email = "some-email@nonce.fake",
                NormalizedEmail = "some-email@nonce.fake",
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };
            testUser.PasswordHash = _passHasher.HashPassword(testUser, Defaults.Password);
            modelBuilder.Entity<User>().HasData(testUser);
            var testUserRole = new IdentityUserRole<string>() { UserId = testUser.Id, RoleId = userRole.Id };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(testUserRole);

            // Test data
            var unknownArea = new Area
            {
                Id = 1,
                Name = "Unknown area",
                Description = "The bug doesn't fit to any other area"
            };
            modelBuilder.Entity<Area>().HasData(unknownArea);

            modelBuilder.Entity<Bug>().HasData(
                new Bug
                {
                    Id = 1,
                    AreaId = unknownArea.Id,
                    AuthorId = Defaults.TestUserId,
                    CreateDate = new DateTime(2000, 1, 1),
                    Description = "Ultra bug new",
                    Status = BugStatus.New
                },
                new Bug
                {
                    Id = 2,
                    AreaId = unknownArea.Id,
                    AuthorId = Defaults.TestUserId,
                    CreateDate = new DateTime(2000, 2, 1),
                    Description = "Ultra bug in progress",
                    Status = BugStatus.InProgress
                },
                new Bug
                {
                    Id = 3,
                    AreaId = unknownArea.Id,
                    AuthorId = Defaults.TestUserId,
                    CreateDate = new DateTime(2000, 3, 1),
                    CloseDate = new DateTime(2020, 3, 1),
                    Description = "Ultra bug closed",
                    Status = BugStatus.Closed
                });
        }

        #endregion
    }
}