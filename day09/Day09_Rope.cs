using System.Text.RegularExpressions;
using Aoc;

public class Day09_Rope : AoC
{
    public override string InputFile => "day09/input.txt";

    record struct XY(int X, int Y);
    record class State(XY Head, XY Tail, String LastDirection);
    public override object PartOne()
    {
        var history = new List<State>();
        var cmds = File
        .ReadAllLines(InputFileFullPath)
        .Select(line => line.Split(" "))
        .Select(parsed => (Direction: parsed.First(), Distance: int.Parse(parsed.Last())))
        .Select(cmd => Enumerable.Range(0, cmd.Distance).Select(x => cmd.Direction))
        .SelectMany(x => x);

        var state = new State(new XY { X = 0, Y = 0 }, new XY { X = 0, Y = 0 }, "X");
        history.Add(state);
        cmds.ForEach(direction =>
        {
            var moveHead = direction switch
            {
                "R" => state with { Head = state.Head with { X = state.Head.X + 1 } },
                "L" => state with { Head = state.Head with { X = state.Head.X - 1 } },
                "U" => state with { Head = state.Head with { Y = state.Head.Y + 1 } },
                "D" => state with { Head = state.Head with { Y = state.Head.Y + 1 } },
                _=> throw new Exception()
            } with
            { LastDirection = direction };

            history.Add(moveHead with { });
            state = moveHead;

            if (!AreItemsNextToEachOther(state.Head, state.Tail))
            {
                var afterTailMove = MoveTail(state);
                state = afterTailMove;
                history.Add(state with { });
                PrintState(state);
            }


        });

        return "banana";
    }

    void PrintState(State state)
    {
        return;
        var x = 7;
        var y = 6;

        for (int i = x - 1; i >= 0; i--)
        {
            for (int j = y - 1; j >= 0; j--)
            {
                if (state.Head.X == j && state.Head.Y == i)
                    Console.Write("H");
                else if (state.Tail.X == j && state.Tail.Y == i)
                    Console.Write("T");
                else
                    Console.Write(".");
            }
            Console.WriteLine();
        }
        System.Console.WriteLine("----------------");
    }
    //Thanks GPT
    bool AreItemsNextToEachOther(XY item1, XY item2)
    {
        double distance = Math.Sqrt(Math.Pow(item1.X - item2.X, 2) + Math.Pow(item1.Y - item2.Y, 2));
        return distance <= 1;
    }

    private State MoveTail(State state)
    {
        if (state.Head.Y == state.Tail.Y)
        {
            return state.LastDirection switch
            {
                "R" => state with { Tail = state.Tail with { X = state.Tail.X + 1 } },
                "L" => state with { Tail = state.Tail with { X = state.Tail.X - 1 } },
                "U" => state with { Tail = state.Tail with { Y = state.Tail.Y + 1 } },
                "D" => state with { Tail = state.Tail with { Y = state.Tail.Y + 1 } }
            };
        }
        if (state.Head.Y > state.Tail.Y)
        {
            return state with { Tail = state.Tail with { X = state.Head.X, Y = state.Head.Y - 1 } };
        }
        return state;
    }

    public override object PartTwo()
    {
        return "nah.";
    }
}
