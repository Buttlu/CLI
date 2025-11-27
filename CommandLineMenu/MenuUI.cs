using ConsoleUtils;

namespace CommandLineMenu;

public class MenuUI(IUI ui) : IMenuCLI
{
    private int _selectedOption = 0;
    private readonly IUI _ui = ui;

    public ConsoleColor SelectedColor { get; set; } = ConsoleColor.Cyan;
    public (int index, string option) CliMenu(string[] options) => CliMenu("", false, options);
    public (int index, string option) CliMenu(string question, string[] options) => CliMenu(question, false, options);
    public (int index, string option) CliMenu(bool printTutorial, string[] options) => CliMenu("", printTutorial, options);

    public (int index, string option) CliMenu(string question, bool printTutorial, string[] options)
    {
        _ui.HideCursor();

        int length = options.Length;
        bool first = true;
        ConsoleKey key;
        _selectedOption = 0;
        
        if (printTutorial)
            _ui.Println("Move using up and down arrows, select using enter");
        
        if (!string.IsNullOrWhiteSpace(question))
            _ui.Println(question);

        // Prints the menu and gets input until the user makes a selection
        do {
            PrintMenu(options, length, first);
            key = MoveSelection(length);
            first = false;
        } while (key != ConsoleKey.Enter);

        _ui.ShowCursor();
        _ui.Println("");
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
