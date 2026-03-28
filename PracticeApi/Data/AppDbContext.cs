using Microsoft.EntityFrameworkCore;
using PracticeApi.Models;
using System.Collections.Generic;

namespace PracticeApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
