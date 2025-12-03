using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using StudentManagement.Data;
using StudentManagement.WinForms.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace StudentManagement.WinForms.Reports;

public static class ReportService
{
    static ReportService()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public static string GenerateStudyPlanBySemester(string semesterCode)
    {
        using var db = DbFactory.CreateDbContext();
        var sem = db.Semesters.FirstOrDefault(x => x.Code == semesterCode);
        var enrollments = db.Enrollments
            .Where(x => x.Semester.Code == semesterCode)
            .Select(x => new
            {
                x.Student.StudentCode,
                x.Student.FullName,
                x.Course.CourseCode,
                CourseName = x.Course.Name,
                x.Course.Credits
            })
            .OrderBy(x => x.StudentCode).ThenBy(x => x.CourseCode)
            .ToList();

        var file = Path.Combine(AppContext.BaseDirectory, $"BaoCao_KeHoach_{semesterCode}.pdf");

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Header().Text($"Kế hoạch học tập - Học kỳ: {semesterCode}").SemiBold().FontSize(18);
                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(2);
                        cols.RelativeColumn(3);
                        cols.RelativeColumn(2);
                        cols.RelativeColumn(4);
                        cols.ConstantColumn(60);
                    });
                    table.Header(h =>
                    {
                        h.Cell().Text("Mã SV").SemiBold();
                        h.Cell().Text("Họ tên").SemiBold();
                        h.Cell().Text("Mã môn").SemiBold();
                        h.Cell().Text("Tên môn").SemiBold();
                        h.Cell().Text("TC").SemiBold();
                    });
                    foreach (var i in enrollments)
                    {
                        table.Cell().Text(i.StudentCode);
                        table.Cell().Text(i.FullName);
                        table.Cell().Text(i.CourseCode);
                        table.Cell().Text(i.CourseName);
                        table.Cell().Text(i.Credits.ToString());
                    }
                });
                page.Footer().AlignRight().Text(x =>
                {
                    x.Span("Trang ");
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
        }).GeneratePdf(file);

        return file;
    }

    public static string GenerateStudentsByCourseSemester(string courseCode, string semesterCode)
    {
        using var db = DbFactory.CreateDbContext();
        var data = db.Enrollments
            .Where(x => x.Course.CourseCode == courseCode && x.Semester.Code == semesterCode)
            .Select(x => new
            {
                x.Student.StudentCode,
                x.Student.FullName,
                x.Student.ClassName,
                x.Grade
            })
            .OrderBy(x => x.StudentCode)
            .ToList();

        var file = Path.Combine(AppContext.BaseDirectory, $"BaoCao_DSSV_{courseCode}_{semesterCode}.pdf");

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Header().Text($"Danh sách SV - Môn: {courseCode} - HK: {semesterCode}").SemiBold().FontSize(18);
                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(2);
                        cols.RelativeColumn(4);
                        cols.RelativeColumn(3);
                        cols.ConstantColumn(60);
                    });
                    table.Header(h =>
                    {
                        h.Cell().Text("Mã SV").SemiBold();
                        h.Cell().Text("Họ tên").SemiBold();
                        h.Cell().Text("Lớp").SemiBold();
                        h.Cell().Text("Điểm").SemiBold();
                    });
                    foreach (var i in data)
                    {
                        table.Cell().Text(i.StudentCode);
                        table.Cell().Text(i.FullName);
                        table.Cell().Text(i.ClassName ?? "");
                        table.Cell().Text(i.Grade?.ToString("0.##") ?? "");
                    }
                });
                page.Footer().AlignRight().Text(x =>
                {
                    x.Span("Trang ");
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
        }).GeneratePdf(file);

        return file;
    }
}
