
namespace Aoc
{
    public abstract class AoC
    {
        public abstract object PartOne();
        public abstract object PartTwo();
        public abstract string InputFile { get; }
        public string InputFileFullPath
            => Path.Join(Environment.CurrentDirectory, InputFile);
        public static string Solutions(AoC aoc) => $"{aoc.GetType().Name}: {Try(aoc.PartOne)}, {Try(aoc.PartTwo)}";

        private static object Try(Func<object> action)
        {
            try
            {
                return action();
            }
            catch (Exception e)
            {
                return "Error : " + e.ToString().Take(250);
            }
        }

    }
}