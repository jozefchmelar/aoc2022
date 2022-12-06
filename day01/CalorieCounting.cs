namespace Aoc
{
    public class Day01_CalorieCounting : AoC
    {
        public override string InputFile => @"day01\CalorieCounting.txt";
        public override object PartOne() => File
            .ReadAllText(InputFileFullPath, System.Text.Encoding.UTF8)
            .ReplaceLineEndings()
            .Split("\n\n")
            .Select(x => x.Split("\n").Select(long.Parse).Sum())
            .OrderDescending()
            .First();

        public override object PartTwo() => File
            .ReadAllText(InputFileFullPath)
            .ReplaceLineEndings()
            .Split("\n\n")
            .Select(x => x.Split("\n").Select(long.Parse).Sum())
            .OrderDescending()
            .Take(3)
            .Sum();
    }
}