namespace CommandLineMenu;

public class MenuUI : IMenuCLI
{
    private int _selectedOption = 0;
    public (int, string) CliMenu(string? question, params string[] options)
    {
        int length = options.Length;
        bool first = true;
        ConsoleKey key;
        _selectedOption = 0;

        if (!string.IsNullOrWhiteSpace(question))
            Console.WriteLine(question);

        do {
            PrintMenu(options, length, first);
            key = GetInput(length);
            first = false;
        } while (key != ConsoleKey.Enter);

        return (_selectedOption, options[_selectedOption]);
    }

    private void PrintMenu(string[] options, int length, bool first)
    {
        // Don't clear the menu on the initial write since there's no menu to clear
        if (!first)
            MoveUpCursor(length);

        // Text isn't cleared and is instead just overwritten,
        // has a bonus of not the menu not flickering since the text isn't dissapearing and reappearing constantly

        for (int i = 0; i < length; i++) {
            // print the selected option in a different color and underscore it
            if (i == _selectedOption) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(IMenuCLI.UNDERLINE + options[i] + IMenuCLI.RESET);
                Console.ResetColor();
            } else {
                Console.WriteLine(options[i]);
            }
        }
    }

    // Moves up the cursor to the start of the current menu
    private void MoveUpCursor(int length)
    {        
        var (_, currentTopPos) = Console.GetCursorPosition();
        int topOfMenu = Math.Max(currentTopPos - length, 0);
        Console.SetCursorPosition(0, topOfMenu);
    }

    private ConsoleKey GetInput(int length)
    {
        // Up and down arrows changes the selection & enter is used to make a choice.
        // All other keys are ignored
        ConsoleKey key = Console.ReadKey(intercept: true).Key;
        if (key == ConsoleKey.UpArrow) {
            _selectedOption--;
            _selectedOption = Math.Max(_selectedOption, 0);
        } else if (key == ConsoleKey.DownArrow) {
            _selectedOption++;
            _selectedOption = Math.Min(_selectedOption, length - 1);
        }
        return key;
    }
}
