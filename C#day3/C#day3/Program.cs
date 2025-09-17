namespace C_day3
{
    class Calc
    {
        public int Sum(int a, int b) => a + b;
        public double Sum(double a, double b) => a + b;

        public int Sub(int a, int b) => a - b;
        public double Sub(double a, double b) => a - b;

        public int Mul(int a, int b) => a * b;
        public double Mul(double a, double b) => a * b;

        public int Div(int a, int b) => b != 0 ? a / b : 0;
        public double Div(double a, double b) => b != 0 ? a / b : 0.0;
    }
    class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        public Question() { }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        public virtual void Show()
        {
            Console.WriteLine($"[{Header}] {Body} ({Mark} marks)");
        }
    }
    class MCQ : Question
    {
        public string[] Choices { get; set; }
        public int CorrectAnswer { get; set; } // store correct index

        public MCQ(string header, string body, int mark, string[] choices, int correctAnswer)
            : base(header, body, mark)
        {
            Choices = choices;
            CorrectAnswer = correctAnswer;
        }

        public override void Show()
        {
            base.Show();
            for (int i = 0; i < Choices.Length; i++)
                Console.WriteLine($"{i + 1}. {Choices[i]}");
        }

        public bool CheckAnswer(int userAnswer)
        {
            return userAnswer == CorrectAnswer;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test Calc
            Calc calc = new Calc();
            Console.WriteLine("Sum: " + calc.Sum(5, 3));
            Console.WriteLine("Mul: " + calc.Mul(4, 2));

            // Single MCQ
            MCQ q1 = new MCQ("Q1", "What is the capital of France?", 5,
                new string[] { "Berlin", "Paris", "Rome" }, 2);
            q1.Show();

            Console.Write("Your answer: ");
            int ans = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine(q1.CheckAnswer(ans) ? "Correct!" : "Wrong!");

            // Array of MCQs
            Console.Write("\nHow many questions? ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            MCQ[] quiz = new MCQ[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter data for Question {i + 1}");
                Console.Write("Header: ");
                string header = Console.ReadLine();

                Console.Write("Body: ");
                string body = Console.ReadLine();

                Console.Write("Mark: ");
                int mark = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("How many choices? ");
                int c = int.Parse(Console.ReadLine() ?? "0");
                string[] choices = new string[c];
                for (int j = 0; j < c; j++)
                {
                    Console.Write($"Choice {j + 1}: ");
                    choices[j] = Console.ReadLine();
                }

                Console.Write("Correct answer index (1-based): ");
                int correct = int.Parse(Console.ReadLine() ?? "1");

                quiz[i] = new MCQ(header, body, mark, choices, correct);
            }

            Console.WriteLine("\n--- Quiz Start ---");
            int totalScore = 0;
            foreach (var q in quiz)
            {
                q.Show();
                Console.Write("Your answer: ");
                int userAns = int.Parse(Console.ReadLine() ?? "0");
                if (q.CheckAnswer(userAns))
                    totalScore += q.Mark;
            }
            Console.WriteLine($"\nYour total score = {totalScore}");
        }
    }
}
