namespace DogeCoin
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(' ');
            int m = int.Parse(dimensions[0]) + 1;
            int n = int.Parse(dimensions[1]) + 1;
            int[,] maze = new int[m + 1, n + 1];
            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                var coin = Console.ReadLine().Split(' ');
                int enemyX = int.Parse(coin[0]) + 1;
                int enemyY = int.Parse(coin[1]) + 1;
                maze[enemyX, enemyY] ++;               
            }
            
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    maze[i, j] += Math.Max(maze[i, j - 1], maze[i - 1, j]);
                }
            }

            Console.WriteLine(maze[m, n]);
        }
    }
}