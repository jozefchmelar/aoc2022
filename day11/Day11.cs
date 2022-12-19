using System.Text.RegularExpressions;
using Aoc;

public class Day11 : AoC
{
    public override string InputFile => "day10/input.txt";

    public override object PartOne()
    {
        var samples = new int[] { 20, 60, 100, 140, 180, 220 };
        var crt = Process(new State(1, 1))
        .Where(x => samples.Contains(x.Cycle))
        .Sum(x => x.Cycle * x.registerX);
        return crt;

    }

    record struct State(int Cycle, int registerX);
    private IEnumerable<State> Process(State initialState)
    {
        var state = initialState;
        foreach (var instruction in Read())
        {
            if (instruction.Item1 == 1)
                yield return new(state.Cycle++, state.registerX);
            else
            {
                yield return new(state.Cycle++, state.registerX);
                yield return new(state.Cycle++, state.registerX);
                state.registerX += instruction.Item2;
            }
        }
    }
    private IEnumerable<(int, int)> Read() => File
            .ReadAllLines(InputFileFullPath)
            .Select(x => x == "noop" ? (1, 0) : (2, x.Split(" ").Last().Int()));

    public override object PartTwo()
    {
        return "nah.";
    }
}
