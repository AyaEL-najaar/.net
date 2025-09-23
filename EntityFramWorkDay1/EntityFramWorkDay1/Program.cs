using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramWorkDay1
{
    internal class Program
    {
        // ---------- Class Subject ----------
        class Subject
        {
            public int Code { get; set; }
            public string Name { get; set; }
        }

        // ---------- Class Student ----------
        class Student
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Subject[] subjects { get; set; }
        }

        static void Main(string[] args)
        {
            // ---------------- Assignment 1 ----------------
            Console.WriteLine("=== Assignment 1 ===");

            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

            // Query1: remove duplicates (Distinct) + sort ascending
            var query1 = numbers.Distinct().OrderBy(n => n);
            Console.WriteLine("Query1: Distinct & Sorted numbers");
            foreach (var num in query1)
            {
                Console.WriteLine(num);
            }

            // Query2: from query1 → show number + its multiplication
            var query2 = query1.Select(n => new { Number = n, Square = n * n });
            Console.WriteLine("\nQuery2: Number and its Square");
            foreach (var item in query2)
            {
                Console.WriteLine($"{item.Number} -> {item.Square}");
            }

            // ---------------- Assignment 2 ----------------
            Console.WriteLine("\n=== Assignment 2 ===");

            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            // Query1: names with length = 3
            var namesQ1 = from n in names
                          where n.Length == 3
                          select n;
            Console.WriteLine("Query1: Names with length = 3");
            foreach (var name in namesQ1)
            {
                Console.WriteLine(name);
            }

            // Query2: names contain 'a' or 'A', ordered by length
            var namesQ2 = names.Where(n => n.ToLower().Contains("a"))
                               .OrderBy(n => n.Length);
            Console.WriteLine("\nQuery2: Names containing 'a' sorted by length");
            foreach (var name in namesQ2)
            {
                Console.WriteLine(name);
            }

            // Query3: first 2 names
            var namesQ3 = names.Take(2);
            Console.WriteLine("\nQuery3: First 2 names");
            foreach (var name in namesQ3)
            {
                Console.WriteLine(name);
            }

            // ---------------- Assignment 3 ----------------
            Console.WriteLine("\n=== Assignment 3 ===");

            // List of students with subjects
            List<Student> students = new List<Student>()
            {
                new Student(){ ID=1, FirstName="Ali", LastName="Mohammed",
                    subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"},
                                            new Subject(){ Code=33,Name="UML"}}},

                new Student(){ ID=2, FirstName="Mona", LastName="Gala",
                    subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"},
                                            new Subject(){ Code=34,Name="XML"},
                                            new Subject(){ Code=25,Name="JS"}}},

                new Student(){ ID=3, FirstName="Yara", LastName="Yousf",
                    subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"},
                                            new Subject(){ Code=25,Name="JS"}}},

                new Student(){ ID=1, FirstName="Ali", LastName="Ali",
                    subjects=new Subject[]{ new Subject(){ Code=33,Name="UML"}}},
            };

            // Query1: Full name + number of subjects
            var q1 = students.Select(s => new
            {
                FullName = s.FirstName + " " + s.LastName,
                SubjectCount = s.subjects.Count()
            });
            Console.WriteLine("Query1: Full name and number of subjects");
            foreach (var item in q1)
            {
                Console.WriteLine($"{item.FullName} - {item.SubjectCount}");
            }

            // Query2: order by FirstName Desc + LastName Asc
            var q2 = students.OrderByDescending(s => s.FirstName)
                             .ThenBy(s => s.LastName)
                             .Select(s => new { s.FirstName, s.LastName });
            Console.WriteLine("\nQuery2: Ordered Students (FirstName Desc, LastName Asc)");
            foreach (var item in q2)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            // Query3: display each student with his subjects (SelectMany)
            var q3 = students.SelectMany(s => s.subjects,
                        (st, subj) => new { Student = st.FirstName + " " + st.LastName, SubjectName = subj.Name });
            Console.WriteLine("\nQuery3: Each student with their subjects");
            foreach (var item in q3)
            {
                Console.WriteLine($"{item.Student} - {item.SubjectName}");
            }

            // BONUS: GroupBy Subject → show subject + students studying it
            var qBonus = students.SelectMany(s => s.subjects,
                                (st, subj) => new { Student = st.FirstName, SubjectName = subj.Name })
                                 .GroupBy(x => x.SubjectName);

            Console.WriteLine("\nBONUS: Group by Subject");
            foreach (var group in qBonus)
            {
                Console.WriteLine($"Subject: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($"  {student.Student}");
                }
            }
        }
    }
}
