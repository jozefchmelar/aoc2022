using System.Text.RegularExpressions;
using Aoc;

public class Day05_Cranes : AoC
{
    public override string InputFile => @"day05\day05input.txt";

    public override object PartOne()
    {
        var file = File.ReadAllLines(InputFileFullPath);
        var loadedStacks = LoadStacks(file);

        ParseCommands(file).ForEach(command => command
            .HowMany
            .Repetitions(() => loadedStacks![command.To - 1].Push(loadedStacks[command.From - 1].Pop())
        ));

        return loadedStacks
            .Select(x => x.First())
            .Join("");
    }
    public override object PartTwo()
    {
        var file = File.ReadAllLines(InputFileFullPath);
        var loadedStacks = LoadStacks(file);

        ParseCommands(file)
           .ForEach(command =>
           {
               var boxes = Enumerable.Range(0, command.HowMany).Select(y => loadedStacks[command.From - 1].Pop()).Reverse();
               boxes.ForEach(loadedStacks[command.To - 1].Push);
           });

        return loadedStacks
            .Select(x => x.First())
            .Join("");
    }

    private IList<Stack<string>> LoadStacks(string[] input) => input
        .TakeWhile(x => !x.StartsWith(" 1"))
        .Select(x => x.Chunk(4).Select(y => y.All(char.IsWhiteSpace) ? "[X] " : y.Join("")).Join(""))
        .Select(x => x.Replace("[", "").Replace("]", "").Split(" "))
        .Aggregate(new List<IList<String>>(EmptyStacks(input)), (acc, value) =>
            {
                value.ForEachIndexed((box, i) =>
                {
                    if (box != "X")
                        acc[i].Add(box);
                });
                return acc;
            })
        .Select(x => new Stack<string>(x.Reverse()))
        .ToList();

    private IEnumerable<IList<string>> EmptyStacks(string[] input) => input
        .TakeWhile(x => !x.StartsWith("move"))
        .SkipLast(1)
        .Last()
        .Replace(" 1", "1").Replace("   ", " ").Split(" ").SkipLast(1).Select(int.Parse)
        .Select(x => new List<string>());

    record struct Command(int HowMany, int From, int To);

    private IEnumerable<Command> ParseCommands(string[] input) => input
        .SkipWhile(x => !x.StartsWith("move"))
        .Select(x => Regex.Match(x, @"move (.*) from (.*) to (.*)"))
        .Select(x => x.Groups.Values.Skip(1).Select(x => x.Value).Select(Int32.Parse).ToArray())
        .Select(x => new Command(HowMany: x[0], From: x[1], To: x[2]));

}