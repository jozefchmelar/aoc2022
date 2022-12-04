using Aoc;
public class Program
{
    public static void Main(string[] args) => AppDomain
        .CurrentDomain
        .GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(x => x.IsSubclassOf(typeof(AoC)))
        .OrderBy(x => x.Name)
        .Select(Activator.CreateInstance)
        .Cast<AoC>()
        .Select(AoC.Solutions)
        .Join("\n")
        .Let(System.Console.WriteLine);
}