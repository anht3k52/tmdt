using System.Collections.Generic;

namespace StudentManagement.Data.Models;

public class Semester
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty; // Ví dụ: 2025-1
    public string Name { get; set; } = string.Empty; // Ví dụ: Học kỳ 1 năm 2025

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
