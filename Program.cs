using Aoc;
public class Program
{
    public static void Main(string[] args) => AppDomain
        .CurrentDomain
        .GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(x => x.IsSubclassOf(typeof(BaseAoc)))
        .Select(Activator.CreateInstance)
        .Cast<BaseAoc>()
        .Select(BaseAoc.Solutions)
        .Join("\n")
        .Let(System.Console.WriteLine);
}