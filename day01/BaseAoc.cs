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
        public string Solutions() => $"{this.GetType().Name}: {PartOne()}, {PartTwo()}";

    }
}