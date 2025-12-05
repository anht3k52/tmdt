namespace StudentManagement.WinForms.Reports;

partial class EnrollmentReportForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ComboBox cmbSemester;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.DataGridView dgv;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        cmbSemester = new ComboBox();
        btnRefresh = new Button();
        dgv = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        SuspendLayout();
        // 
        // cmbSemester
        // 
        cmbSemester.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSemester.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        cmbSemester.Location = new Point(12, 12);
        cmbSemester.Name = "cmbSemester";
        cmbSemester.Size = new Size(260, 28);
        // 
        // btnRefresh
        // 
        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        btnRefresh.Location = new Point(290, 12);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(120, 28);
        btnRefresh.Text = "Xem báo cáo";
        // 
        // dgv
        // 
        dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgv.Location = new Point(12, 52);
        dgv.Name = "dgv";
        dgv.RowHeadersVisible = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.Size = new Size(760, 396);
        // 
        // EnrollmentReportForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 461);
        Controls.Add(dgv);
        Controls.Add(btnRefresh);
        Controls.Add(cmbSemester);
        Name = "EnrollmentReportForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Báo cáo đăng ký";
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        ResumeLayout(false);
    }
}
