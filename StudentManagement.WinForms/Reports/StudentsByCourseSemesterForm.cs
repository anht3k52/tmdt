using Microsoft.EntityFrameworkCore;
using StudentManagement.WinForms.Data;
using System.ComponentModel;

namespace StudentManagement.WinForms.Reports;

public partial class StudentsByCourseSemesterForm : Form
{
    public StudentsByCourseSemesterForm()
    {
        InitializeComponent();
        Load += (_, __) =>
        {
            try
            {
                using var db = DbFactory.CreateDbContext();
                var courses = db.Courses.AsNoTracking()
                    .OrderBy(x => x.CourseCode)
                    .Select(x => new { x.Id, x.CourseCode, x.Name, Display = x.CourseCode + " - " + x.Name })
                    .ToList();
                cmbCourse.DisplayMember = "Display";
                cmbCourse.ValueMember = "CourseCode";
                cmbCourse.DataSource = courses;
                if (courses.Count > 0) cmbCourse.SelectedIndex = 0;

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
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}");
            }
        };

        btnRefresh.Click += (_, __) => RefreshReport();
    }

    private void RefreshReport()
    {
        if (cmbCourse.SelectedValue == null || cmbSemester.SelectedValue == null) return;
        var courseCode = cmbCourse.SelectedValue.ToString() ?? string.Empty;
        var semCode = cmbSemester.SelectedValue.ToString() ?? string.Empty;
        try
        {
            using var db = DbFactory.CreateDbContext();
            var data = db.Enrollments
                .Where(x => x.Course.CourseCode == courseCode && x.Semester.Code == semCode)
                .Select(x => new StudentsByCourseRow
                {
                    StudentCode = x.Student.StudentCode,
                    FullName = x.Student.FullName,
                    ClassName = x.Student.ClassName,
                    Grade = x.Grade
                })
                .OrderBy(x => x.StudentCode)
                .ToList();

            dgv.DataSource = new BindingList<StudentsByCourseRow>(data);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tạo báo cáo: {ex.Message}");
        }
    }
}

public class StudentsByCourseRow
{
    public string StudentCode { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? ClassName { get; set; }
    public double? Grade { get; set; }
}
