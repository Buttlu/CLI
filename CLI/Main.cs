namespace CLI;

internal class Main
{
    private int _selectedOption = 0;
    
    private const string UNDERLINE = " \x1b[4m";
    private const string RESET = " \x1b[24m";

    public void Run()
    {
        _selectedOption = 0;
        int length = 0;
        ConsoleKey key = ConsoleKey.Backspace;
        while (key != ConsoleKey.Enter) {
            length = PrintMenu("Attack 1", "Attack 2", "Attack 3", "Attack 4", "Pizza", "Quit");
            key = GetInput(length);
        }
        Console.WriteLine(new String('\n', length));
    }

    public int PrintMenu(params string[] options)
    {
        int length = options.Length;
        ClearLastMenu(length);
        for (int i = 0; i < length; i++) {
            if (i == _selectedOption) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(UNDERLINE + options[i] + RESET);
                Console.ResetColor();
                var (leftPos, topPos) = Console.GetCursorPosition();
                Console.SetCursorPosition(leftPos - 1, topPos);
                Console.WriteLine(" ");
            } else {
                Console.WriteLine(" " + options[i]);
            }
        }    
        return length;
    }

    private void ClearLastMenu(int length)
    {
        var (_, currentTopPos) = Console.GetCursorPosition();
        int topOfMenu = Math.Max(currentTopPos - length, 0);
        Console.SetCursorPosition(0, topOfMenu);
    }

    private ConsoleKey GetInput(int length)
    {
        ConsoleKey key = Console.ReadKey(intercept: true).Key;
        if (key == ConsoleKey.UpArrow) {
            _selectedOption--;
            _selectedOption = Math.Max(_selectedOption, 0);
        } else {
            _selectedOption++;
            _selectedOption = Math.Min(_selectedOption, length-1);
        }
        return key;
    }
}
