using Microsoft.EntityFrameworkCore;

namespace GardenLog.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions options) : base(options)
        {

        }
    }
}
