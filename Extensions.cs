public static class Extensions
{
    public static string Join<T>(this IEnumerable<T> ienu, string separator = ",") => string.Join(separator, ienu);

    public static void Let<T>(this T @object, Action<T> a) => a(@object);
}