using System.Text.RegularExpressions;
using Aoc;

public class Day08_TreesInSight : AoC
{
    public override string InputFile => "day08/input.txt";

    public override object PartOne()
    {
        var matrix = GetMatrix();
        return CountEdgeTrees(matrix) + InnerVisibleTrees(matrix);
    }

    bool IsVisibleFromTop(int x, int y, int[,] array)
    {
        var treeSize = array[x, y];
        for (int i = 0; i < x; i++)
        {
            if (array[i, y] >= treeSize)
                return false;
        }
        return true;
    }

    bool IsVisibleFromBottom(int x, int y, int[,] array)
    {
        var treeSize = array[x, y];
        for (int i = array.GetLength(0) - 1; i > x; i--)
        {
            if (array[i, y] >= treeSize)
                return false;
        }
        return true;
    }

    bool IsVisibleFromLeft(int x, int y, int[,] array)
    {
        var treeSize = array[x, y];
        for (int i = 0; i < y; i++)
        {
            if (array[x, i] >= treeSize)
                return false;
        }
        return true;
    }

    bool IsVisibleFromRight(int x, int y, int[,] array)
    {
        var treeSize = array[x, y];
        for (int i = array.GetLength(0) - 1; i > y; i--)
        {
            if (array[x, i] >= treeSize)
                return false;
        }
        return true;
    }

    private int InnerVisibleTrees(int[,] arr)
    {
        int top, left, right, bottom, total;
        top = left = right = bottom = total = 0;
        for (int i = 1; i < arr.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < arr.GetLength(1) - 1; j++)
            {
                var toCheck = arr[i, j];
                top += IsVisibleFromTop(i, j, arr) ? 1 : 0;
                left += IsVisibleFromLeft(i, j, arr) ? 1 : 0;
                right += IsVisibleFromRight(i, j, arr) ? 1 : 0;
                bottom += IsVisibleFromBottom(i, j, arr) ? 1 : 0;
                total += (IsVisibleFromTop(i, j, arr) ||
                IsVisibleFromLeft(i, j, arr) ||
                IsVisibleFromRight(i, j, arr) ||
                IsVisibleFromBottom(i, j, arr)) ? 1 : 0;
            }
        }
        ;
        return total;//top + left + right + bottom;
    }

    private int CountEdgeTrees(int[,] arr) => arr.GetLength(0) * 2 + arr.GetLength(1) * 2 - 4;

    // thank you chat gpt.
    private void PrintMatrix(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // thank you chat gpt.
    private int[,] GetMatrix()
    {
        string[] lines = System.IO.File.ReadAllLines(InputFileFullPath);
        int[,] array = new int[lines.Length, lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                array[i, j] = int.Parse($"{lines[i][j]}");
            }
        }
        return array;
    }
    public override object PartTwo()
    {
        return "nah.";
    }
}
