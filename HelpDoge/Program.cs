namespace HelpDoge
{
    using System;
    using System.Numerics;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            var food = Console.ReadLine().Split(' ');
            int fx = int.Parse(food[0]) + 1;
            int fy = int.Parse(food[1]) + 1;
            BigInteger[,] maze = new BigInteger[fx + 1, fy + 1];
            maze[1, 1] = 1;
            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                var enemy = Console.ReadLine().Split(' ');
                int enemyX = int.Parse(enemy[0]) + 1;
                int enemyY = int.Parse(enemy[1]) + 1;
                if (enemyX > fx || enemyY > fy)
                {
                    continue;
                }
                maze[enemyX, enemyY] = -1;               
            }

            for (int i = 1; i <= fx; i++)
            {
                for (int j = 1; j <= fy; j++)
                {
                    if (maze[i, j] == -1)
                    {
                        maze[i, j] = 0;
                        continue;
                    }

                    maze[i, j] += maze[i, j - 1] + maze[i - 1, j];
                }
            }

            Console.WriteLine(maze[fx, fy]);
        }
    }
}