namespace Businessmen
{
    using System;
    using System.Linq;
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            ulong[,] dp = new ulong[n + 1, n + 2];
            string expr = new string('?', n);

            dp[0, 0] = 1;

            for (int i = 1; i <= n; i++)
            {
                if (expr[i - 1] == '(')
                {
                    dp[i, 0] = 0;
                }
                else
                {
                    dp[i, 0] = dp[i - 1, 1];
                }

                for (int j = 1; j <= n; j++)
                {
                    if (expr[i - 1] == '(')
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (expr[i - 1] == ')')
                    {
                        dp[i, j] = dp[i - 1, j + 1];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j + 1];
                    }
                }
            }

            Console.WriteLine(dp[n, 0]);
        }
    }
}