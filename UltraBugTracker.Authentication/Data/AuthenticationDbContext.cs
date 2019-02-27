using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UltraBugTracker.Common.Authentication.Models;

namespace UltraBugTracker.Authentication.Data
{
    public class AuthenticationDbContext: IdentityDbContext<User>
    {
        public AuthenticationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            string adminRoleName = "admin";
            string userRoleName = "user";
            var adminRole = new IdentityRole { Id = "1", Name = adminRoleName };
            var userRole =  new IdentityRole { Id = "2", Name = userRoleName };
            modelBuilder.Entity<IdentityRole>().HasData(adminRole, userRole);

            string adminName = "admin";
            string adminPasswordHash = "AQAAAAEAACcQAAAAEIEJpPmCwsXjQaAn/9Pa8FneJNQU6y9VBMESVE3+jwXoWZk0O2HWfPlRtyIsBz5fpg==";
            var adminUser = new User { Id = "1", UserName = adminName, PasswordHash = adminPasswordHash};
            modelBuilder.Entity<User>().HasData(adminUser);

            var adminUserRole = new IdentityUserRole<string>() {UserId = adminUser.Id, RoleId = adminRole.Id};
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);

            base.OnModelCreating(modelBuilder);

        }

    }
}