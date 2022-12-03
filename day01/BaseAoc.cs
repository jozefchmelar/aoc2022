using System.Diagnostics;

namespace Aoc
{
    public abstract class BaseAoc
    {
        public abstract object PartOne();
        public abstract object PartTwo();
        public abstract string InputFile { get; }
        public string InputFileFullPath
            => Path.Join(Environment.CurrentDirectory, InputFile);
        public static string Solutions(BaseAoc aoc) => $"{aoc.GetType().Name}: {aoc.PartOne()}, {aoc.PartTwo()}";

    }
}