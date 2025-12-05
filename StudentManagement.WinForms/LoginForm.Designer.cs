namespace StudentManagement.WinForms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblUser;
    private System.Windows.Forms.Label lblPass;
    private System.Windows.Forms.TextBox txtUser;
    private System.Windows.Forms.TextBox txtPass;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblUser = new System.Windows.Forms.Label();
        this.lblPass = new System.Windows.Forms.Label();
        this.txtUser = new System.Windows.Forms.TextBox();
        this.txtPass = new System.Windows.Forms.TextBox();
        this.btnLogin = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.SuspendLayout();

        // lblUser
        this.lblUser.AutoSize = true;
        this.lblUser.Text = "Tài khoản";
        this.lblUser.Left = 16; this.lblUser.Top = 18;

        // lblPass
        this.lblPass.AutoSize = true;
        this.lblPass.Text = "Mật khẩu";
        this.lblPass.Left = 16; this.lblPass.Top = 58;

        // txtUser
        this.txtUser.Left = 100; this.txtUser.Top = 15; this.txtUser.Width = 220;

        // txtPass
        this.txtPass.Left = 100; this.txtPass.Top = 55; this.txtPass.Width = 220; this.txtPass.PasswordChar = '•';

        // btnLogin
        this.btnLogin.Text = "Đăng nhập";
        this.btnLogin.Left = 100; this.btnLogin.Top = 100; this.btnLogin.Width = 100;

        // btnCancel
        this.btnCancel.Text = "Hủy";
        this.btnCancel.Left = 220; this.btnCancel.Top = 100; this.btnCancel.Width = 100;

        // Form
        this.AcceptButton = this.btnLogin;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(350, 150);
        this.Controls.Add(this.lblUser);
        this.Controls.Add(this.lblPass);
        this.Controls.Add(this.txtUser);
        this.Controls.Add(this.txtPass);
        this.Controls.Add(this.btnLogin);
        this.Controls.Add(this.btnCancel);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Đăng nhập";
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false; this.MinimizeBox = false;

        this.ResumeLayout(false);
    }
}
