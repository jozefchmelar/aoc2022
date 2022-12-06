namespace Aoc
{
    public class Day02_RockPaperScissors : AoC
    {
        class Game
        {
            enum Hand { Rock, Paper, Scissors }
            Hand PlayerOne;
            Hand PlayerTwo;
            public Game(string gamePlayed)
            {
                var hands = gamePlayed.Trim().Split(" ").Select(FromInput);
                PlayerOne = hands.First();
                PlayerTwo = hands.Last();
            }
            public Game(IEnumerable<string> line)
            {
                (string, string) playAndResult = (line.First(), line.Last());
                PlayerOne = FromInput(playAndResult.Item1);
                PlayerTwo = (playAndResult.Item2, PlayerOne) switch
                {
                    ("Y", _) => PlayerOne,
                    ("X", Hand.Rock) => Hand.Scissors,
                    ("X", Hand.Paper) => Hand.Rock,
                    ("X", Hand.Scissors) => Hand.Paper,
                    ("Z", Hand.Rock) => Hand.Paper,
                    ("Z", Hand.Paper) => Hand.Scissors,
                    ("Z", Hand.Scissors) => Hand.Rock,
                    _ => throw new Exception()
                };
            }

            public int MyScore() => (PlayerOne, PlayerTwo) switch
            {
                (Hand.Rock, Hand.Rock) => 3 + 1,
                (Hand.Rock, Hand.Paper) => 6 + 2,
                (Hand.Rock, Hand.Scissors) => 0 + 3,

                (Hand.Paper, Hand.Rock) => 0 + 1,
                (Hand.Paper, Hand.Paper) => 3 + 2,
                (Hand.Paper, Hand.Scissors) => 6 + 3,

                (Hand.Scissors, Hand.Rock) => 6 + 1,
                (Hand.Scissors, Hand.Paper) => 0 + 2,
                (Hand.Scissors, Hand.Scissors) => 3 + 3,
                _ => throw new Exception()
            };
            private Hand FromInput(string s) => s switch
            {
                "A" or "X" => Hand.Rock,
                "B" or "Y" => Hand.Paper,
                "C" or "Z" => Hand.Scissors,
                _ => throw new Exception()
            };

        }

        public override string InputFile => @"day02\day02input.txt";

        public override string PartOne() => File
            .ReadAllLines(InputFileFullPath)
            .Select(x => new Game(x))
            .Select(x => x.MyScore())
            .Sum()
            .ToString();

        public override object PartTwo() => File
            .ReadAllLines(InputFileFullPath)
            .Select(x => new Game(x.Split(" ")))
            .Select(x => x.MyScore())
            .Sum();

    }
}