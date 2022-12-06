namespace Aoc
{
    public class Day01_CalorieCounting : AoC
    {
        public override string InputFile => @"day01\CalorieCounting.txt";
        public override object PartOne() => File
            .ReadAllText(InputFileFullPath, System.Text.Encoding.UTF8)
            .ReplaceLineEndings()
            .Split(Environment.NewLine+Environment.NewLine)
            .Select(x => x.Split(Environment.NewLine).Select(long.Parse).Sum())
            .OrderDescending()
            .First();

        public override object PartTwo() => File
            .ReadAllText(InputFileFullPath)
            .ReplaceLineEndings()
            .Split(Environment.NewLine+Environment.NewLine)
            .Select(x => x.Split(Environment.NewLine).Select(long.Parse).Sum())
            .OrderDescending()
            .Take(3)
            .Sum();
    }
}