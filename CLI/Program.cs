using CommandLineMenu;
using ConsoleUtils;

namespace CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUI ui = new ConsoleUI();
            IMenuCLI menu = new MenuUI(ui);

            string[] options = ["Pizza", "Egg", "Egg 2", "water"];
            var (index, option) = menu.CliMenu(null, options);
            Console.WriteLine($"\nSelected {options[index]} at index {index}\n");

            options = ["React", "Vue", "potatis"];
            (index, option) = menu.CliMenu("Select framework: ", options);
            Console.WriteLine($"\nSelected {options[index]} at index {index}\n");

            (index, option) = menu.CliMenu("Choose gender", "Male", "Female", "March 14", "Others");
            Console.WriteLine($"\nSelected {option} at index {index}\n");

            (index, option) = menu.CliMenu(null, options);
            Console.WriteLine($"\nSelected {options[index]} at index {index}\n");
        }
    }
}
