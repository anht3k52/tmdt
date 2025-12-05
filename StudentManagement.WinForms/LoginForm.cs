namespace StudentManagement.WinForms;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();

        btnLogin.Click += (_, __) => DoLogin();
        btnCancel.Click += (_, __) => { this.DialogResult = DialogResult.Cancel; Close(); };
    }

    private void DoLogin()
    {
        var user = txtUser.Text?.Trim() ?? string.Empty;
        var pass = txtPass.Text ?? string.Empty;

        if (string.Equals(user, "admin", StringComparison.OrdinalIgnoreCase)
            && pass == "admin")
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPass.SelectAll();
            txtPass.Focus();
        }
    }
}
