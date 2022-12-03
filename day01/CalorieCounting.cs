namespace Aoc
{
    public class CalorieCounting : BaseAoc
    {
        public override string InputFile => @"day01\CalorieCounting.txt";
        public override object PartOne() => File
            .ReadAllText(InputFileFullPath)
            .Split("\n\n")
            .Select(x => x.Split("\n").Select(int.Parse).Sum())
            .OrderDescending()
            .First();

        public override object PartTwo() => File
            .ReadAllText(InputFileFullPath)
            .Split("\n\n")
            .Select(x => x.Split("\n").Select(int.Parse).Sum())
            .OrderDescending()
            .Take(3)
            .Sum();

    }
}