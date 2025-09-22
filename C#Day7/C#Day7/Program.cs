namespace C_Day7
{
    // Extension methods for string type
    static class StringExtensions
    {
        // Counts the number of words in a string
        public static int CountWords(this string s)
        {
            var splittedArray = s.Split(new char[] { ' ', '\t', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            return splittedArray.Length;
        }

        // Reverses the string
        public static string ReverseString(this string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }

    // Extension methods for int type
    static class IntExtensions
    {
        // Checks if an integer is even
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }

    // Extension methods for DateTime type
    static class DateTimeExtensions
    {
        // Calculates age based on the given birthdate
        public static int CalculateAge(this DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--; // Adjust if birthday hasn’t occurred yet this year
            return age;
        }
    }

    // Product class with Name and Price properties
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Product Name: {Name}, Price: {Price}";
        }
    }

    internal class Program
    {
        // Method that creates and returns a Product object (like anonymous object creation)
        static Product CreateProduct()
        {
            return new Product { Name = "Laptop", Price = 15000 };
        }

        static void Main(string[] args)
        {
            // Create and display product details
            var product = CreateProduct();
            Console.WriteLine(product);

            // Test string extension methods
            string sentence = "Hello, world! This is Aya.";
            Console.WriteLine($"Word Count: {sentence.CountWords()}");
            Console.WriteLine($"Reversed: {sentence.ReverseString()}");

            // Test int extension method
            int number = 42;
            Console.WriteLine($"Is {number} even? {number.IsEven()}");

            // Test DateTime extension method
            DateTime birthDate = new DateTime(2000, 9, 22);
            Console.WriteLine($"Age: {birthDate.CalculateAge()}");
        }
    }
}