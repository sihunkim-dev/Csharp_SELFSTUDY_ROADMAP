using Microsoft.EntityFrameworkCore;
using To_Do_ListAPI.Models;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Todos>(entity =>
        {
            //Primary key configuration
            entity.HasKey(e => e.Id);
            entity.Property(e=>e.Id)
                .ValueGeneratedOnAdd(); //Id property will be generated automatically when a new record is added to the database.

            //Title property configuration
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Title"); //Title property is required, has a maximum length of 50 characters, and will be mapped to a column named "Title" in the database.
        
            //IsCompleted property configuration
            entity.Property(e => e.IsCompleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("IsCompleted"); //IsCompleted property is required, has a default value of false, and will be mapped to a column named "IsCompleted" in the database.

        });
    }

    public DbSet<Todos> Todos { get; set; }

}