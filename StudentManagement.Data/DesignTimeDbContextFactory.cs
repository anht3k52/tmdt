using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace StudentManagement.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();

        var basePath = Directory.GetCurrentDirectory();
        var dbPath = Path.Combine(basePath, "app.db");
        var connection = $"Data Source={dbPath}";

        builder.UseSqlite(connection);
        return new AppDbContext(builder.Options);
    }
}
