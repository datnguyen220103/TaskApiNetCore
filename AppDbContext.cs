using Microsoft.EntityFrameworkCore;
using TaskListApi.Models;

public class AppDbContext : DbContext
{
    #region db set
    public DbSet<TaskItem> TaskItems { get; set; }

    #endregion

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}