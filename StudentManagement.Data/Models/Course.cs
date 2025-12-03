using System.Collections.Generic;

namespace StudentManagement.Data.Models;

public class Course
{
    public int Id { get; set; }
    public string CourseCode { get; set; } = string.Empty; // Mã môn
    public string Name { get; set; } = string.Empty;       // Tên môn
    public int Credits { get; set; }                       // Số tín chỉ

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
