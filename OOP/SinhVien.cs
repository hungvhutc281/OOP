
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    public class SinhVien
    {
        private int id;
        private string name;
        private string sex;
        private int age;
        private float math;
        private float physics;
        private float chemistry;
        private float gPA;
        private string hl;

        private static int _IdNext = 1;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Age { get => age; set => age = value; }
        public float Math { get => math; set => math = value; }
        public float Physics { get => physics; set => physics = value; }
        public float Chemistry { get => chemistry; set => chemistry = value; }
        public float GPA { get => gPA; set => gPA = value; }
        public string Hl { get => hl; set => hl = value; }

        public SinhVien()
        {
            Id = _IdNext++;
        }

        public void GetGPA()
        {
            GPA = (Math + Physics + Chemistry) / 3;
            Hl = GetHl(GPA);
        }

        private string GetHl(float gpa)
        {
            if (gpa >= 8) return "Gioi";
            if (gpa >= 6.5) return "Kha";
            if (gpa >= 5) return "Trung Binh";
            return "Yeu";
        }
    }

    class Program
    {
        static List<SinhVien> students = new List<SinhVien>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Update by id");
                Console.WriteLine("3. Remove by ID");
                Console.WriteLine("4. Seach Name");
                Console.WriteLine("5. Sort GPA");
                Console.WriteLine("6. Sort name");
                Console.WriteLine("7. Sort  ID");
                Console.WriteLine("8. List");
                Console.WriteLine("9. Close");
                Console.Write("Please Choice ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddSt();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                       Remove();
                        break;
                    case 4:
                        Seachname();
                        break;
                    case 5:
                       Sort_GPA();
                        break;
                    case 6:
                        Sort_name();
                        break;
                    case 7:
                        Sort_Id();
                        break;
                    case 8:
                        Display_List();
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("You again");
                        break;
                }
            }
        }

        static void AddSt()
        {
            var student = new SinhVien();
            Console.Write("Input name: ");
            student.Name = Console.ReadLine();
            Console.Write("Input Sex: ");
            student.Sex = Console.ReadLine();
            Console.Write("Input Age: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Iput Math: ");
            student.Math = float.Parse(Console.ReadLine());
            Console.Write("Input Phisical: ");
            student.Physics = float.Parse(Console.ReadLine());
            Console.Write("Input Chemistry: ");
            student.Chemistry = float.Parse(Console.ReadLine());
            student.GetGPA();
            students.Add(student);
            Console.WriteLine("Add Corect");
        }

        static void Update()
        {
            Console.Write("Input Id");
            int id = int.Parse(Console.ReadLine());
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Input name : ");
                student.Name = Console.ReadLine();
                Console.Write("Input Sex new: ");
                student.Sex = Console.ReadLine();
                Console.Write("Input Age new: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Input Math New ");
                student.Math = float.Parse(Console.ReadLine());
                Console.Write("Input Phisical new ");
                student.Physics = float.Parse(Console.ReadLine());
                Console.Write("Input Chemmistry: ");
                student.Chemistry = float.Parse(Console.ReadLine());
                student.GetGPA();
                Console.WriteLine("Update Corect");
            }
            else
            {
                Console.WriteLine("Don ' t Seach");
            }
        }

        static void Remove()
        {
            Console.Write("Input Id remove : ");
            int id = int.Parse(Console.ReadLine());


            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Remove Success");
            }
            else
            {
                Console.WriteLine("Don 't seach");
            }
        }

        static void Seachname()
        {

        }

        static void Sort_GPA()
        {
            students = students.OrderByDescending(s => s.GPA).ToList();
            Console.WriteLine("sort by GPA success");
        }

        static void Sort_name()
        {
            students = students.OrderBy(s => s.Name).ToList();
            Console.WriteLine("sort bt name sucess");
        }

        static void Sort_Id()
        {
            students = students.OrderBy(s => s.Id).ToList();
            Console.WriteLine("sort by id sucesss");
        }

        static void Display_List()
        {
            Display_List(students);
        }

        static void Display_List(List<SinhVien> studentList)
        {
            Console.WriteLine("List");
            foreach (var student in studentList)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Sex {student.Sex}, Age: {student.Age}, " +
                                  $"math: {student.Math}, Ly: {student.Physics}, Hoa: {student.Chemistry}, " +
                                  $"GPA: {student.GPA:F2}, Hl: {student.Hl}");
            }
        }
    }
}
