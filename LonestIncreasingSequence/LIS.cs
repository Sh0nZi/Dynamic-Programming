using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS
{
    class Program
    {
        static void Main(string[] args)
        {
            //2, 4, 3, 5, 1, 7, 6, 9, 8
            int[] nums = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int maxLength = 1;
            int end = 1;

            int[] length = new int[nums.Length];
            int[] best = new int[nums.Length];
            length[0] = 1;
            best[0] = -1;

            for (int i = 1; i < nums.Length; i++)
            {
                length[i] = 1;
                best[i] = -1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (length[j] + 1 > length[i] && nums[j] < nums[i])
                    {
                        length[i] = length[j] + 1;
                        best[i] = j;
                    }
                }
                
                if (length[i] > maxLength)
                {
                    maxLength = length[i];
                    end = i;
                }
            }

            Console.WriteLine("Maximum length: " +maxLength);
            Console.Write("Longest subsequence: ");
            int[] result = new int[maxLength];
            int pos = maxLength-1;

            while (end!=-1)
            {
                result[pos]=nums[end];
                end = best[end];
                pos--;
            }
            Console.WriteLine(string.Join(" ",result));

        }
    }
}