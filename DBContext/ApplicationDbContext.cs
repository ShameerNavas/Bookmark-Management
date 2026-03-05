using Microsoft.EntityFrameworkCore;
using BOOKMARK.Models;
using System.Collections.Generic;

namespace BOOKMARK.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Bookmark> Bookmarks { get; set; }

    }
}
