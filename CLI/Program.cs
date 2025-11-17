using CommandLineMenu;

namespace CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Main main = new();
            IMenuCLI menu = new MenuUI();

            string[] options = ["Pizza", "Egg", "Egg 2", "water"];
            var (index, option) = menu.CliMenu(null, options);
            Console.WriteLine($"Selected {options[index]} at index {index}");

            options = ["React", "Vue", "potatis"];
            (index, option) = menu.CliMenu("Select framework: ", options);
            Console.WriteLine($"Selected {options[index]} at index {index}");

            (index, option) = menu.CliMenu(null, ["Male", "Female", "March 14", "Others"]);
            Console.WriteLine($"Selected {option} at index {index}");

            (index, option) = menu.CliMenu(null, options);
            Console.WriteLine($"Selected {options[index]} at index {index}");
        }
    }
}
