namespace StudentManagement.WinForms.Students;

partial class StudentEditForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblCode;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Label lblDob;
    private System.Windows.Forms.Label lblClass;
    private System.Windows.Forms.TextBox txtCode;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.DateTimePicker dtDob;
    private System.Windows.Forms.TextBox txtClass;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblCode = new System.Windows.Forms.Label();
        this.lblName = new System.Windows.Forms.Label();
        this.lblDob = new System.Windows.Forms.Label();
        this.lblClass = new System.Windows.Forms.Label();
        this.txtCode = new System.Windows.Forms.TextBox();
        this.txtName = new System.Windows.Forms.TextBox();
        this.dtDob = new System.Windows.Forms.DateTimePicker();
        this.txtClass = new System.Windows.Forms.TextBox();
        this.btnOk = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.SuspendLayout();

        this.lblCode.Text = "Mã SV"; this.lblCode.Left = 16; this.lblCode.Top = 20; this.lblCode.AutoSize = true;
        this.lblName.Text = "Họ tên"; this.lblName.Left = 16; this.lblName.Top = 60; this.lblName.AutoSize = true;
        this.lblDob.Text = "Ngày sinh"; this.lblDob.Left = 16; this.lblDob.Top = 100; this.lblDob.AutoSize = true;
        this.lblClass.Text = "Lớp"; this.lblClass.Left = 16; this.lblClass.Top = 140; this.lblClass.AutoSize = true;

        this.txtCode.Left = 100; this.txtCode.Top = 16; this.txtCode.Width = 260;
        this.txtName.Left = 100; this.txtName.Top = 56; this.txtName.Width = 260;
        this.dtDob.Left = 100; this.dtDob.Top = 96; this.dtDob.Width = 260; this.dtDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom; this.dtDob.CustomFormat = "dd/MM/yyyy"; this.dtDob.ShowCheckBox = true;
        this.txtClass.Left = 100; this.txtClass.Top = 136; this.txtClass.Width = 260;

        this.btnOk.Text = "OK"; this.btnOk.Left = 160; this.btnOk.Top = 190; this.btnOk.Width = 90;
        this.btnCancel.Text = "Hủy"; this.btnCancel.Left = 270; this.btnCancel.Top = 190; this.btnCancel.Width = 90;

        this.AcceptButton = this.btnOk;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(380, 240);
        this.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblCode, this.lblName, this.lblDob, this.lblClass, this.txtCode, this.txtName, this.dtDob, this.txtClass, this.btnOk, this.btnCancel });
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false; this.MinimizeBox = false;
        this.Text = "Sinh viên";

        this.ResumeLayout(false);
    }
}
