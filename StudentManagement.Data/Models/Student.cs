using System;
using System.Collections.Generic;

namespace StudentManagement.Data.Models;

public class Student
{
    public int Id { get; set; }
    public string StudentCode { get; set; } = string.Empty; // Mã SV
    public string FullName { get; set; } = string.Empty;    // Họ tên
    public DateTime? DateOfBirth { get; set; }
    public string? ClassName { get; set; }                  // Lớp

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
