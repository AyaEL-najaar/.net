using System;
using System.Collections.Generic;
using System.Collections;

namespace C_Day5_6
{
    internal class Helper
    {
        // 1. Optimized Bubble Sort
        public static void OptimizedBubbleSort<T>(T[] Array) where T : IComparable<T>
        {
            if (Array is not null)
            {
                for (int i = 0; i < Array.Length - 1; i++)
                {
                    bool swapped = false;
                    for (int j = 0; j < Array.Length - i - 1; j++)
                    {
                        if (Array[j].CompareTo(Array[j + 1]) > 0)
                        {
                            T temp = Array[j];
                            Array[j] = Array[j + 1];
                            Array[j + 1] = temp;
                            swapped = true;
                        }
                    }
                    if (!swapped) break;
                }
            }
        }

        // 2. Generic Range<T> Class
        public class Range<T> where T : IComparable<T>
        {
            public T Min { get; }
            public T Max { get; }

            public Range(T min, T max)
            {
                if (min.CompareTo(max) > 0)
                    throw new ArgumentException("Min must be <= Max");

                Min = min;
                Max = max;
            }

            public bool IsInRange(T value)
            {
                return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
            }

            public dynamic Length()
            {
                dynamic min = Min;
                dynamic max = Max;
                return max - min;
            }
        }

        // 3. Reverse ArrayList
        public static void ReverseArrayList(ArrayList list)
        {
            if (list is not null)
            {
                int left = 0, right = list.Count - 1;
                while (left < right)
                {
                    object temp = list[left];
                    list[left] = list[right];
                    list[right] = temp;
                    left++;
                    right--;
                }
            }
        }

        // 4. Get Even Numbers
        public static List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> evens = new List<int>();
            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                    evens.Add(num);
            }
            return evens;
        }

        // 5. FixedSizeList<T>
        public class FixedSizeList<T>
        {
            private T[] items;
            private int count;

            public FixedSizeList(int capacity)
            {
                if (capacity <= 0)
                    throw new ArgumentException("Capacity must be > 0");
                items = new T[capacity];
                count = 0;
            }

            public void Add(T item)
            {
                if (count >= items.Length)
                    throw new InvalidOperationException("List is full!");
                items[count++] = item;
            }

            public T Get(int index)
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Invalid index!");
                return items[index];
            }
        }

        // 6. First Non-Repeated Character
        public static int FirstNonRepeatedChar(string s)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (freq[s[i]] == 1)
                    return i;
            }
            return -1;
        }
    }
}
