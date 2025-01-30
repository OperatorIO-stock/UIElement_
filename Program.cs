namespace UIElement;

class Program
{
    static void Main(string[] args)
    {
        int settingValuesBar;

        Console.WriteLine("Выберите размер бара");
        settingValuesBar = int.Parse(Console.ReadLine());

        RendererBar(settingValuesBar);
    }
    static void RendererBar(int settingValuesBar)
    {
        const string CommandRendererBarHealth = "H";
        const string CommandRendererBarMana = "M";

        string healthBar = "";
        string manaBar = "";

        string choosingBar;

        int totalLengthBar = 10;

        int x = 100;
        int y = 100;

        char symbolBar = '#';

        if (!ControlBarSize(settingValuesBar, totalLengthBar, out string errorMessage))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {errorMessage}");
            Console.ResetColor();
        }
        else
        {
            bool renderingProcessBar = true;

            while (renderingProcessBar)
            {
                Console.WriteLine("Выберите бар: 'M - mana' 'H - health'");
                choosingBar = Console.ReadLine().ToUpper();

                switch(choosingBar)
                {
                    case CommandRendererBarHealth:
                        healthBar = new string(symbolBar, settingValuesBar);
                        manaBar = new string(symbolBar, totalLengthBar);

                        renderingProcessBar = false;
                        break;
                    case CommandRendererBarMana:
                        manaBar = new string(symbolBar, settingValuesBar);
                        healthBar = new string(symbolBar, totalLengthBar);

                        renderingProcessBar = false;
                        break;
                    default:
                        Console.WriteLine("Такого бара нет");
                        break;
                }
            }

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Health: [{healthBar}]");

            Console.ResetColor();

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Mana: [{manaBar}]");

            Console.ResetColor();
        }
    }
    static bool ControlBarSize(int settingValuesBar, int totalLenghtBar, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (settingValuesBar > totalLenghtBar)
        {
            errorMessage = $"Размер бара слишком большой и не должен превышать {totalLenghtBar}";
            return false;
        }
        else if (settingValuesBar < 0)
        {
            errorMessage = "Размер бара не может быть < 0";
            return false;
        }
        else return true;
    }
}
