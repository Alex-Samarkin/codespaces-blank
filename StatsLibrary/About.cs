namespace StatsLibrary;
public static class About
{
    public static string Name { get; } = "StatsLibrary";
    public static string Version { get; } = "1.0.0";
    public static string Author { get; } = "John Doe";

    public static string GetAbout()
    {
        return $"{Name} {Version} by {Author}";
    }
    
}
