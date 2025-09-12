
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApp
{
    // ==== ENTITY CLASS ====
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Gpa { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Age: {Age} | GPA: {Gpa:F2}";
        }
    }

    // ==== MANAGER CLASS ====
    public class StudentManager
    {
        private readonly List<Student> students = new();

        public void Add(Student s) => students.Add(s);

        public bool Remove(string id)
        {
            var s = students.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                students.Remove(s);
                return true;
            }
            return false;
        }

        public bool Update(string id, string newName, int newAge, double newGpa)
        {
            var s = students.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                s.Name = newName;
                s.Age = newAge;
                s.Gpa = newGpa;
                return true;
            }
            return false;
        }

        public void DisplayAll()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }
            foreach (var s in students) Console.WriteLine(s);
        }

        public void FindByName(string name)
        {
            var found = students.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            foreach (var s in found) Console.WriteLine("Tìm thấy: " + s);
        }

        public void FindExcellent(double threshold = 8.0)
        {
            var found = students.Where(x => x.Gpa > threshold);
            foreach (var s in found) Console.WriteLine("Sinh viên giỏi: " + s);
        }

        public void SortByName()
        {
            students.Sort((a, b) => a.Name.CompareTo(b.Name));
            Console.WriteLine("Đã sắp xếp theo tên.");
        }

        public void SortByGpaDesc()
        {
            students.Sort((a, b) => b.Gpa.CompareTo(a.Gpa));
            Console.WriteLine("Đã sắp xếp theo GPA giảm dần.");
        }
    }

    // ==== MAIN PROGRAM ====
    public class Program
    {
        public static void Main()
        {
            var studentManager = new StudentManager();
            int menu = 0;

            while (menu != 99)
            {
                Console.WriteLine("============= MENU CHÍNH =============");
                Console.WriteLine("1. Quản lý Sinh viên");
                Console.WriteLine("99. Thoát");
                Console.Write("Nhập lựa chọn: ");
                int.TryParse(Console.ReadLine(), out menu);

                if (menu == 1)
                {
                    int smenu = 0;
                    while (smenu != 9)
                    {
                        Console.WriteLine("--- QUẢN LÝ SINH VIÊN ---");
                        Console.WriteLine("1. Thêm SV");
                        Console.WriteLine("2. Xóa SV");
                        Console.WriteLine("3. Cập nhật SV");
                        Console.WriteLine("4. Hiển thị tất cả SV");
                        Console.WriteLine("5. Tìm SV theo tên");
                        Console.WriteLine("6. Tìm SV GPA > 8");
                        Console.WriteLine("7. Sắp xếp theo tên");
                        Console.WriteLine("8. Sắp xếp theo GPA");
                        Console.WriteLine("9. Quay lại");
                        Console.Write("Chọn: ");
                        int.TryParse(Console.ReadLine(), out smenu);

                        switch (smenu)
                        {
                            case 1:
                                Console.Write("Nhập id: ");
                                string id = Console.ReadLine();
                                Console.Write("Nhập tên: ");
                                string name = Console.ReadLine();
                                Console.Write("Nhập tuổi: ");
                                int age = int.Parse(Console.ReadLine() ?? "0");
                                Console.Write("Nhập GPA: ");
                                double gpa = double.Parse(Console.ReadLine() ?? "0");
                                studentManager.Add(new Student { Id = id, Name = name, Age = age, Gpa = gpa });
                                break;

                            case 2:
                                Console.Write("Nhập id cần xóa: ");
                                if (studentManager.Remove(Console.ReadLine()))
                                    Console.WriteLine("Xóa thành công.");
                                else
                                    Console.WriteLine("Không tìm thấy.");
                                break;

                            case 3:
                                Console.Write("Nhập id cần cập nhật: ");
                                string uid = Console.ReadLine();
                                Console.Write("Tên mới: ");
                                string uname = Console.ReadLine();
                                Console.Write("Tuổi mới: ");
                                int uage = int.Parse(Console.ReadLine() ?? "0");
                                Console.Write("GPA mới: ");
                                double ugpa = double.Parse(Console.ReadLine() ?? "0");
                                if (studentManager.Update(uid, uname, uage, ugpa))
                                    Console.WriteLine("Cập nhật thành công.");
                                else
                                    Console.WriteLine("Không tìm thấy.");
                                break;

                            case 4:
                                studentManager.DisplayAll();
                                break;

                            case 5:
                                Console.Write("Nhập tên cần tìm: ");
                                studentManager.FindByName(Console.ReadLine());
                                break;

                            case 6:
                                studentManager.FindExcellent();
                                break;

                            case 7:
                                studentManager.SortByName();
                                break;

                            case 8:
                                studentManager.SortByGpaDesc();
                                break;
                        }
                    }
                }
            }
        }
    }
}

