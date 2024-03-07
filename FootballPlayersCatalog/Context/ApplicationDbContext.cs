using Microsoft.EntityFrameworkCore;
using FootballPlayersCatalog.Models;
using System;

namespace FootballPlayersCatalog.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<PlayerFormModel> Players { get; set; }
    }
}
