namespace CommandLineMenu;

public interface IMenuCLI
{
    /// <summary>
    /// Strings to handle console formatting
    /// </summary>    
    internal static string UNDERLINE { get => "\x1b[4m"; }
    internal static string RESET { get => "\x1b[24m"; }

    /// <summary>
    /// Accepts an array of string options
    /// </summary>
    /// <param name="options">String array of options to display</param>
    /// <returns>returns the index and text of the selected option</returns>
    public (int index, string option) CliMenu(string[] options);

    /// <summary>
    /// Accepts a bool for displaying the tutorial and an array of string options
    /// </summary>
    /// <param name="printTutorial">Display the button tutorials</param>
    /// <param name="options">String array of options to display</param>
    /// <returns>returns the index and text of the selected option</returns>
    public (int index, string option) CliMenu(bool printTutorial, string[] options);

    /// <summary>
    /// Accepts a question and an array of string options
    /// </summary>
    /// <param name="question">Question that's printed above the options</param>
    /// <param name="options">String array of options to display</param>
    /// <returns>returns the index and text of the selected option</returns>
    public (int index, string option) CliMenu(string question, string[] options);

    /// <summary>
    /// Accepts a question, a bool to decide if the button tutorial should be displayed, and an array of string options
    /// </summary>
    /// <param name="question">Question that's printed above the options</param>
    /// <param name="options">String array of options to display</param>
    /// <returns>returns the index and text of the selected option</returns>
    public (int index, string option) CliMenu(string question, bool printTutorial, string[] options);
}
