using CookieAuthentication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CookieAuthentication.DataAccess
{
    public class AccountDbContext:DbContext
    {
        private readonly IConfiguration configuration;
        public AccountDbContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionStrings:Sql").Value);
        }
    }
}
