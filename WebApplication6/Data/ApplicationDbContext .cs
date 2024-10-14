using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tazkarty.Models;

namespace Tazkarty.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5QU8GSA\\SQLEXPRESS;Database = Tazkarty;Integrated Security=true;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Match)
                .WithMany(m => m.Tickets)
                .HasForeignKey(t => t.MatchId)
                .OnDelete(DeleteBehavior.Cascade); // Configure delete behavior

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Configure delete behavior

            base.OnModelCreating(modelBuilder);
        }

    }
}
