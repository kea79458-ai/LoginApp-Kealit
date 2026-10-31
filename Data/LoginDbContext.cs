using LoginApp_Kealit.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginApp_Kealit.Data
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}