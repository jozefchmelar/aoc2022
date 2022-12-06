using System.Diagnostics;
using Aoc;

public class Day06_Marker : AoC
{
    public override string InputFile => @"day06\day06input.txt";

    public override object PartOne()
    {
        var solution1 = Measure("Solution 1", () => Solve(4)).ToString();
        //kinda amazing to see that this one slower. didn't expect that. by about 1000 ticks.
        //probably due to the disk speed? still this one is using a stream instead of reading the file at once.
        var solution2 = Measure("Solution 2", () => Solve2(4)).ToString();
        return string.Join(",", solution1, solution2);
    }

    private object Measure(string description, Func<object> action)
    {
        var sw = new Stopwatch();
        sw.Start();
        var result = action();
        sw.Stop();
        return $"{description} took {sw.ElapsedTicks}ticks : {result}. ";
    }

    private object Solve2(int bufferSize)
    {
        using StreamReader sr = new StreamReader(InputFileFullPath);
        char[] buffer = new char[bufferSize];
        var reading = 0;
        while (sr.ReadBlock(buffer, 0, bufferSize) == bufferSize)
        {
            Array.Sort(buffer);
            for (int i = 0; i < buffer.Length; i++)
            {
                if (i + 1 == bufferSize) return reading + bufferSize - 1;
                if (buffer[i] == buffer[i + 1]) break;

            }
            reading += bufferSize;
        }
        throw new Exception("Not found");
    }

    private object Solve(int bufferSize)
    {
        var input = File.ReadAllText(InputFileFullPath); // kinda cheating.
        var set = new HashSet<char>();
        for (int i = 0; i < input.Length - 1 - bufferSize; i++)
        {
            set.Clear();
            for (int j = 0; j < bufferSize; j++)
            {
                set.Add(input[i + j]);
            }
            if (set.Count == bufferSize)
                return i + bufferSize;

        }
        throw new Exception("Not found");
    }
    public override object PartTwo() => Solve(14);
}