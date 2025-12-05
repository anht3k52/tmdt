using Microsoft.EntityFrameworkCore;
using StudentManagement.WinForms.Data;
using System.Globalization;

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

        // Thiết lập văn hóa tiếng Việt để nhập ngày dd/MM/yyyy
        var culture = new CultureInfo("vi-VN");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        // Đảm bảo CSDL được tạo (Code-First)
        using (var db = DbFactory.CreateDbContext())
        {
            db.Database.EnsureCreated();
        }

        using (var login = new LoginForm())
        {
            var result = login.ShowDialog();
            if (result != DialogResult.OK)
                return;
        }

        Application.Run(new Form1());
    }
}