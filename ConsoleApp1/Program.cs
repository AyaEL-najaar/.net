using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Engine
    {
        public string Model { get; set; }
        public void Start() => Console.WriteLine("Engine started now");
    }

    class Car
    {
        public string Make { get; set; }
        private Engine engine = new Engine();
        public void Start() => engine.Start();
    }
    enum CourseLevel { Beginner, Intermediate, Advanced }
    class Course
    {
        public string Title { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public Instructor Instructor { get; set; }
        public CourseLevel Level { get; set; }
        public Course(string title)
        {
            Title = title;
        }
    }
    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
    class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
    class Company
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
    }
    static class IdGenerator
    {
        private static int currentId = 0;
        public static int GetNextId() => ++currentId;
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Id = IdGenerator.GetNextId();
            Name = name;
            Age = age;
        }
        public virtual void Introduce() => Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
    }
    class Grade
    {
        public int Value { get; set; }
        public Grade(int value)
        {
            Value = value;
        }
        public static Grade operator +(Grade g1, Grade g2) => new Grade(g1.Value + g2.Value);
        public static bool operator ==(Grade g1, Grade g2) => g1.Value == g2.Value;
        public static bool operator !=(Grade g1, Grade g2) => g1.Value != g2.Value;

    }
    class Student : Person
    {
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public Student(string name, int age) : base(name, age) { }
        public void RegisterCourse(Course course)
        {
            Courses.Add(course);
            course.Students.Add(this);
            switch (course.Level)
            {
                case CourseLevel.Beginner:
                    Console.WriteLine($"{Name} registered in {course.Title}: Good luck starting out!");
                    break;
                case CourseLevel.Intermediate:
                    Console.WriteLine($"{Name} registered in {course.Title}: Keep going!");
                    break;
                case CourseLevel.Advanced:
                    Console.WriteLine($"{Name} registered in {course.Title}: This will be challenging!");
                    break;
            }
        }
        public void AddGrade(int value)
        {
            Grades.Add(new Grade(value));
        }

        public Grade GetTotalGrade()
        {
            Grade total = new Grade(0);
            foreach (var g in Grades)
            {
                total += g;
            }
            return total;
        }
        public override void Introduce()
        {
            string courseTitles = Courses.Count > 0 ? string.Join(", ", Courses.ConvertAll(c => c.Title)) : "no courses";
            Console.WriteLine($"Hi,My ID:{Id}, I am {Name}, a student in {courseTitles}  , Total grade = {GetTotalGrade().Value} .");
        }
    }
    class Instructor : Person
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        public Instructor(string name, int age) : base(name, age) { }
        public void TeachCourse(Course course)
        {
            course.Instructor = this;
            Courses.Add(course);
        }
        public override void Introduce()
        {
            string courseTitles = Courses.Count > 0 ? string.Join(", ", Courses.ConvertAll(c => c.Title)): "no courses";
            Console.WriteLine($"Hi,My ID:{Id}, I am {Name}, an instractor in {courseTitles} .\n");
        }
    }

    abstract class Shape
    {
        public abstract double Area();
    }

    // Interface
    interface IDrawable
    {
        void Draw();
    }

    // Circle class
    class Circle : Shape, IDrawable
    {
        public double Radius { get; set; }

        public Circle(double r)
        {
            Radius = r;
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Circle (o)");
        }
    }

    // Rectangle class
    class Rectangle : Shape, IDrawable
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public override double Area()
        {
            return Width * Height;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Rectangle [ ]");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Mona", 20);
            Student s2 = new Student("Ali", 22);
            Student s3 = new Student("Sara", 21);
            Student s4 = new Student("Omar", 23);
            Instructor inst1 = new Instructor("Dr. Smith", 45);
            Instructor inst2 = new Instructor("Prof. Johnson", 50);
            Instructor inst3 = new Instructor("Ms. Lee", 35);
            s1.AddGrade(85);
            s1.AddGrade(90);
            s2.AddGrade(78);
            s3.AddGrade(92);
            s1.AddGrade(88);
            s4.AddGrade(76);
            s4.AddGrade(80);
            Course c1 = new Course("C# Basics");
            Course c2 = new Course("Databases");
            Course c3 = new Course("Web Development");
            Course c4 = new Course("Advanced C#");
            Course c5 = new Course("Data Science");
            c1.Level = CourseLevel.Beginner;    
            c2.Level = CourseLevel.Intermediate;
            c3.Level = CourseLevel.Beginner;
            c4.Level = CourseLevel.Advanced;
            c5.Level = CourseLevel.Advanced;

            s1.RegisterCourse(c1);
            s1.RegisterCourse(c4);
            s2.RegisterCourse(c2);
            s3.RegisterCourse(c3);
            s4.RegisterCourse(c5);
            s4.RegisterCourse(c1);

            inst1.TeachCourse(c1);
            inst1.TeachCourse(c2);
            inst3.TeachCourse(c4);
            inst2.TeachCourse(c5);
            inst2.TeachCourse(c3);
          


            s1.Introduce();
            s2.Introduce();
            s3.Introduce();
            s4.Introduce();

            inst1.Introduce();
            inst2.Introduce();
            inst3.Introduce();

            Company company = new Company { Name = "TechCorp" };
            Department devDept = new Department { Name = "Development" };
            Department hrDept = new Department { Name = "HR" };
            company.Departments.Add(devDept);
            company.Departments.Add(hrDept);

            Employee emp1 = new Employee { Name = "Alice", Age = 28, Position = "Developer" };
            Employee emp2 = new Employee { Name = "Bob", Age = 32, Position = "HR Manager" };
            devDept.Employees.Add(emp1);
            hrDept.Employees.Add(emp2);
            Console.WriteLine("\nDepartments:");
            foreach (var dept in company.Departments)
            {
                Console.WriteLine($"Department: {dept.Name}, Employees: {dept.Employees.Count}");
            }

            Console.WriteLine("\nShapes:");

            List<Shape> shapes = new List<Shape>
            {
                new Circle(5),
                new Rectangle(4, 6)
            };

            Console.WriteLine("Shapes info:\n");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Area: {shape.Area()}");

                // Cast to IDrawable to call Draw
                (shape as IDrawable)?.Draw();
                Console.WriteLine();
            }
        }
    }
}
