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
    private System.Windows.Forms.Button btnCouEdit;
    private System.Windows.Forms.Button btnCouDelete;
    private System.Windows.Forms.Button btnCouSave;
    private System.Windows.Forms.Button btnSemAdd;
    private System.Windows.Forms.Button btnSemEdit;
    private System.Windows.Forms.Button btnSemDelete;
    private System.Windows.Forms.Button btnSemSave;
    private System.Windows.Forms.Button btnEnrAdd;
    private System.Windows.Forms.Button btnEnrEdit;
    private System.Windows.Forms.Button btnEnrDelete;
    private System.Windows.Forms.Button btnEnrSave;
    private System.Windows.Forms.Panel panelStu;
    private System.Windows.Forms.Panel panelCou;
    private System.Windows.Forms.Panel panelSem;
    private System.Windows.Forms.Panel panelEnr;

    private void InitializeComponent()
    {
        menuStrip1 = new MenuStrip();
        mnuBaoCao = new ToolStripMenuItem();
        mnuBC_KeHoachHocTap = new ToolStripMenuItem();
        mnuBC_DSSVTheoMonHK = new ToolStripMenuItem();
        tabMain = new TabControl();
        tabStudents = new TabPage();
        dgvStudents = new DataGridView();
        panelStu = new Panel();
        btnStuAdd = new Button();
        btnStuEdit = new Button();
        btnStuDelete = new Button();
        btnStuSave = new Button();
        tabCourses = new TabPage();
        dgvCourses = new DataGridView();
        panelCou = new Panel();
        btnCouAdd = new Button();
        btnCouEdit = new Button();
        btnCouDelete = new Button();
        btnCouSave = new Button();
        tabSemesters = new TabPage();
        dgvSemesters = new DataGridView();
        panelSem = new Panel();
        btnSemAdd = new Button();
        btnSemEdit = new Button();
        btnSemDelete = new Button();
        btnSemSave = new Button();
        tabEnrollments = new TabPage();
        dgvEnrollments = new DataGridView();
        panelEnr = new Panel();
        btnEnrAdd = new Button();
        btnEnrEdit = new Button();
        btnEnrDelete = new Button();
        btnEnrSave = new Button();
        menuStrip1.SuspendLayout();
        tabMain.SuspendLayout();
        tabStudents.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
        panelStu.SuspendLayout();
        tabCourses.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
        panelCou.SuspendLayout();
        tabSemesters.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvSemesters).BeginInit();
        panelSem.SuspendLayout();
        tabEnrollments.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEnrollments).BeginInit();
        panelEnr.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(20, 20);
        menuStrip1.Items.AddRange(new ToolStripItem[] { mnuBaoCao });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1000, 28);
        menuStrip1.TabIndex = 1;
        // 
        // mnuBaoCao
        // 
        mnuBaoCao.DropDownItems.AddRange(new ToolStripItem[] { mnuBC_KeHoachHocTap, mnuBC_DSSVTheoMonHK });
        mnuBaoCao.Name = "mnuBaoCao";
        mnuBaoCao.Size = new Size(77, 24);
        mnuBaoCao.Text = "Báo cáo";
        // 
        // mnuBC_KeHoachHocTap
        // 
        mnuBC_KeHoachHocTap.Name = "mnuBC_KeHoachHocTap";
        mnuBC_KeHoachHocTap.Size = new Size(336, 26);
        mnuBC_KeHoachHocTap.Text = "Kế hoạch học tập (theo Học kỳ)";
        // 
        // mnuBC_DSSVTheoMonHK
        // 
        mnuBC_DSSVTheoMonHK.Name = "mnuBC_DSSVTheoMonHK";
        mnuBC_DSSVTheoMonHK.Size = new Size(336, 26);
        mnuBC_DSSVTheoMonHK.Text = "Danh sách SV theo Môn học (Học kỳ)";
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabStudents);
        tabMain.Controls.Add(tabCourses);
        tabMain.Controls.Add(tabSemesters);
        tabMain.Controls.Add(tabEnrollments);
        tabMain.Dock = DockStyle.Fill;
        tabMain.Location = new Point(0, 28);
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new Size(1000, 572);
        tabMain.TabIndex = 0;
        // 
        // tabStudents
        // 
        tabStudents.Controls.Add(dgvStudents);
        tabStudents.Controls.Add(panelStu);
        tabStudents.Location = new Point(4, 29);
        tabStudents.Name = "tabStudents";
        tabStudents.Padding = new Padding(3);
        tabStudents.Size = new Size(992, 539);
        tabStudents.TabIndex = 0;
        tabStudents.Text = "Sinh viên";
        // 
        // dgvStudents
        // 
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvStudents.ColumnHeadersHeight = 29;
        dgvStudents.Dock = DockStyle.Fill;
        dgvStudents.Location = new Point(3, 3);
        dgvStudents.Name = "dgvStudents";
        dgvStudents.RowHeadersVisible = false;
        dgvStudents.RowHeadersWidth = 51;
        dgvStudents.Size = new Size(986, 485);
        dgvStudents.TabIndex = 0;
        // 
        // panelStu
        // 
        panelStu.Controls.Add(btnStuAdd);
        panelStu.Controls.Add(btnStuEdit);
        panelStu.Controls.Add(btnStuDelete);
        panelStu.Controls.Add(btnStuSave);
        panelStu.Dock = DockStyle.Bottom;
        panelStu.Location = new Point(3, 488);
        panelStu.Name = "panelStu";
        panelStu.Size = new Size(986, 48);
        panelStu.TabIndex = 1;
        // 
        // btnStuAdd
        // 
        btnStuAdd.Location = new Point(8, 10);
        btnStuAdd.Name = "btnStuAdd";
        btnStuAdd.Size = new Size(100, 23);
        btnStuAdd.TabIndex = 0;
        btnStuAdd.Text = "Thêm";
        // 
        // btnStuEdit
        // 
        btnStuEdit.Location = new Point(120, 10);
        btnStuEdit.Name = "btnStuEdit";
        btnStuEdit.Size = new Size(100, 23);
        btnStuEdit.TabIndex = 1;
        btnStuEdit.Text = "Sửa";
        // 
        // btnStuDelete
        // 
        btnStuDelete.Location = new Point(232, 10);
        btnStuDelete.Name = "btnStuDelete";
        btnStuDelete.Size = new Size(100, 23);
        btnStuDelete.TabIndex = 2;
        btnStuDelete.Text = "Xóa";
        // 
        // btnStuSave
        // 
        btnStuSave.Location = new Point(344, 10);
        btnStuSave.Name = "btnStuSave";
        btnStuSave.Size = new Size(100, 23);
        btnStuSave.TabIndex = 3;
        btnStuSave.Text = "Lưu";
        // 
        // tabCourses
        // 
        tabCourses.Controls.Add(dgvCourses);
        tabCourses.Controls.Add(panelCou);
        tabCourses.Location = new Point(4, 29);
        tabCourses.Name = "tabCourses";
        tabCourses.Padding = new Padding(3);
        tabCourses.Size = new Size(992, 567);
        tabCourses.TabIndex = 1;
        tabCourses.Text = "Môn học";
        // 
        // dgvCourses
        // 
        dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCourses.ColumnHeadersHeight = 29;
        dgvCourses.Dock = DockStyle.Fill;
        dgvCourses.Location = new Point(3, 3);
        dgvCourses.Name = "dgvCourses";
        dgvCourses.RowHeadersVisible = false;
        dgvCourses.RowHeadersWidth = 51;
        dgvCourses.Size = new Size(986, 513);
        dgvCourses.TabIndex = 0;
        // 
        // panelCou
        // 
        panelCou.Controls.Add(btnCouAdd);
        panelCou.Controls.Add(btnCouEdit);
        panelCou.Controls.Add(btnCouDelete);
        panelCou.Controls.Add(btnCouSave);
        panelCou.Dock = DockStyle.Bottom;
        panelCou.Location = new Point(3, 516);
        panelCou.Name = "panelCou";
        panelCou.Size = new Size(986, 48);
        panelCou.TabIndex = 1;
        // 
        // btnCouAdd
        // 
        btnCouAdd.Location = new Point(8, 10);
        btnCouAdd.Name = "btnCouAdd";
        btnCouAdd.Size = new Size(100, 23);
        btnCouAdd.TabIndex = 0;
        btnCouAdd.Text = "Thêm";
        // 
        // btnCouEdit
        // 
        btnCouEdit.Location = new Point(120, 10);
        btnCouEdit.Name = "btnCouEdit";
        btnCouEdit.Size = new Size(100, 23);
        btnCouEdit.TabIndex = 1;
        btnCouEdit.Text = "Sửa";
        // 
        // btnCouDelete
        // 
        btnCouDelete.Location = new Point(232, 10);
        btnCouDelete.Name = "btnCouDelete";
        btnCouDelete.Size = new Size(100, 23);
        btnCouDelete.TabIndex = 2;
        btnCouDelete.Text = "Xóa";
        // 
        // btnCouSave
        // 
        btnCouSave.Location = new Point(344, 10);
        btnCouSave.Name = "btnCouSave";
        btnCouSave.Size = new Size(100, 23);
        btnCouSave.TabIndex = 3;
        btnCouSave.Text = "Lưu";
        // 
        // tabSemesters
        // 
        tabSemesters.Controls.Add(dgvSemesters);
        tabSemesters.Controls.Add(panelSem);
        tabSemesters.Location = new Point(4, 29);
        tabSemesters.Name = "tabSemesters";
        tabSemesters.Padding = new Padding(3);
        tabSemesters.Size = new Size(992, 567);
        tabSemesters.TabIndex = 2;
        tabSemesters.Text = "Học kỳ";
        // 
        // dgvSemesters
        // 
        dgvSemesters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvSemesters.ColumnHeadersHeight = 29;
        dgvSemesters.Dock = DockStyle.Fill;
        dgvSemesters.Location = new Point(3, 3);
        dgvSemesters.Name = "dgvSemesters";
        dgvSemesters.RowHeadersVisible = false;
        dgvSemesters.RowHeadersWidth = 51;
        dgvSemesters.Size = new Size(986, 513);
        dgvSemesters.TabIndex = 0;
        // 
        // panelSem
        // 
        panelSem.Controls.Add(btnSemAdd);
        panelSem.Controls.Add(btnSemEdit);
        panelSem.Controls.Add(btnSemDelete);
        panelSem.Controls.Add(btnSemSave);
        panelSem.Dock = DockStyle.Bottom;
        panelSem.Location = new Point(3, 516);
        panelSem.Name = "panelSem";
        panelSem.Size = new Size(986, 48);
        panelSem.TabIndex = 1;
        // 
        // btnSemAdd
        // 
        btnSemAdd.Location = new Point(8, 10);
        btnSemAdd.Name = "btnSemAdd";
        btnSemAdd.Size = new Size(100, 23);
        btnSemAdd.TabIndex = 0;
        btnSemAdd.Text = "Thêm";
        // 
        // btnSemEdit
        // 
        btnSemEdit.Location = new Point(120, 10);
        btnSemEdit.Name = "btnSemEdit";
        btnSemEdit.Size = new Size(100, 23);
        btnSemEdit.TabIndex = 1;
        btnSemEdit.Text = "Sửa";
        // 
        // btnSemDelete
        // 
        btnSemDelete.Location = new Point(232, 10);
        btnSemDelete.Name = "btnSemDelete";
        btnSemDelete.Size = new Size(100, 23);
        btnSemDelete.TabIndex = 2;
        btnSemDelete.Text = "Xóa";
        // 
        // btnSemSave
        // 
        btnSemSave.Location = new Point(344, 10);
        btnSemSave.Name = "btnSemSave";
        btnSemSave.Size = new Size(100, 23);
        btnSemSave.TabIndex = 3;
        btnSemSave.Text = "Lưu";
        // 
        // tabEnrollments
        // 
        tabEnrollments.Controls.Add(dgvEnrollments);
        tabEnrollments.Controls.Add(panelEnr);
        tabEnrollments.Location = new Point(4, 29);
        tabEnrollments.Name = "tabEnrollments";
        tabEnrollments.Padding = new Padding(3);
        tabEnrollments.Size = new Size(992, 539);
        tabEnrollments.TabIndex = 3;
        tabEnrollments.Text = "Đăng ký";
        // 
        // dgvEnrollments
        // 
        dgvEnrollments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEnrollments.ColumnHeadersHeight = 29;
        dgvEnrollments.Dock = DockStyle.Fill;
        dgvEnrollments.Location = new Point(3, 3);
        dgvEnrollments.Name = "dgvEnrollments";
        dgvEnrollments.RowHeadersVisible = false;
        dgvEnrollments.RowHeadersWidth = 51;
        dgvEnrollments.Size = new Size(986, 485);
        dgvEnrollments.TabIndex = 0;
        // 
        // panelEnr
        // 
        panelEnr.Controls.Add(btnEnrAdd);
        panelEnr.Controls.Add(btnEnrEdit);
        panelEnr.Controls.Add(btnEnrDelete);
        panelEnr.Controls.Add(btnEnrSave);
        panelEnr.Dock = DockStyle.Bottom;
        panelEnr.Location = new Point(3, 488);
        panelEnr.Name = "panelEnr";
        panelEnr.Size = new Size(986, 48);
        panelEnr.TabIndex = 1;
        // 
        // btnEnrAdd
        // 
        btnEnrAdd.Location = new Point(8, 10);
        btnEnrAdd.Name = "btnEnrAdd";
        btnEnrAdd.Size = new Size(100, 23);
        btnEnrAdd.TabIndex = 0;
        btnEnrAdd.Text = "Thêm";
        // 
        // btnEnrEdit
        // 
        btnEnrEdit.Location = new Point(120, 10);
        btnEnrEdit.Name = "btnEnrEdit";
        btnEnrEdit.Size = new Size(100, 23);
        btnEnrEdit.TabIndex = 1;
        btnEnrEdit.Text = "Sửa";
        // 
        // btnEnrDelete
        // 
        btnEnrDelete.Location = new Point(232, 10);
        btnEnrDelete.Name = "btnEnrDelete";
        btnEnrDelete.Size = new Size(100, 23);
        btnEnrDelete.TabIndex = 2;
        btnEnrDelete.Text = "Xóa";
        // 
        // btnEnrSave
        // 
        btnEnrSave.Location = new Point(344, 10);
        btnEnrSave.Name = "btnEnrSave";
        btnEnrSave.Size = new Size(100, 23);
        btnEnrSave.TabIndex = 3;
        btnEnrSave.Text = "Lưu";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 600);
        Controls.Add(tabMain);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "Form1";
        Text = "Quản lý Sinh viên";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        tabMain.ResumeLayout(false);
        tabStudents.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
        panelStu.ResumeLayout(false);
        tabCourses.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
        panelCou.ResumeLayout(false);
        tabSemesters.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvSemesters).EndInit();
        panelSem.ResumeLayout(false);
        tabEnrollments.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvEnrollments).EndInit();
        panelEnr.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
