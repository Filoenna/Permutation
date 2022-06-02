using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            PrintResult(
               Permute(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })
           );


            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);

            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();

            PrintResult2(
               Permute(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })
           );


            
            stopWatch2.Stop();
            // Get the elapsed time as a TimeSpan value.
            ts = stopWatch2.Elapsed;

            // Format and display the TimeSpan value.
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
        }

        static IList<IList<int>> Permute(int[] nums)
        {
            var list = new List<IList<int>>();
            return DoPermute(nums, 0, nums.Length - 1, list);
        }

        static IList<IList<int>> DoPermute(int[] nums, int start, int end, IList<IList<int>> list)
        {
            if (start == end)
            {
                list.Add(new List<int>(nums));
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    Swap(ref nums[start], ref nums[i]);
                    DoPermute(nums, start + 1, end, list);
                    Swap(ref nums[start], ref nums[i]);
                }
            }

            return list;
        }

        static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        static void PrintResult(IList<IList<int>> lists)
        {
            int first, second, third;
            foreach (var list in lists)
            {
                first = list[0] * (list[1] * 10 + list[2]);
                second = (list[3] * 100 + list[4] * 10 + list[5]);
                third = (list[6] * 10 + list[7]) * list[5];

                if (first == second && second == third)
                {
                    Console.WriteLine("{0} x {1} = {2} = {3} x {4}", list[0], list[1] * 10 + list[2], list[3] * 100 + list[4] * 10 + list[5], list[6] * 10 + list[7], list[5]);
                }
            }
        }

        static void PrintResult2(IList<IList<int>> lists)
        {
            int first, second, third;
            foreach (var list in lists)
            {
                //On first and last place there can't be number 1
                bool cond1 = list[0] != 1 && list[8] != 1;
                bool cond2 = list[0] % 2 != 0 && list[1] % 2 != 0;
                bool cond3 = list[5] % 2 != 0;
                bool cond4 = list[7] % 2 != 0 || list[1] % 2 != 8;
                if (list[0] != 1 && list[8] != 1)
                {
                    //If first or second number is even, then first result also has to 
                    if (!(cond2 || cond3 || cond4))
                    {
                        continue;
                    }
                    first = list[0] * (list[1] * 10 + list[2]);
                    second = (list[3] * 100 + list[4] * 10 + list[5]);
                    third = (list[6] * 10 + list[7]) * list[5];

                    if (first == second && second == third)
                    {
                        Console.WriteLine("{0} x {1} = {2} = {3} x {4}", list[0], list[1] * 10 + list[2], list[3] * 100 + list[4] * 10 + list[5], list[6] * 10 + list[7], list[5]);
                    }
                }
                
            }
        }
    }
}
