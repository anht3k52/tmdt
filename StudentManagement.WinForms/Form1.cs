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

        // Ensure auto-generate columns so bound DTOs appear without manual column definitions
        dgvStudents.AutoGenerateColumns = true;
        dgvCourses.AutoGenerateColumns = true;
        dgvSemesters.AutoGenerateColumns = true;
        dgvEnrollments.AutoGenerateColumns = true;

        this.Shown += (_, __) =>
        {
            if (!Program.Authenticated)
            {
                using var login = new LoginForm() { TopMost = true };
                if (login.ShowDialog(this) != DialogResult.OK)
                {
                    Close();
                    return;
                }
                Program.Authenticated = true;
            }

            try { LoadStudents(); } catch (Exception ex) { MessageBox.Show($"Lỗi tải Sinh viên: {ex.Message}"); }
            try { LoadCourses(); } catch (Exception ex) { MessageBox.Show($"Lỗi tải Môn học: {ex.Message}"); }
            try { LoadSemesters(); } catch (Exception ex) { MessageBox.Show($"Lỗi tải Học kỳ: {ex.Message}"); }
            try { LoadEnrollments(); } catch (Exception ex) { MessageBox.Show($"Lỗi tải Đăng ký: {ex.Message}"); }
        };

        btnStuAdd.Click += (_, __) => AddStudent();
        btnStuEdit.Click += (_, __) => EditSelectedStudent();
        btnStuDelete.Click += (_, __) => DeleteSelectedStudent();

        btnCouAdd.Click += (_, __) => AddCourse();
        btnCouSave.Click += (_, __) => SaveCourses();
        // wire edit for courses
        if (btnCouEdit != null) btnCouEdit.Click += (_, __) => EditSelectedCourse();
        btnCouDelete.Click += (_, __) => DeleteSelectedCourse();

        btnSemAdd.Click += (_, __) => AddSemester();
        if (btnSemEdit != null) btnSemEdit.Click += (_, __) => EditSelectedSemester();
        btnSemDelete.Click += (_, __) => DeleteSelectedSemester();
        btnSemSave.Click += (_, __) => SaveSemesters();

        btnEnrAdd.Click += (_, __) => AddEnrollment();
        if (btnEnrEdit != null) btnEnrEdit.Click += (_, __) => EditSelectedEnrollment();
        btnEnrDelete.Click += (_, __) => DeleteSelectedEnrollment();
        btnEnrSave.Click += (_, __) => SaveEnrollments();

        mnuBC_KeHoachHocTap.Click += (_, __) =>
        {
            using var f = new Reports.StudyPlanReportForm();
            f.ShowDialog(this);
        };
        mnuBC_DSSVTheoMonHK.Click += (_, __) =>
        {
            using var f = new Reports.StudentsByCourseSemesterForm();
            f.ShowDialog(this);
        };
        mnuBC_BaoCaoDangKy.Click += (_, __) =>
        {
            using var f = new Reports.EnrollmentReportForm();
            f.ShowDialog(this);
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
        using var f = new Students.StudentEditForm();
        if (f.ShowDialog(this) == DialogResult.OK) LoadStudents();
    }

    private void EditSelectedStudent()
    {
        if (dgvStudents.CurrentRow == null) return;
        var idObj = dgvStudents.CurrentRow.Cells[nameof(Student.Id)]?.Value;
        if (idObj is int id && id > 0)
        {
            using var f = new Students.StudentEditForm(id);
            if (f.ShowDialog(this) == DialogResult.OK) LoadStudents();
        }
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
        // No-op for Students since add/edit handled by dialog
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
        using var f = new Courses.CourseEditForm();
        if (f.ShowDialog(this) == DialogResult.OK) LoadCourses();
    }

    private void EditSelectedCourse()
    {
        if (dgvCourses.CurrentRow == null) return;
        var idObj = dgvCourses.CurrentRow.Cells[nameof(Course.Id)]?.Value;
        if (idObj is int id && id > 0)
        {
            using var f = new Courses.CourseEditForm(id);
            if (f.ShowDialog(this) == DialogResult.OK) LoadCourses();
        }
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
        // No-op: add/edit handled by dialog forms
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
        using var f = new Semesters.SemesterEditForm();
        if (f.ShowDialog(this) == DialogResult.OK) LoadSemesters();
    }

    private void EditSelectedSemester()
    {
        if (dgvSemesters.CurrentRow == null) return;
        var idObj = dgvSemesters.CurrentRow.Cells[nameof(Semester.Id)]?.Value;
        if (idObj is int id && id > 0)
        {
            using var f = new Semesters.SemesterEditForm(id);
            if (f.ShowDialog(this) == DialogResult.OK) LoadSemesters();
        }
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
        // No-op: add/edit handled by dialog forms
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
        using var f = new Enrollments.EnrollmentEditForm();
        if (f.ShowDialog(this) == DialogResult.OK) LoadEnrollments();
    }

    private void EditSelectedEnrollment()
    {
        if (dgvEnrollments.CurrentRow == null) return;
        var idObj = dgvEnrollments.CurrentRow.Cells[nameof(Enrollment.Id)]?.Value;
        if (idObj is int id && id > 0)
        {
            using var f = new Enrollments.EnrollmentEditForm(id);
            if (f.ShowDialog(this) == DialogResult.OK) LoadEnrollments();
        }
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
        // No-op: add/edit handled by dialog forms
        LoadEnrollments();
    }
}
