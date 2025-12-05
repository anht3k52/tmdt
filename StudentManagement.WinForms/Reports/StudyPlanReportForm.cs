using Microsoft.EntityFrameworkCore;
using StudentManagement.WinForms.Data;
using System.ComponentModel;

namespace StudentManagement.WinForms.Reports;

public partial class StudyPlanReportForm : Form
{
    public StudyPlanReportForm()
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
                .Where(x => x.Semester.Code == semCode)
                .Select(x => new StudyPlanRow
                {
                    StudentCode = x.Student.StudentCode,
                    FullName = x.Student.FullName,
                    CourseCode = x.Course.CourseCode,
                    CourseName = x.Course.Name,
                    Credits = x.Course.Credits
                })
                .OrderBy(x => x.StudentCode).ThenBy(x => x.CourseCode)
                .ToList();

            dgv.DataSource = new BindingList<StudyPlanRow>(data);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tạo báo cáo: {ex.Message}");
        }
    }
}

public class StudyPlanRow
{
    public string StudentCode { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string CourseCode { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public int Credits { get; set; }
}
