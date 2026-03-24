using Ability.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ability.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasKey(t => t.Id);

            modelBuilder.Entity<Ticket>().Property(t => t.Title).IsRequired().HasMaxLength(100);
        }
    }
}
