using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.WinForms.Data;
using StudentManagement.WinForms.Reports;
using Microsoft.VisualBasic; // For Interaction.InputBox
using StudentManagement.WinForms.Models;
using System.ComponentModel;

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
        var data = db.Students.AsNoTracking()
            .Select(s => new StudentRow
            {
                Id = s.Id,
                StudentCode = s.StudentCode,
                FullName = s.FullName,
                DateOfBirth = s.DateOfBirth,
                ClassName = s.ClassName
            })
            .ToList();
        dgvStudents.DataSource = new BindingList<StudentRow>(data);
    }

    private void AddStudent()
    {
        var src = dgvStudents.DataSource as BindingList<StudentRow>;
        if (src == null)
        {
            LoadStudents();
            src = dgvStudents.DataSource as BindingList<StudentRow>;
        }
        src!.Add(new StudentRow { Id = 0, StudentCode = string.Empty, FullName = string.Empty, DateOfBirth = null, ClassName = string.Empty });
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
        var data = db.Courses.AsNoTracking()
            .Select(s => new CourseRow { Id = s.Id, CourseCode = s.CourseCode, Name = s.Name, Credits = s.Credits })
            .ToList();
        dgvCourses.DataSource = new BindingList<CourseRow>(data);
    }

    private void AddCourse()
    {
        var src = dgvCourses.DataSource as BindingList<CourseRow>;
        if (src == null)
        {
            LoadCourses();
            src = dgvCourses.DataSource as BindingList<CourseRow>;
        }
        src!.Add(new CourseRow { Id = 0, CourseCode = string.Empty, Name = string.Empty, Credits = 0 });
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
        var data = db.Semesters.AsNoTracking()
            .Select(s => new SemesterRow { Id = s.Id, Code = s.Code, Name = s.Name })
            .ToList();
        dgvSemesters.DataSource = new BindingList<SemesterRow>(data);
    }

    private void AddSemester()
    {
        var src = dgvSemesters.DataSource as BindingList<SemesterRow>;
        if (src == null)
        {
            LoadSemesters();
            src = dgvSemesters.DataSource as BindingList<SemesterRow>;
        }
        src!.Add(new SemesterRow { Id = 0, Code = string.Empty, Name = string.Empty });
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
        var data = db.Enrollments.AsNoTracking()
            .Select(s => new EnrollmentRow { Id = s.Id, StudentId = s.StudentId, CourseId = s.CourseId, SemesterId = s.SemesterId, Grade = s.Grade })
            .ToList();
        dgvEnrollments.DataSource = new BindingList<EnrollmentRow>(data);
    }

    private void AddEnrollment()
    {
        var src = dgvEnrollments.DataSource as BindingList<EnrollmentRow>;
        if (src == null)
        {
            LoadEnrollments();
            src = dgvEnrollments.DataSource as BindingList<EnrollmentRow>;
        }
        src!.Add(new EnrollmentRow { Id = 0, StudentId = 0, CourseId = 0, SemesterId = 0, Grade = null });
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
