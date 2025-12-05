namespace StudentManagement.WinForms.Courses;

partial class CourseEditForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblCode;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Label lblCredits;
    private System.Windows.Forms.TextBox txtCode;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.NumericUpDown numCredits;
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
        this.lblCredits = new System.Windows.Forms.Label();
        this.txtCode = new System.Windows.Forms.TextBox();
        this.txtName = new System.Windows.Forms.TextBox();
        this.numCredits = new System.Windows.Forms.NumericUpDown();
        this.btnOk = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.numCredits)).BeginInit();
        this.SuspendLayout();

        this.lblCode.Text = "Mã môn"; this.lblCode.Left = 16; this.lblCode.Top = 20; this.lblCode.AutoSize = true;
        this.lblName.Text = "Tên môn"; this.lblName.Left = 16; this.lblName.Top = 60; this.lblName.AutoSize = true;
        this.lblCredits.Text = "Số TC"; this.lblCredits.Left = 16; this.lblCredits.Top = 100; this.lblCredits.AutoSize = true;

        this.txtCode.Left = 100; this.txtCode.Top = 16; this.txtCode.Width = 260;
        this.txtName.Left = 100; this.txtName.Top = 56; this.txtName.Width = 260;
        this.numCredits.Left = 100; this.numCredits.Top = 96; this.numCredits.Width = 120; this.numCredits.Minimum = 0; this.numCredits.Maximum = 30;

        this.btnOk.Text = "OK"; this.btnOk.Left = 170; this.btnOk.Top = 150; this.btnOk.Width = 90;
        this.btnCancel.Text = "Hủy"; this.btnCancel.Left = 270; this.btnCancel.Top = 150; this.btnCancel.Width = 90;

        this.AcceptButton = this.btnOk; this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(380, 200);
        this.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblCode, this.lblName, this.lblCredits, this.txtCode, this.txtName, this.numCredits, this.btnOk, this.btnCancel });
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false; this.MinimizeBox = false;
        this.Text = "Môn học";

        ((System.ComponentModel.ISupportInitialize)(this.numCredits)).EndInit();
        this.ResumeLayout(false);
    }
}
