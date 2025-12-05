using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.WinForms.Data;

namespace StudentManagement.WinForms.Semesters;

public partial class SemesterEditForm : Form
{
    private readonly int? _id;
    public SemesterEditForm(int? id = null)
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
        var s = db.Semesters.Find(id);
        if (s == null) return;
        txtCode.Text = s.Code;
        txtName.Text = s.Name;
    }

    private void SaveAndClose()
    {
        var code = (txtCode.Text ?? "").Trim();
        var name = (txtName.Text ?? "").Trim();
        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Mã/Tên học kỳ bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        using var db = DbFactory.CreateDbContext();
        bool codeExists = (_id == null)
            ? db.Semesters.Any(x => x.Code == code)
            : db.Semesters.Any(x => x.Code == code && x.Id != _id);
        if (codeExists)
        {
            MessageBox.Show("Mã học kỳ đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (_id is int id && id > 0)
        {
            var s = db.Semesters.Find(id);
            if (s == null) { DialogResult = DialogResult.Cancel; Close(); return; }
            s.Code = code; s.Name = name;
        }
        else
        {
            db.Semesters.Add(new Semester { Code = code, Name = name });
        }
        db.SaveChanges();
        DialogResult = DialogResult.OK;
        Close();
    }
}
