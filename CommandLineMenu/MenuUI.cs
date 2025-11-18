using ConsoleUtils;

namespace CommandLineMenu;

public class MenuUI(IUI ui) : IMenuCLI
{
    private int _selectedOption = 0;
    private readonly IUI _ui = ui;

    public ConsoleColor SelectedColor { get; set; } = ConsoleColor.Cyan;

    public (int, string) CliMenu(string? question, params string[] options)
    {
        _ui.HideCursor();

        int length = options.Length;
        bool first = true;
        ConsoleKey key;
        _selectedOption = 0;

        if (!string.IsNullOrWhiteSpace(question))
            _ui.Println(question);

        do {
            PrintMenu(options, length, first);
            key = MoveSelection(length);
            first = false;
        } while (key != ConsoleKey.Enter);

        _ui.ShowCursor();

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
                _ui.Println(IMenuCLI.UNDERLINE + options[i] + IMenuCLI.RESET, SelectedColor);
            } else {
                _ui.Println(options[i]);
            }
        }
    }

    // Moves up the cursor to the start of the current menu
    private void MoveUpCursor(int length)
    {        
        var (_, currentTopPos) = _ui.GetCursorPosition();
        int topOfMenu = Math.Max(currentTopPos - length, 0);
        _ui.SetCursorPosition(0, topOfMenu);
    }

    private ConsoleKey MoveSelection(int length)
    {
        // Up and down arrows changes the selection & enter is used to make a choice.
        // All other keys are ignored
        ConsoleKey key = _ui.GetKey(intercept: true);
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
