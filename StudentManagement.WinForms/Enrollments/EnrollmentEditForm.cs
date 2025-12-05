using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.WinForms.Data;

namespace StudentManagement.WinForms.Enrollments;

public partial class EnrollmentEditForm : Form
{
    private readonly int? _id;
    public EnrollmentEditForm(int? id = null)
    {
        _id = id;
        InitializeComponent();
        btnOk.Click += (_, __) => SaveAndClose();
        btnCancel.Click += (_, __) => { DialogResult = DialogResult.Cancel; Close(); };
        Load += (_, __) => { LoadCombos(); LoadData(); };
    }

    private void LoadCombos()
    {
        using var db = DbFactory.CreateDbContext();
        var stus = db.Students.OrderBy(s => s.FullName).Select(s => new { s.Id, Display = s.StudentCode + " - " + s.FullName }).ToList();
        var cous = db.Courses.OrderBy(c => c.CourseCode).Select(c => new { c.Id, Display = c.CourseCode + " - " + c.Name }).ToList();
        var sems = db.Semesters.OrderBy(s => s.Code).Select(s => new { s.Id, Display = s.Code + " - " + s.Name }).ToList();
        cboStudent.DataSource = stus; cboStudent.DisplayMember = "Display"; cboStudent.ValueMember = "Id";
        cboCourse.DataSource = cous; cboCourse.DisplayMember = "Display"; cboCourse.ValueMember = "Id";
        cboSemester.DataSource = sems; cboSemester.DisplayMember = "Display"; cboSemester.ValueMember = "Id";
    }

    private void LoadData()
    {
        if (_id is not int id || id <= 0) return;
        using var db = DbFactory.CreateDbContext();
        var e = db.Enrollments.Find(id);
        if (e == null) return;
        cboStudent.SelectedValue = e.StudentId;
        cboCourse.SelectedValue = e.CourseId;
        cboSemester.SelectedValue = e.SemesterId;
        numGrade.Value = Math.Max(numGrade.Minimum, Math.Min(numGrade.Maximum, (decimal)(e.Grade ?? 0)));
    }

    private void SaveAndClose()
    {
        if (cboStudent.SelectedValue == null || cboCourse.SelectedValue == null || cboSemester.SelectedValue == null)
        {
            MessageBox.Show("Chọn Sinh viên, Môn học, Học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        int studentId = (int)cboStudent.SelectedValue;
        int courseId = (int)cboCourse.SelectedValue;
        int semesterId = (int)cboSemester.SelectedValue;
        decimal? grade = numGrade.Value;

        using var db = DbFactory.CreateDbContext();
        bool dup = (_id == null)
            ? db.Enrollments.Any(x => x.StudentId == studentId && x.CourseId == courseId && x.SemesterId == semesterId)
            : db.Enrollments.Any(x => x.StudentId == studentId && x.CourseId == courseId && x.SemesterId == semesterId && x.Id != _id);
        if (dup)
        {
            MessageBox.Show("Đăng ký đã tồn tại (SV + Môn + HK)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_id is int id && id > 0)
        {
            var e = db.Enrollments.Find(id);
            if (e == null) { DialogResult = DialogResult.Cancel; Close(); return; }
            e.StudentId = studentId; e.CourseId = courseId; e.SemesterId = semesterId; e.Grade = (double?)grade;
        }
        else
        {
            db.Enrollments.Add(new Enrollment { StudentId = studentId, CourseId = courseId, SemesterId = semesterId, Grade = (double?)grade });
        }
        db.SaveChanges();
        DialogResult = DialogResult.OK;
        Close();
    }
}
