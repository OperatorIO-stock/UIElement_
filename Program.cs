namespace UIElement;

class Program
{
    static void Main(string[] args)
    {
        int maxLengthBar = 10;

        int healthBarPercent = 25;
        int manaBarPercent = 75;

        int healthPositionY = 0;
        int manaPositionY = 1;

        char symbolHealth = '#';
        char symbolMana = '@';

        DrawBar(ref healthBarPercent, maxLengthBar, ConsoleColor.Green, symbolHealth, healthPositionY);
        DrawBar(ref manaBarPercent, maxLengthBar, ConsoleColor.Blue, symbolMana, manaPositionY);

        Console.ReadKey();
        Console.Clear();
    }

    static void DrawBar(ref int valueBarPercent, int maxLengthBar, ConsoleColor colorBar, char symbolBar, int positionY, int positionX = 0)
    {
        int fillValue;
        int voidValue;

        string openBracket = "[";
        string closeBracket = "]";
        
        string bar = "";

        char voidSymbol = ' ';

        ConsoleColor defaultColor = Console.BackgroundColor;

        fillValue = CalculatePercent(valueBarPercent, maxLengthBar);

        voidValue = maxLengthBar - fillValue;

        bar = DrawBarFill(fillValue, symbolBar);

        Console.ForegroundColor = colorBar;
        Console.SetCursorPosition(positionX, positionY);
        Console.Write(openBracket + bar);

        bar = DrawBarFill(voidValue, voidSymbol);

        Console.WriteLine(bar + closeBracket);

        Console.ForegroundColor = defaultColor;
        Console.ResetColor();
    }

    static string DrawBarFill(int value, char symbolBar)
    {
        string bar = "";

        for (int i = 0; i < value; i++)
        {
            bar += symbolBar;
        }
        return bar;
    }

    static int CalculatePercent(int valueBarPercent, int maxLengthBar)
    {
        int fillValue;
        int maxPercent = 100;

        fillValue = valueBarPercent * maxLengthBar / maxPercent;

        if (fillValue > maxLengthBar)
        {
            fillValue = maxLengthBar;
        }

        return fillValue;
    }
}