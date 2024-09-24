try
{
    var fileName = CommandLineParser.Parse(args);
    var count = TextAnalyzer.AnalyzeFile(fileName);

    Console.WriteLine($"Success. Found {count} occurances");
    Environment.Exit(0);

}
catch (Exception ex)
{
    Console.WriteLine($"Failed. {ex.Message}");
    Environment.Exit(-1);
}

public static class CommandLineParser
{
    public static string Parse(string[] args)
    {
        if (args.Length == 0)
            throw new ArgumentException("Expected one argument 'file path'. Got zero.");

        if (args.Length > 1)
            throw new ArgumentException($"Expected one, single argument 'file path'. Got {args.Length}");

        return args[0];
    }
}

public static class TextAnalyzer
{
    public static int AnalyzeFile(string file)
    {
        if (!File.Exists(file))
            throw new FileNotFoundException(file);

        var text = File.ReadAllText(file);
        var searchString = Path.GetFileNameWithoutExtension(file);
        return AnalyzeText(text, searchString);
    }

    public static int AnalyzeText(string text, string searchString)
    {
        if (string.IsNullOrEmpty(searchString))
            throw new ArgumentException("Search string must not be empty");

        int count = 0;
        int index = 0;
        while ((index = text.IndexOf(searchString, index)) != -1)
        {
            ++count;
            index += searchString.Length;
        }

        return count;
    }
}
