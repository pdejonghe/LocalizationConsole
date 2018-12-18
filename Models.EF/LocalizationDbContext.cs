using Microsoft.EntityFrameworkCore;
using System;

namespace Models.EF
{
    public class LocalizationDbContext : DbContext
    {
        public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
