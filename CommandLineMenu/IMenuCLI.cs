namespace CommandLineMenu;

public interface IMenuCLI
{
    // <summary>
    // Strings to handle console formatting
    // </summary>    
    internal static string UNDERLINE { get => "\x1b[4m"; }
    internal static string RESET { get => "\x1b[24m"; }

    /// <summary>
    /// Acceps an optional question and an array of string options
    /// </summary>
    /// <param name="question">Question that's printed above the options if sent in</param>
    /// <param name="options">String array of options to display</param>
    /// <returns>returns the index and text of the selected option</returns>
    public (int, string) CliMenu(string? question, params string[] options);
}
