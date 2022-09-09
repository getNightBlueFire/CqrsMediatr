using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatrExample.DataStore;

public class ProjectDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    private string DbPath { get; }
    
    public ProjectDbContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "tested.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlite($"Filename={DbPath}",
            options => { options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName); });
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map table names
        modelBuilder.Entity<Blog>().ToTable("Blogs", "test");
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId);
            entity.HasIndex(e => e.Title).IsUnique();
            entity.Property(e => e.DateTimeAdd).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
        base.OnModelCreating(modelBuilder);
    }
}