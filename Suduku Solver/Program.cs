using System;
class GFG
{
    static int N = 9;
    static int count = 0;

    static bool solveSudoku(int[,] grid, int row, int col)
    {
        if (row == N - 1 && col == N)
            return true;

        if (col == N)
        {
            row++;
            col = 0;
        }

        if (grid[row, col] != 0)
            return solveSudoku(grid, row, col + 1);

        for (int num = 1; num < 10; num++)
        {
            Console.WriteLine("--- {0} ---", count);
            count++;
            print(grid);
            if (isSafe(grid, row, col, num))
            {
                grid[row, col] = num;

                if (solveSudoku(grid, row, col + 1))
                    return true;
            }
            grid[row, col] = 0;
        }
        return false;
    }

    static void print(int[,] grid)
    {
        Console.WriteLine("----------------------");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (j % 3 == 0)
                {
                    Console.Write("|");
                }
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine("|");
            if(i == 2 || i == 5 || i == 8)
            {
                Console.WriteLine("----------------------");
            }
        }
    }

    static bool isSafe(int[,] grid, int row, int col,
                        int num)
    {

        for (int x = 0; x <= 8; x++)
            if (grid[row, x] == num)
                return false;

        for (int x = 0; x <= 8; x++)
            if (grid[x, col] == num)
                return false;

        int startRow = row - row % 3, startCol
        = col - col % 3;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (grid[i + startRow, j + startCol] == num)
                    return false;

        return true;
    }

    static void Main()
    {
        int[,] grid = new int[N, N];

        Console.WriteLine("Select Input Method\n" +
                          "1- input one by one\n" +
                          "2- input whole string\n");
        string input = Console.ReadLine();

        if (input == "1")
        {
            //one by one input
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i % 3 == 0)
                    {
                        Console.WriteLine("---");
                    }
                    if (j % 3 == 0)
                    {
                        Console.Write(" | ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    String[] nums = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                    Console.Write("Grid[{0},{1}]: ", i + 1, j + 1);
                    String temp = Console.ReadLine();

                    if (temp == null)
                    {
                        temp = "0";
                    }

                    if (nums.Contains(temp))
                    {
                        grid[i, j] = int.Parse(temp);
                    }
                    else
                    {
                        grid[i, j] = 0;
                    }

                }
            }
        }
        else if (input == "2")
        {
            //string input
            Console.Write("Input String: ");
            string inString = Console.ReadLine();

            if(inString.Length == 81)
            {
            int index = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = int.Parse(inString[index].ToString());
                    index++;
                }
            }
            }
            else
            {
                grid = new int[N, N];
            }
            print(grid);
        }
        else
        {
            return;
        }

        

        


        if (solveSudoku(grid, 0, 0))
        {
            Console.WriteLine("Solved !! {0}", count);
            print(grid);
        }
        else
            Console.WriteLine("No Solution exists");
    }
}
