using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.WinForms.Data;

namespace StudentManagement.WinForms.Students;

public partial class StudentEditForm : Form
{
    private readonly int? _id;
    public StudentEditForm(int? id = null)
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
        var sv = db.Students.Find(id);
        if (sv == null) return;
        txtCode.Text = sv.StudentCode;
        txtName.Text = sv.FullName;
        if (sv.DateOfBirth.HasValue)
        {
            dtDob.Checked = true;
            dtDob.Value = sv.DateOfBirth.Value;
        }
        else dtDob.Checked = false;
        txtClass.Text = sv.ClassName;
    }

    private void SaveAndClose()
    {
        var code = (txtCode.Text ?? "").Trim();
        var name = (txtName.Text ?? "").Trim();
        DateTime? dob = dtDob.Checked ? dtDob.Value.Date : null;
        var cls = (txtClass.Text ?? "").Trim();

        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Mã SV và Họ tên bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var db = DbFactory.CreateDbContext();

        // Unique StudentCode
        bool codeExists = (_id == null)
            ? db.Students.Any(x => x.StudentCode == code)
            : db.Students.Any(x => x.StudentCode == code && x.Id != _id);
        if (codeExists)
        {
            MessageBox.Show("Mã SV đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_id is int id && id > 0)
        {
            var sv = db.Students.Find(id);
            if (sv == null) { DialogResult = DialogResult.Cancel; Close(); return; }
            sv.StudentCode = code;
            sv.FullName = name;
            sv.DateOfBirth = dob;
            sv.ClassName = cls;
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

        db.SaveChanges();
        DialogResult = DialogResult.OK;
        Close();
    }
}
