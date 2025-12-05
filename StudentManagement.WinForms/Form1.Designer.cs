namespace StudentManagement.WinForms;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
    private System.Windows.Forms.ToolStripMenuItem mnuBC_KeHoachHocTap;
    private System.Windows.Forms.ToolStripMenuItem mnuBC_DSSVTheoMonHK;
    private System.Windows.Forms.TabControl tabMain;
    private System.Windows.Forms.TabPage tabStudents;
    private System.Windows.Forms.TabPage tabCourses;
    private System.Windows.Forms.TabPage tabSemesters;
    private System.Windows.Forms.TabPage tabEnrollments;
    private System.Windows.Forms.DataGridView dgvStudents;
    private System.Windows.Forms.DataGridView dgvCourses;
    private System.Windows.Forms.DataGridView dgvSemesters;
    private System.Windows.Forms.DataGridView dgvEnrollments;
    private System.Windows.Forms.Button btnStuAdd;
    private System.Windows.Forms.Button btnStuDelete;
    private System.Windows.Forms.Button btnStuSave;
    private System.Windows.Forms.Button btnStuEdit;
    private System.Windows.Forms.Button btnCouAdd;
    private System.Windows.Forms.Button btnCouDelete;
    private System.Windows.Forms.Button btnCouSave;
    private System.Windows.Forms.Button btnSemAdd;
    private System.Windows.Forms.Button btnSemDelete;
    private System.Windows.Forms.Button btnSemSave;
    private System.Windows.Forms.Button btnEnrAdd;
    private System.Windows.Forms.Button btnEnrDelete;
    private System.Windows.Forms.Button btnEnrSave;
    private System.Windows.Forms.Panel panelStu;
    private System.Windows.Forms.Panel panelCou;
    private System.Windows.Forms.Panel panelSem;
    private System.Windows.Forms.Panel panelEnr;

    private void InitializeComponent()
    {
        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuBC_KeHoachHocTap = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuBC_DSSVTheoMonHK = new System.Windows.Forms.ToolStripMenuItem();
        this.tabMain = new System.Windows.Forms.TabControl();
        this.tabStudents = new System.Windows.Forms.TabPage();
        this.tabCourses = new System.Windows.Forms.TabPage();
        this.tabSemesters = new System.Windows.Forms.TabPage();
        this.tabEnrollments = new System.Windows.Forms.TabPage();
        this.dgvStudents = new System.Windows.Forms.DataGridView();
        this.dgvCourses = new System.Windows.Forms.DataGridView();
        this.dgvSemesters = new System.Windows.Forms.DataGridView();
        this.dgvEnrollments = new System.Windows.Forms.DataGridView();
        this.panelStu = new System.Windows.Forms.Panel();
        this.panelCou = new System.Windows.Forms.Panel();
        this.panelSem = new System.Windows.Forms.Panel();
        this.panelEnr = new System.Windows.Forms.Panel();
        this.btnStuAdd = new System.Windows.Forms.Button();
        this.btnStuDelete = new System.Windows.Forms.Button();
        this.btnStuSave = new System.Windows.Forms.Button();
        this.btnStuEdit = new System.Windows.Forms.Button();
        this.btnCouAdd = new System.Windows.Forms.Button();
        this.btnCouDelete = new System.Windows.Forms.Button();
        this.btnCouSave = new System.Windows.Forms.Button();
        this.btnSemAdd = new System.Windows.Forms.Button();
        this.btnSemDelete = new System.Windows.Forms.Button();
        this.btnSemSave = new System.Windows.Forms.Button();
        this.btnEnrAdd = new System.Windows.Forms.Button();
        this.btnEnrDelete = new System.Windows.Forms.Button();
        this.btnEnrSave = new System.Windows.Forms.Button();

        // menuStrip1
        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuBaoCao });
        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new System.Drawing.Size(1000, 24);

        // mnuBaoCao
        this.mnuBaoCao.Text = "Báo cáo";
        this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuBC_KeHoachHocTap, this.mnuBC_DSSVTheoMonHK });

        // mnuBC_KeHoachHocTap
        this.mnuBC_KeHoachHocTap.Text = "Kế hoạch học tập (theo Học kỳ)";
        
        // mnuBC_DSSVTheoMonHK
        this.mnuBC_DSSVTheoMonHK.Text = "Danh sách SV theo Môn học (Học kỳ)";

        this.SuspendLayout();

        // tabMain
        this.tabMain.Controls.Add(this.tabStudents);
        this.tabMain.Controls.Add(this.tabCourses);
        this.tabMain.Controls.Add(this.tabSemesters);
        this.tabMain.Controls.Add(this.tabEnrollments);
        this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabMain.Location = new System.Drawing.Point(0, 24);
        this.tabMain.Name = "tabMain";
        this.tabMain.SelectedIndex = 0;
        this.tabMain.Size = new System.Drawing.Size(1000, 600);

        // tabStudents
        this.tabStudents.Text = "Sinh viên";
        this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
        this.tabStudents.Controls.Add(this.dgvStudents);
        this.tabStudents.Controls.Add(this.panelStu);

        // dgvStudents
        this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvStudents.RowHeadersVisible = false;

        // panelStu
        this.panelStu.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panelStu.Height = 48;
        this.panelStu.Controls.Add(this.btnStuAdd);
        this.panelStu.Controls.Add(this.btnStuEdit);
        this.panelStu.Controls.Add(this.btnStuDelete);
        this.panelStu.Controls.Add(this.btnStuSave);

        // btnStuAdd
        this.btnStuAdd.Text = "Thêm";
        this.btnStuAdd.Left = 8; this.btnStuAdd.Top = 10; this.btnStuAdd.Width = 100;
        // btnStuEdit
        this.btnStuEdit.Text = "Sửa";
        this.btnStuEdit.Left = 120; this.btnStuEdit.Top = 10; this.btnStuEdit.Width = 100;
        // btnStuDelete
        this.btnStuDelete.Text = "Xóa";
        this.btnStuDelete.Left = 232; this.btnStuDelete.Top = 10; this.btnStuDelete.Width = 100;
        // btnStuSave
        this.btnStuSave.Text = "Lưu";
        this.btnStuSave.Left = 344; this.btnStuSave.Top = 10; this.btnStuSave.Width = 100;

        // tabCourses
        this.tabCourses.Text = "Môn học";
        this.tabCourses.Padding = new System.Windows.Forms.Padding(3);
        this.tabCourses.Controls.Add(this.dgvCourses);
        this.tabCourses.Controls.Add(this.panelCou);

        // dgvCourses
        this.dgvCourses.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCourses.RowHeadersVisible = false;

        // panelCou
        this.panelCou.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panelCou.Height = 48;
        this.panelCou.Controls.Add(this.btnCouAdd);
        this.panelCou.Controls.Add(this.btnCouDelete);
        this.panelCou.Controls.Add(this.btnCouSave);

        // btnCouAdd
        this.btnCouAdd.Text = "Thêm";
        this.btnCouAdd.Left = 8; this.btnCouAdd.Top = 10; this.btnCouAdd.Width = 100;
        // btnCouDelete
        this.btnCouDelete.Text = "Xóa";
        this.btnCouDelete.Left = 120; this.btnCouDelete.Top = 10; this.btnCouDelete.Width = 100;
        // btnCouSave
        this.btnCouSave.Text = "Lưu";
        this.btnCouSave.Left = 232; this.btnCouSave.Top = 10; this.btnCouSave.Width = 100;

        // tabSemesters
        this.tabSemesters.Text = "Học kỳ";
        this.tabSemesters.Padding = new System.Windows.Forms.Padding(3);
        this.tabSemesters.Controls.Add(this.dgvSemesters);
        this.tabSemesters.Controls.Add(this.panelSem);

        // dgvSemesters
        this.dgvSemesters.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvSemesters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvSemesters.RowHeadersVisible = false;

        // panelSem
        this.panelSem.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panelSem.Height = 48;
        this.panelSem.Controls.Add(this.btnSemAdd);
        this.panelSem.Controls.Add(this.btnSemDelete);
        this.panelSem.Controls.Add(this.btnSemSave);

        // btnSemAdd
        this.btnSemAdd.Text = "Thêm";
        this.btnSemAdd.Left = 8; this.btnSemAdd.Top = 10; this.btnSemAdd.Width = 100;
        // btnSemDelete
        this.btnSemDelete.Text = "Xóa";
        this.btnSemDelete.Left = 120; this.btnSemDelete.Top = 10; this.btnSemDelete.Width = 100;
        // btnSemSave
        this.btnSemSave.Text = "Lưu";
        this.btnSemSave.Left = 232; this.btnSemSave.Top = 10; this.btnSemSave.Width = 100;

        // tabEnrollments
        this.tabEnrollments.Text = "Đăng ký";
        this.tabEnrollments.Padding = new System.Windows.Forms.Padding(3);
        this.tabEnrollments.Controls.Add(this.dgvEnrollments);
        this.tabEnrollments.Controls.Add(this.panelEnr);

        // dgvEnrollments
        this.dgvEnrollments.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvEnrollments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvEnrollments.RowHeadersVisible = false;

        // panelEnr
        this.panelEnr.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panelEnr.Height = 48;
        this.panelEnr.Controls.Add(this.btnEnrAdd);
        this.panelEnr.Controls.Add(this.btnEnrDelete);
        this.panelEnr.Controls.Add(this.btnEnrSave);

        // btnEnrAdd
        this.btnEnrAdd.Text = "Thêm";
        this.btnEnrAdd.Left = 8; this.btnEnrAdd.Top = 10; this.btnEnrAdd.Width = 100;
        // btnEnrDelete
        this.btnEnrDelete.Text = "Xóa";
        this.btnEnrDelete.Left = 120; this.btnEnrDelete.Top = 10; this.btnEnrDelete.Width = 100;
        // btnEnrSave
        this.btnEnrSave.Text = "Lưu";
        this.btnEnrSave.Left = 232; this.btnEnrSave.Top = 10; this.btnEnrSave.Width = 100;

        // Form1
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1000, 600);
        this.Controls.Add(this.tabMain);
        this.Controls.Add(this.menuStrip1);
        this.MainMenuStrip = this.menuStrip1;
        this.Text = "Quản lý Sinh viên";

        this.ResumeLayout(false);
    }

    #endregion
}
