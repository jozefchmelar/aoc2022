public static class Extensions
{
    public static string Join<T>(this IEnumerable<T> ienu, string separator = ",")
        => string.Join(separator, ienu);

    public static void ForEach<T>(this IEnumerable<T> ienu, Action<T> action)
    {
        foreach (var x in ienu)
        {
            action(x);
        }
    }

    public static void ForEachIndexed<T>(this IEnumerable<T> ienu, Action<T, int> action)
    {
        var i = 0;
        foreach (var x in ienu)
        {
            action(x, i++);
        }
    }

    public static void Repetitions(this Int32 ienu, Action action)
    {
        Enumerable.Range(0, ienu).ForEach(x => action());
    }



    public static void Let<T>(this T @object, Action<T> a) => a(@object);
}