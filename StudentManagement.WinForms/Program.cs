using Microsoft.EntityFrameworkCore;
using StudentManagement.WinForms.Data;

namespace StudentManagement.WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Khởi tạo cấu hình ứng dụng
        ApplicationConfiguration.Initialize();

        // Đảm bảo CSDL được tạo (Code-First)
        using (var db = DbFactory.CreateDbContext())
        {
            db.Database.EnsureCreated();
        }

        Application.Run(new Form1());
    }
}