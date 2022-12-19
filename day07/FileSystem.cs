using Aoc;
public class Day07_FileSystem : AoC
{
    public override string InputFile => "day07/input.txt";

    public override object PartOne() =>
         Directories()
         .Where((kv) => kv.Value <= 100000)
         .Sum(x => x.Value);

    private int FreeSpace()=> 70000000 - Directories().MaxBy(x => x.Value).Value;
    public override object PartTwo() => Directories()
        .Where((kv) => (FreeSpace() + kv.Value) > 30000000)
        .OrderBy(x => x.Value).Select(x => x.Value)
        .FirstOrDefault();

  //  private static IDictionary<string, int> WorkaroundDirs = new Day07_FileSystem().Directories();
    private IDictionary<string, int> Directories()
    {
        var path = new Stack<string>();
        var sizes = new Dictionary<string, int>();
        File
        .ReadAllLines(InputFileFullPath)
        .ForEach(line =>
        {
            if (line.Contains("cd .."))
            {
                path.Pop();
                return;
            }
            if (line.Contains("cd"))
                path.Push(path.Join("") + line.Split(" ").Last());

            if (char.IsNumber(line.First()))
            {
                var pathSize = sizes.GetValueOrDefault(path.Peek());
                var fileSize = int.Parse(line.Split(" ").First());
                var pathx = path.Peek();
                sizes[pathx] = sizes.GetValueOrDefault(pathx) + fileSize;
                //add to the parent dirs
                path.Skip(1).ForEach(p => sizes[p] = sizes.GetValueOrDefault(p) + fileSize);
            }
        });
        return sizes;
    }

}