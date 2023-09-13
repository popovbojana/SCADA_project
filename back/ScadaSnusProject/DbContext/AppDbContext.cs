using Microsoft.EntityFrameworkCore;
using ScadaSnusProject.Model;

namespace ScadaSnusProject.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}