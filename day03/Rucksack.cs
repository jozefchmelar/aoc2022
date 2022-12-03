namespace Aoc
{
    public class Rucksack : BaseAoc
    {
        public override string InputFile => @"day03\rucksackInput.txt";

        public override object PartOne() => File
            .ReadAllLines(InputFileFullPath)
            .Select(x => x.Chunk(x.Count() / 2))
            .Select(x => x.First().Intersect(x.Last()).First())
            .Select(Score)
            .Sum();

        public override object PartTwo() => File
            .ReadAllLines(InputFileFullPath)
            .Chunk(3)
            .Select(x => x[0].Intersect(x[1]).Intersect(x[2]).First())
            .Select(Score)
            .Sum();

        private int Score(char x) => char.IsUpper(x) ? (int)x - 38 : (int)x - 96;
    }
}