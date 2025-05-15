using Microsoft.EntityFrameworkCore;
using Services.User.Entity;

namespace Services.User.Context;

public class ServiceContext : DbContext
{
    public DbSet<UserDto> Пользователь { get; set; } = null!;

    public DbSet<SecretQuestionDto> СекретныйВопрос { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=Lab5;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDto>().HasKey("КодПользователя");
        modelBuilder.Entity<SecretQuestionDto>().HasKey("КодСекретногоВопроса");
        base.OnModelCreating(modelBuilder);
    }
}
