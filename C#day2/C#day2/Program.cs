namespace C_day2
{
    struct Time
    {
        public int hours;
        public int minutes;
        public int seconds;

        public Time(int h, int m, int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }

        public void Print()
        {
            Console.WriteLine(hours + "H:" + minutes + "M:" + seconds + "S");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter student number: ");
            int n = int.Parse(Console.ReadLine());

            string[] names = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter student name " + (i + 1) + ": ");
                names[i] = Console.ReadLine();
            }

            Console.WriteLine("\nstudent name:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(names[i]);
            }


            Console.Write("\nEnter trake number: ");
            int tracks = int.Parse(Console.ReadLine());

            for (int t = 0; t < tracks; t++)
            {
                Console.Write("Enter number of student trakes " + (t + 1) + ": ");
                int stuNum = int.Parse(Console.ReadLine());

                int[] ages = new int[stuNum];
                int sum = 0;

                for (int j = 0; j < stuNum; j++)
                {
                    Console.Write("Enter student age " + (j + 1) + ": ");
                    ages[j] = int.Parse(Console.ReadLine());
                    sum += ages[j];
                }

                double avg = (double)sum / stuNum;
                Console.WriteLine("Averadge age in each trake " + (t + 1) + " = " + avg);
            }

            Console.WriteLine("\n--- Time ---");
            Time t1 = new Time(22, 33, 11);
            t1.Print();
        }
    }
}

