namespace StudentManagement.WinForms.Enrollments;

partial class EnrollmentEditForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblStu;
    private System.Windows.Forms.Label lblCou;
    private System.Windows.Forms.Label lblSem;
    private System.Windows.Forms.Label lblGrade;
    private System.Windows.Forms.ComboBox cboStudent;
    private System.Windows.Forms.ComboBox cboCourse;
    private System.Windows.Forms.ComboBox cboSemester;
    private System.Windows.Forms.NumericUpDown numGrade;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblStu = new System.Windows.Forms.Label();
        this.lblCou = new System.Windows.Forms.Label();
        this.lblSem = new System.Windows.Forms.Label();
        this.lblGrade = new System.Windows.Forms.Label();
        this.cboStudent = new System.Windows.Forms.ComboBox();
        this.cboCourse = new System.Windows.Forms.ComboBox();
        this.cboSemester = new System.Windows.Forms.ComboBox();
        this.numGrade = new System.Windows.Forms.NumericUpDown();
        this.btnOk = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.numGrade)).BeginInit();
        this.SuspendLayout();

        this.lblStu.Text = "Sinh viên"; this.lblStu.Left = 16; this.lblStu.Top = 20; this.lblStu.AutoSize = true;
        this.lblCou.Text = "Môn học"; this.lblCou.Left = 16; this.lblCou.Top = 60; this.lblCou.AutoSize = true;
        this.lblSem.Text = "Học kỳ"; this.lblSem.Left = 16; this.lblSem.Top = 100; this.lblSem.AutoSize = true;
        this.lblGrade.Text = "Điểm"; this.lblGrade.Left = 16; this.lblGrade.Top = 140; this.lblGrade.AutoSize = true;

        this.cboStudent.Left = 100; this.cboStudent.Top = 16; this.cboStudent.Width = 280; this.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboCourse.Left = 100; this.cboCourse.Top = 56; this.cboCourse.Width = 280; this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboSemester.Left = 100; this.cboSemester.Top = 96; this.cboSemester.Width = 280; this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.numGrade.Left = 100; this.numGrade.Top = 136; this.numGrade.Width = 120; this.numGrade.Minimum = 0; this.numGrade.Maximum = 10; this.numGrade.DecimalPlaces = 2; this.numGrade.Increment = 0.25M;

        this.btnOk.Text = "OK"; this.btnOk.Left = 200; this.btnOk.Top = 190; this.btnOk.Width = 80;
        this.btnCancel.Text = "Hủy"; this.btnCancel.Left = 300; this.btnCancel.Top = 190; this.btnCancel.Width = 80;

        this.AcceptButton = this.btnOk; this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(400, 240);
        this.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblStu, this.lblCou, this.lblSem, this.lblGrade, this.cboStudent, this.cboCourse, this.cboSemester, this.numGrade, this.btnOk, this.btnCancel });
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false; this.MinimizeBox = false;
        this.Text = "Đăng ký";

        ((System.ComponentModel.ISupportInitialize)(this.numGrade)).EndInit();
        this.ResumeLayout(false);
    }
}
