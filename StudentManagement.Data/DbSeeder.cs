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
                // Thêm nhiều môn học
                ("CT111", "Toán rời rạc", 3),
                ("CT112", "Xác suất thống kê", 3),
                ("CT113", "Kiến trúc máy tính", 3),
                ("CT114", "Nhập môn an toàn thông tin", 3),
                ("CT115", "Nhập môn IoT", 3),
                ("CT116", "Công nghệ phần mềm nâng cao", 3),
                ("CT117", "Hệ quản trị CSDL nâng cao", 3),
                ("CT118", "Phát triển Web nâng cao", 3),
                ("CT119", "Phân tích dữ liệu", 3),
                ("CT120", "Học máy", 3),
                ("CT121", "Xử lý ảnh", 3),
                ("CT122", "Lập trình di động", 3),
                ("CT123", "Lập trình đa nền tảng", 3),
                ("CT124", "Hệ thống nhúng", 3),
                ("CT125", "Mạng nâng cao", 3),
                ("CT126", "Điện toán đám mây", 3),
                ("CT127", "Khai phá dữ liệu", 3),
                ("CT128", "Xử lý ngôn ngữ tự nhiên", 3),
                ("CT129", "Trí tuệ nhân tạo nâng cao", 3),
                ("CT130", "Phát triển game", 3),
                ("CT131", "Đảm bảo chất lượng phần mềm", 3),
                ("CT132", "Quản lý dự án phần mềm", 3),
                ("CT133", "Công nghệ Blockchain", 3),
                ("CT134", "Kỹ thuật ảo hóa", 3),
                ("CT135", "Phân tán và song song", 3),
                ("CT136", "Kỹ thuật lập trình nâng cao", 3),
                ("CT137", "Kỹ thuật biên dịch", 3),
                ("CT138", "Thực tế ảo", 3),
                ("CT139", "Đồ án 1", 3),
                ("CT140", "Đồ án 2", 3),
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
