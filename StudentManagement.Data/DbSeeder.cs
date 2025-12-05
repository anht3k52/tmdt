using StudentManagement.Data.Models;

namespace StudentManagement.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        var rnd = new Random(12345);

        // Semesters
        if (!db.Semesters.Any())
        {
            var sems = new[]
            {
                new Semester { Code = "2024-1", Name = "Học kỳ 1 - 2024" },
                new Semester { Code = "2024-2", Name = "Học kỳ 2 - 2024" },
                new Semester { Code = "2025-1", Name = "Học kỳ 1 - 2025" },
                new Semester { Code = "2025-2", Name = "Học kỳ 2 - 2025" },
            };
            db.Semesters.AddRange(sems);
            db.SaveChanges();
        }

        // Courses
        if (!db.Courses.Any())
        {
            var courseNames = new (string code, string name, int credits)[]
            {
                ("CT101", "Lập trình C cơ bản", 3),
                ("CT102", "Cấu trúc dữ liệu & Giải thuật", 4),
                ("CT103", "Cơ sở dữ liệu", 3),
                ("CT104", "Mạng máy tính", 3),
                ("CT105", "Hệ điều hành", 3),
                ("CT106", "Lập trình hướng đối tượng", 3),
                ("CT107", "Lập trình Windows", 3),
                ("CT108", "Phát triển Web", 3),
                ("CT109", "Trí tuệ nhân tạo", 3),
                ("CT110", "Phân tích & Thiết kế Hệ thống", 3),
            };
            db.Courses.AddRange(courseNames.Select(c => new Course { CourseCode = c.code, Name = c.name, Credits = c.credits }));
            db.SaveChanges();
        }

        // Students
        if (!db.Students.Any())
        {
            var ho = new[] { "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Huỳnh", "Phan", "Vũ", "Võ", "Đặng", "Bùi", "Đỗ", "Hồ" };
            var dem = new[] { "Văn", "Thị", "Hồng", "Minh", "Anh", "Quốc", "Ngọc", "Thanh", "Tuấn", "Thùy", "Đức", "Thành" };
            var ten = new[] { "An", "Bình", "Châu", "Dũng", "Dung", "Giang", "Hà", "Hải", "Hân", "Hiếu", "Hùng", "Hương", "Khánh", "Lan", "Linh", "Loan", "Long", "Ly", "Mai", "Ngân", "Phong", "Phúc", "Quân", "Quyên", "Sơn", "Thảo", "Thiện", "Thu", "Trang", "Trí", "Trinh", "Tú", "Tùng", "Vy" };
            var classes = new[] { "CTK46A", "CTK46B", "CTK47A", "CTK47B", "CTK48A", "CTK48B" };

            var list = new List<Student>();
            int n = 50;
            for (int i = 1; i <= n; i++)
            {
                var code = $"SV{i:0000}";
                var fullname = $"{ho[rnd.Next(ho.Length)]} {dem[rnd.Next(dem.Length)]} {ten[rnd.Next(ten.Length)]}";
                var dob = RandomDate(rnd, new DateTime(1999, 1, 1), new DateTime(2006, 12, 31));
                var cls = classes[rnd.Next(classes.Length)];
                list.Add(new Student { StudentCode = code, FullName = fullname, DateOfBirth = dob, ClassName = cls });
            }
            db.Students.AddRange(list);
            db.SaveChanges();
        }

        // Enrollments
        if (!db.Enrollments.Any())
        {
            var studentIds = db.Students.Select(x => x.Id).ToList();
            var courseIds = db.Courses.Select(x => x.Id).ToList();
            var semesterIds = db.Semesters.Select(x => x.Id).ToList();

            var existing = new HashSet<(int s, int c, int se)>();
            var enrolls = new List<Enrollment>();
            foreach (var sId in studentIds)
            {
                int perStudent = rnd.Next(6, 13); // 6..12 enrollments mỗi SV
                for (int k = 0; k < perStudent; k++)
                {
                    int cId = courseIds[rnd.Next(courseIds.Count)];
                    int seId = semesterIds[rnd.Next(semesterIds.Count)];
                    var key = (sId, cId, seId);
                    if (existing.Contains(key)) { k--; continue; }
                    existing.Add(key);
                    double? grade = rnd.NextDouble() < 0.85 ? Math.Round(5 + rnd.NextDouble() * 5, 2) : null; // đa số có điểm 5..10, đôi khi null
                    enrolls.Add(new Enrollment { StudentId = sId, CourseId = cId, SemesterId = seId, Grade = grade });
                }
            }
            db.Enrollments.AddRange(enrolls);
            db.SaveChanges();
        }
    }

    private static DateTime RandomDate(Random rnd, DateTime from, DateTime to)
    {
        var range = (to - from).Days;
        return from.AddDays(rnd.Next(range)).Date;
    }
}
