using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.WinForms.Data;
using StudentManagement.WinForms.Reports;
using Microsoft.VisualBasic; // For Interaction.InputBox

namespace StudentManagement.WinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        this.Load += (_, __) =>
        {
            LoadStudents();
            LoadCourses();
            LoadSemesters();
            LoadEnrollments();
        };

        btnStuAdd.Click += (_, __) => AddStudent();
        btnStuDelete.Click += (_, __) => DeleteSelectedStudent();
        btnStuSave.Click += (_, __) => SaveStudents();

        btnCouAdd.Click += (_, __) => AddCourse();
        btnCouDelete.Click += (_, __) => DeleteSelectedCourse();
        btnCouSave.Click += (_, __) => SaveCourses();

        btnSemAdd.Click += (_, __) => AddSemester();
        btnSemDelete.Click += (_, __) => DeleteSelectedSemester();
        btnSemSave.Click += (_, __) => SaveSemesters();

        btnEnrAdd.Click += (_, __) => AddEnrollment();
        btnEnrDelete.Click += (_, __) => DeleteSelectedEnrollment();
        btnEnrSave.Click += (_, __) => SaveEnrollments();

        mnuBC_KeHoachHocTap.Click += (_, __) =>
        {
            var sem = Interaction.InputBox("Nhập mã Học kỳ (ví dụ: 2025-1)", "Báo cáo kế hoạch học tập", "");
            if (!string.IsNullOrWhiteSpace(sem))
            {
                var file = ReportService.GenerateStudyPlanBySemester(sem.Trim());
                MessageBox.Show($"Đã tạo: {file}");
                try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = file, UseShellExecute = true }); } catch { }
            }
        };
        mnuBC_DSSVTheoMonHK.Click += (_, __) =>
        {
            var course = Interaction.InputBox("Nhập mã Môn học (vd: CT101)", "Báo cáo danh sách SV", "");
            var sem = Interaction.InputBox("Nhập mã Học kỳ (vd: 2025-1)", "Báo cáo danh sách SV", "");
            if (!string.IsNullOrWhiteSpace(course) && !string.IsNullOrWhiteSpace(sem))
            {
                var file = ReportService.GenerateStudentsByCourseSemester(course.Trim(), sem.Trim());
                MessageBox.Show($"Đã tạo: {file}");
                try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = file, UseShellExecute = true }); } catch { }
            }
        };
    }

    private void LoadStudents()
    {
        using var db = DbFactory.CreateDbContext();
        var data = db.Students.AsNoTracking().Select(s => new
        {
            s.Id,
            s.StudentCode,
            s.FullName,
            s.DateOfBirth,
            s.ClassName
        }).ToList();
        dgvStudents.DataSource = data;
    }

    private void AddStudent()
    {
        var src = dgvStudents.DataSource as List<dynamic>;
        if (src == null)
        {
            LoadStudents();
            src = dgvStudents.DataSource as List<dynamic>;
        }
        // Thêm dòng trống để nhập
        var list = src!.ToList();
        list.Add(new { Id = 0, StudentCode = "", FullName = "", DateOfBirth = (DateTime?)null, ClassName = "" });
        dgvStudents.DataSource = list;
    }

    private void DeleteSelectedStudent()
    {
        if (dgvStudents.CurrentRow == null) return;
        var idObj = dgvStudents.CurrentRow.Cells[nameof(Student.Id)]?.Value;
        if (idObj is int id && id > 0)
        {
            using var db = DbFactory.CreateDbContext();
            var entity = db.Students.Find(id);
            if (entity != null)
            {
                db.Students.Remove(entity);
                db.SaveChanges();
            }
        }
        LoadStudents();
    }

    private void SaveStudents()
    {
        using var db = DbFactory.CreateDbContext();
        foreach (DataGridViewRow row in dgvStudents.Rows)
        {
            if (row.IsNewRow) continue;
            var id = row.Cells[nameof(Student.Id)].Value?.ToString();
            var code = row.Cells[nameof(Student.StudentCode)].Value?.ToString() ?? "";
            var name = row.Cells[nameof(Student.FullName)].Value?.ToString() ?? "";
            DateTime? dob = null;
            if (DateTime.TryParse(row.Cells[nameof(Student.DateOfBirth)].Value?.ToString(), out var dt)) dob = dt;
            var cls = row.Cells[nameof(Student.ClassName)].Value?.ToString();

            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name)) continue;

            if (int.TryParse(id, out var iid) && iid > 0)
            {
                var entity = db.Students.Find(iid);
                if (entity != null)
                {
                    entity.StudentCode = code;
                    entity.FullName = name;
                    entity.DateOfBirth = dob;
                    entity.ClassName = cls;
                }
            }
            else
            {
                db.Students.Add(new Student
                {
                    StudentCode = code,
                    FullName = name,
                    DateOfBirth = dob,
                    ClassName = cls
                });
            }
        }
        db.SaveChanges();
        LoadStudents();
    }

    private void LoadCourses()
    {
        using var db = DbFactory.CreateDbContext();
        var data = db.Courses.AsNoTracking().Select(s => new { s.Id, s.CourseCode, s.Name, s.Credits }).ToList();
        dgvCourses.DataSource = data;
    }

    private void AddCourse()
    {
        var src = dgvCourses.DataSource as List<dynamic>;
        if (src == null)
        {
            LoadCourses();
            src = dgvCourses.DataSource as List<dynamic>;
        }
        var list = src!.ToList();
        list.Add(new { Id = 0, CourseCode = "", Name = "", Credits = 0 });
        dgvCourses.DataSource = list;
    }

    private void DeleteSelectedCourse()
    {
        if (dgvCourses.CurrentRow == null) return;
        var idObj = dgvCourses.CurrentRow.Cells[nameof(Course.Id)]?.Value;
        if (idObj is int id && id > 0)
        {
            using var db = DbFactory.CreateDbContext();
            var entity = db.Courses.Find(id);
            if (entity != null)
            {
                db.Courses.Remove(entity);
                db.SaveChanges();
            }
        }
        LoadCourses();
    }

    private void SaveCourses()
    {
        using var db = DbFactory.CreateDbContext();
        foreach (DataGridViewRow row in dgvCourses.Rows)
        {
            if (row.IsNewRow) continue;
            var id = row.Cells[nameof(Course.Id)].Value?.ToString();
            var code = row.Cells[nameof(Course.CourseCode)].Value?.ToString() ?? "";
            var name = row.Cells[nameof(Course.Name)].Value?.ToString() ?? "";
            var creditsStr = row.Cells[nameof(Course.Credits)].Value?.ToString();
            int credits = 0; int.TryParse(creditsStr, out credits);

            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name)) continue;

            if (int.TryParse(id, out var iid) && iid > 0)
            {
                var entity = db.Courses.Find(iid);
                if (entity != null)
                {
                    entity.CourseCode = code;
                    entity.Name = name;
                    entity.Credits = credits;
                }
            }
            else
            {
                db.Courses.Add(new Course { CourseCode = code, Name = name, Credits = credits });
            }
        }
        db.SaveChanges();
        LoadCourses();
    }

    private void LoadSemesters()
    {
        using var db = DbFactory.CreateDbContext();
        var data = db.Semesters.AsNoTracking().Select(s => new { s.Id, s.Code, s.Name }).ToList();
        dgvSemesters.DataSource = data;
    }

    private void AddSemester()
    {
        var src = dgvSemesters.DataSource as List<dynamic>;
        if (src == null)
        {
            LoadSemesters();
            src = dgvSemesters.DataSource as List<dynamic>;
        }
        var list = src!.ToList();
        list.Add(new { Id = 0, Code = "", Name = "" });
        dgvSemesters.DataSource = list;
    }

    private void DeleteSelectedSemester()
    {
        if (dgvSemesters.CurrentRow == null) return;
        var idObj = dgvSemesters.CurrentRow.Cells[nameof(Semester.Id)]?.Value;
        if (idObj is int id && id > 0)
        {
            using var db = DbFactory.CreateDbContext();
            var entity = db.Semesters.Find(id);
            if (entity != null)
            {
                db.Semesters.Remove(entity);
                db.SaveChanges();
            }
        }
        LoadSemesters();
    }

    private void SaveSemesters()
    {
        using var db = DbFactory.CreateDbContext();
        foreach (DataGridViewRow row in dgvSemesters.Rows)
        {
            if (row.IsNewRow) continue;
            var id = row.Cells[nameof(Semester.Id)].Value?.ToString();
            var code = row.Cells[nameof(Semester.Code)].Value?.ToString() ?? "";
            var name = row.Cells[nameof(Semester.Name)].Value?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name)) continue;

            if (int.TryParse(id, out var iid) && iid > 0)
            {
                var entity = db.Semesters.Find(iid);
                if (entity != null)
                {
                    entity.Code = code;
                    entity.Name = name;
                }
            }
            else
            {
                db.Semesters.Add(new Semester { Code = code, Name = name });
            }
        }
        db.SaveChanges();
        LoadSemesters();
    }

    private void LoadEnrollments()
    {
        using var db = DbFactory.CreateDbContext();
        var data = db.Enrollments.AsNoTracking().Select(s => new { s.Id, s.StudentId, s.CourseId, s.SemesterId, s.Grade }).ToList();
        dgvEnrollments.DataSource = data;
    }

    private void AddEnrollment()
    {
        var src = dgvEnrollments.DataSource as List<dynamic>;
        if (src == null)
        {
            LoadEnrollments();
            src = dgvEnrollments.DataSource as List<dynamic>;
        }
        var list = src!.ToList();
        list.Add(new { Id = 0, StudentId = 0, CourseId = 0, SemesterId = 0, Grade = (double?)null });
        dgvEnrollments.DataSource = list;
    }

    private void DeleteSelectedEnrollment()
    {
        if (dgvEnrollments.CurrentRow == null) return;
        var idObj = dgvEnrollments.CurrentRow.Cells[nameof(Enrollment.Id)]?.Value;
        if (idObj is int id && id > 0)
        {
            using var db = DbFactory.CreateDbContext();
            var entity = db.Enrollments.Find(id);
            if (entity != null)
            {
                db.Enrollments.Remove(entity);
                db.SaveChanges();
            }
        }
        LoadEnrollments();
    }

    private void SaveEnrollments()
    {
        using var db = DbFactory.CreateDbContext();
        foreach (DataGridViewRow row in dgvEnrollments.Rows)
        {
            if (row.IsNewRow) continue;
            var id = row.Cells[nameof(Enrollment.Id)].Value?.ToString();
            int.TryParse(row.Cells[nameof(Enrollment.StudentId)].Value?.ToString(), out var studentId);
            int.TryParse(row.Cells[nameof(Enrollment.CourseId)].Value?.ToString(), out var courseId);
            int.TryParse(row.Cells[nameof(Enrollment.SemesterId)].Value?.ToString(), out var semesterId);
            double? grade = null;
            if (double.TryParse(row.Cells[nameof(Enrollment.Grade)].Value?.ToString(), out var g)) grade = g;

            if (studentId <= 0 || courseId <= 0 || semesterId <= 0) continue;

            if (int.TryParse(id, out var iid) && iid > 0)
            {
                var entity = db.Enrollments.Find(iid);
                if (entity != null)
                {
                    entity.StudentId = studentId;
                    entity.CourseId = courseId;
                    entity.SemesterId = semesterId;
                    entity.Grade = grade;
                }
            }
            else
            {
                db.Enrollments.Add(new Enrollment
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    SemesterId = semesterId,
                    Grade = grade
                });
            }
        }
        db.SaveChanges();
        LoadEnrollments();
    }
}
