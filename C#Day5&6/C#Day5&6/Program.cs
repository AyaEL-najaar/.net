using System;
using System.Collections;
using System.Collections.Generic;

namespace C_Day5_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Assignment 1 Tests =====");

            // 1. Optimized Bubble Sort
            int[] nums = { 5, 1, 4, 2, 8 };
            Helper.OptimizedBubbleSort(nums);
            Console.WriteLine("Sorted Array: " + string.Join(",", nums));

            // 2. Range<T>
            var range = new Helper.Range<int>(10, 20);
            Console.WriteLine($"Is 15 in range? {range.IsInRange(15)}");
            Console.WriteLine($"Range Length: {range.Length()}");

            // 3. Reverse ArrayList
            ArrayList arrList = new ArrayList() { 1, 2, 3, 4, 5 };
            Helper.ReverseArrayList(arrList);
            Console.WriteLine("Reversed ArrayList: " + string.Join(",", arrList.ToArray()));

            // 4. Get Even Numbers
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var evens = Helper.GetEvenNumbers(numbers);
            Console.WriteLine("Even Numbers: " + string.Join(",", evens));

            // 5. FixedSizeList<T>
            var fixedList = new Helper.FixedSizeList<string>(2);
            fixedList.Add("Aya");
            fixedList.Add("Ahmed");
            Console.WriteLine($"FixedSizeList[0]: {fixedList.Get(0)}");
            Console.WriteLine($"FixedSizeList[1]: {fixedList.Get(1)}");

            // 6. First Non-Repeated Character
            string s = "swiss";
            int index = Helper.FirstNonRepeatedChar(s);
            Console.WriteLine($"First non-repeated char index in '{s}': {index}");
        }
    }
}
