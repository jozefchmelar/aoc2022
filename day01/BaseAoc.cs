using System.Diagnostics;

namespace Aoc
{
    public abstract class AoC
    {
        public abstract object PartOne();
        public abstract object PartTwo();
        public abstract string InputFile { get; }
        public string InputFileFullPath
            => Path.Join(Environment.CurrentDirectory, InputFile);
        public static string Solutions(AoC aoc) => $"{aoc.GetType().Name}: {aoc.PartOne()}, {aoc.PartTwo()}";

    }
}