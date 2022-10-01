using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Roadmap.Models;

namespace Roadmap.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Roadmap.Models.User> User { get; set; }
        public DbSet<Roadmap.Models.Event> Event { get; set; }
    }
}