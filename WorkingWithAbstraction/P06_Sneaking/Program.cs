using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;

        private static void FillRoom(int n, int[] samPosition)
        {
            for (var row = 0; row < n; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
                for (var col = 0; col < room[row].Length; col++)
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
            }
        }

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            room = new char[n][];
            var samPosition = new int[2];
            FillRoom(n, samPosition);

            var moves = Console.ReadLine().ToCharArray();

            for (var i = 0; i < moves.Length; i++)
            {
                MoveEnemies();

                var getEnemy = new int[2];
                for (var j = 0; j < room[samPosition[0]].Length; j++)
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }

                if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd'
                                                 && getEnemy[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    for (var row = 0; row < room.Length; row++)
                    {
                        for (var col = 0; col < room[row].Length; col++) Console.Write(room[row][col]);
                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }
                else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b'
                                                      && getEnemy[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    for (var row = 0; row < room.Length; row++)
                    {
                        for (var col = 0; col < room[row].Length; col++) Console.Write(room[row][col]);
                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }

                MoveSam(samPosition, moves, i);

                room[samPosition[0]][samPosition[1]] = 'S';

                for (var j = 0; j < room[samPosition[0]].Length; j++)
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }

                if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    room[getEnemy[0]][getEnemy[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    for (var row = 0; row < room.Length; row++)
                    {
                        for (var col = 0; col < room[row].Length; col++) Console.Write(room[row][col]);
                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }
            }
        }

        private static void MoveEnemies()
        {
            for (var row = 0; row < room.Length; row++)
                for (var col = 0; col < room[row].Length; col++)
                    if (room[row][col] == 'b')
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    else if (room[row][col] == 'd')
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
        }

        private static void MoveSam(int[] samPosition, char[] moves, int i)
        {
            room[samPosition[0]][samPosition[1]] = '.';
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
        }
    }
}
