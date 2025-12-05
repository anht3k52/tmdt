using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using System.IO;

namespace StudentManagement.WinForms.Data;

public static class DbFactory
{
    public static string GetDbPath()
    {
        var basePath = AppContext.BaseDirectory;
        return Path.Combine(basePath, "app.db");
    }

    public static AppDbContext CreateDbContext()
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connection = $"Data Source={GetDbPath()}";
        builder.UseSqlite(connection);
        return new AppDbContext(builder.Options);
    }
}
