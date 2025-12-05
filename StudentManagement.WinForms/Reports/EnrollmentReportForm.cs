using Microsoft.EntityFrameworkCore;
using StudentManagement.WinForms.Data;
using System.ComponentModel;

namespace StudentManagement.WinForms.Reports;

public partial class EnrollmentReportForm : Form
{
    public EnrollmentReportForm()
    {
        InitializeComponent();
        Load += (_, __) =>
        {
            try
            {
                using var db = DbFactory.CreateDbContext();
                var sems = db.Semesters.AsNoTracking()
                    .OrderBy(x => x.Code)
                    .Select(x => new { x.Id, x.Code, x.Name, Display = x.Name + " (" + x.Code + ")" })
                    .ToList();
                cmbSemester.DisplayMember = "Display";
                cmbSemester.ValueMember = "Code";
                cmbSemester.DataSource = sems;
                if (sems.Count > 0) cmbSemester.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải học kỳ: {ex.Message}");
            }
        };

        btnRefresh.Click += (_, __) => RefreshReport();
    }

    private void RefreshReport()
    {
        if (cmbSemester.SelectedValue == null) return;
        var semCode = cmbSemester.SelectedValue.ToString() ?? string.Empty;
        try
        {
            using var db = DbFactory.CreateDbContext();
            var data = db.Enrollments
                .Where(e => e.Semester.Code == semCode)
                .Select(e => new
                {
                    e.Student.StudentCode,
                    e.Student.FullName,
                    e.Student.ClassName,
                    e.Course.CourseCode
                })
                .AsEnumerable()
                .GroupBy(x => new { x.StudentCode, x.FullName, x.ClassName })
                .Select(g => new EnrollmentReportRow
                {
                    StudentCode = g.Key.StudentCode,
                    FullName = g.Key.FullName,
                    ClassName = g.Key.ClassName,
                    Courses = string.Join(", ", g.Select(i => i.CourseCode).OrderBy(s => s))
                })
                .OrderBy(x => x.StudentCode)
                .ToList();

            dgv.DataSource = new BindingList<EnrollmentReportRow>(data);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tạo báo cáo: {ex.Message}");
        }
    }
}

public class EnrollmentReportRow
{
    public string StudentCode { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? ClassName { get; set; }
    public string Courses { get; set; } = string.Empty;
}
