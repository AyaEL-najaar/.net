namespace C_day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintAsciiOfChar();
            PrintCharOfAscii();
            SumSudMuil();
            OddEven();
            Grade();
            MuiltTable();
        }

        static void PrintAsciiOfChar()
        {
            Console.Write("Enter a character: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine("\nASCII code = " + (int)c);
        }
        static void PrintCharOfAscii()
        {
            Console.Write("Enter an ASCII code: ");
            int code = int.Parse(Console.ReadLine());
            char c = (char)code;
            Console.WriteLine("Character = " + c);
        }
        static void OddEven()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
                Console.WriteLine(num + " is even.");
            else
                Console.WriteLine(num + " is odd.");
        }
        static void SumSudMuil()
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Sum = " + (a + b));
            Console.WriteLine("Subtraction = " + (a - b));
            Console.WriteLine("Multiplication = " + (a * b));
        }
        static void Grade()
        {
            Console.Write("Enter student degree: ");
            int degree = int.Parse(Console.ReadLine());

            if (degree >= 90)
                Console.WriteLine("Grade: Excellent");
            else if (degree >= 80)
                Console.WriteLine("Grade: Very Good");
            else if (degree >= 70)
                Console.WriteLine("Grade: Good");
            else if (degree >= 60)
                Console.WriteLine("Grade: Pass");
            else
                Console.WriteLine("Grade: Fail");
        }
        static void MuiltTable()
        {
            Console.Write("Enter a number to show its multiplication table: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Multiplication Table of " + num + ":");
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine(num + " x " + i + " = " + (num * i));
            }
        }
    }
}

