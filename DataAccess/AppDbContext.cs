using Microsoft.EntityFrameworkCore;
using kullaniciGorevTakipSistemi.Entities;
using System.Collections.Generic;

namespace kullaniciGorevTakipSistemi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}


