namespace StudentManagement.Data.Models;

public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public int SemesterId { get; set; }
    public Semester Semester { get; set; } = null!;

    public double? Grade { get; set; } // Điểm (tuỳ chọn)
}
