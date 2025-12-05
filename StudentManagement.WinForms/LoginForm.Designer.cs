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
        lblUser = new Label();
        lblPass = new Label();
        txtUser = new TextBox();
        txtPass = new TextBox();
        btnLogin = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblUser
        // 
        lblUser.AutoSize = true;
        lblUser.Location = new Point(16, 18);
        lblUser.Name = "lblUser";
        lblUser.Size = new Size(71, 20);
        lblUser.TabIndex = 0;
        lblUser.Text = "Tài khoản";
        // 
        // lblPass
        // 
        lblPass.AutoSize = true;
        lblPass.Location = new Point(16, 58);
        lblPass.Name = "lblPass";
        lblPass.Size = new Size(70, 20);
        lblPass.TabIndex = 1;
        lblPass.Text = "Mật khẩu";
        // 
        // txtUser
        // 
        txtUser.Location = new Point(100, 15);
        txtUser.Name = "txtUser";
        txtUser.Size = new Size(220, 27);
        txtUser.TabIndex = 2;
        // 
        // txtPass
        // 
        txtPass.Location = new Point(100, 55);
        txtPass.Name = "txtPass";
        txtPass.PasswordChar = '•';
        txtPass.Size = new Size(220, 27);
        txtPass.TabIndex = 3;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(100, 100);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(100, 38);
        btnLogin.TabIndex = 4;
        btnLogin.Text = "Đăng nhập";
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(220, 100);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(100, 38);
        btnCancel.TabIndex = 5;
        btnCancel.Text = "Hủy";
        // 
        // LoginForm
        // 
        AcceptButton = btnLogin;
        CancelButton = btnCancel;
        ClientSize = new Size(350, 150);
        Controls.Add(lblUser);
        Controls.Add(lblPass);
        Controls.Add(txtUser);
        Controls.Add(txtPass);
        Controls.Add(btnLogin);
        Controls.Add(btnCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Đăng nhập";
        ResumeLayout(false);
        PerformLayout();
    }
}
