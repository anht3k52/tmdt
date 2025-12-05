using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.WinForms.Data;

namespace StudentManagement.WinForms.Courses;

public partial class CourseEditForm : Form
{
    private readonly int? _id;
    public CourseEditForm(int? id = null)
    {
        _id = id;
        InitializeComponent();
        btnOk.Click += (_, __) => SaveAndClose();
        btnCancel.Click += (_, __) => { DialogResult = DialogResult.Cancel; Close(); };
        Load += (_, __) => LoadData();
    }

    private void LoadData()
    {
        if (_id is not int id || id <= 0) return;
        using var db = DbFactory.CreateDbContext();
        var c = db.Courses.Find(id);
        if (c == null) return;
        txtCode.Text = c.CourseCode;
        txtName.Text = c.Name;
        numCredits.Value = Math.Max(numCredits.Minimum, Math.Min(numCredits.Maximum, c.Credits));
    }

    private void SaveAndClose()
    {
        var code = (txtCode.Text ?? "").Trim();
        var name = (txtName.Text ?? "").Trim();
        int credits = (int)numCredits.Value;

        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Mã môn và Tên môn bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var db = DbFactory.CreateDbContext();
        bool codeExists = (_id == null)
            ? db.Courses.Any(x => x.CourseCode == code)
            : db.Courses.Any(x => x.CourseCode == code && x.Id != _id);
        if (codeExists)
        {
            MessageBox.Show("Mã môn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_id is int id && id > 0)
        {
            var c = db.Courses.Find(id);
            if (c == null) { DialogResult = DialogResult.Cancel; Close(); return; }
            c.CourseCode = code;
            c.Name = name;
            c.Credits = credits;
        }
        else
        {
            db.Courses.Add(new Course { CourseCode = code, Name = name, Credits = credits });
        }
        db.SaveChanges();
        DialogResult = DialogResult.OK;
        Close();
    }
}
