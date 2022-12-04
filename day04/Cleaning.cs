using Aoc;

public class Day04_Cleanining : AoC
{
    public override string InputFile => @"day04\day04input.txt";

    public override object PartOne() => File
        .ReadAllLines(InputFileFullPath)
        .Select(x => x.Split(","))
        .Select(x => (first: x.First().Split("-").Select(int.Parse), second: x.Last().Split("-").Select(int.Parse)))
        .Select(x => (first: (from: x.first.First(), to: x.first.Last()), second: (from: x.second.First(), to: x.second.Last())))
        .Where(x => Contains((x.first), (x.second)) || Contains((x.second), (x.first))) //jesus fkcn christ...check from both sides here.
        .Count();

    public override object PartTwo() => File
        .ReadAllLines(InputFileFullPath)
        .Select(x => x.Split(","))
        .Select(x => (first: x.First().Split("-").Select(int.Parse), second: x.Last().Split("-").Select(int.Parse)))
        .Select(x => (first: (from: x.first.First(), to: x.first.Last()), second: (from: x.second.First(), to: x.second.Last())))
        .Where(x => Overlaps((x.first), (x.second)) || Overlaps((x.second), (x.first))) //jesus fkcn christ...check from both sides here.
        .Count();
        
    bool Contains((int, int) first, (int, int) second) => first.Item1 <= second.Item1 && second.Item2 <= first.Item2;

    bool Overlaps((int, int) first, (int, int) second) => first.Item2 >= second.Item1 && first.Item1 <= second.Item2;
}
