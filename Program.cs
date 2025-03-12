namespace UIElement;

class Program
{
    static void Main(string[] args)
    {
        int maxValueBar = 10;
        int healthBar = 0;
        int manaBar = 0;

        bool waitAnswerUser = true;

        ConsoleColor msgError = ConsoleColor.Red;

        while(waitAnswerUser)
        {
            DrawBar(ref healthBar, maxValueBar, ConsoleColor.Green, msgError, '#', 0);
            DrawBar(ref manaBar, maxValueBar, ConsoleColor.Blue, msgError, '@', 1);

            Console.SetCursorPosition(0, 5);

            Console.WriteLine("Выберите значение для бара Health (или 'q' для выхода): ");
            string healthInput = Console.ReadLine();

            if (healthInput.ToLower() == "q")
            {
                waitAnswerUser = false;
                continue;
            }

            Console.WriteLine("Выберите значение для бара Mana (или 'q' для выхода): ");
            string manaInput = Console.ReadLine();

            if (manaInput.ToLower() == "q")
            {
                waitAnswerUser = false;
                continue;
            }

            try
            {
                healthBar = Convert.ToInt32(healthInput);
                manaBar = Convert.ToInt32(manaInput);

                string errorMessage = "";

                if (!ControlSizeBar(healthBar, maxValueBar, ref errorMessage))
                {
                    Console.ForegroundColor = msgError;
                    Console.WriteLine($"Ошибка Health: {errorMessage}");
                    Console.ResetColor();
                    healthBar = 0;
                }

                if (!ControlSizeBar(manaBar, maxValueBar, ref errorMessage))
                {
                    Console.ForegroundColor = msgError;
                    Console.WriteLine($"Ошибка Mana: {errorMessage}");
                    Console.ResetColor();
                    manaBar = 0;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = msgError;
                Console.WriteLine("Ошибка: Введено некорректное значение. Используйте только числа.");
                Console.ResetColor();
            }

            Console.ReadLine();
            Console.Clear();
        }
    }

    static void DrawBar(ref int valueBar, int maxValueBar, ConsoleColor colorBar, ConsoleColor msgError, char symbolBar, int position)
    {
        string bar = "";

        ConsoleColor defaultColor = Console.BackgroundColor;

        for (int i = 0; i < valueBar; i++)
        {
            bar += symbolBar;
        }

        Console.SetCursorPosition(0, position);
        Console.Write('[');
        Console.BackgroundColor = colorBar;
        Console.Write(bar);
        Console.BackgroundColor = defaultColor;

        bar = "";

        for (int i = valueBar; i < maxValueBar; i++)
        {
            bar += " ";
        }

        Console.Write(bar + ']');
    }

    static bool ControlSizeBar(int valueBar, int maxValueBar, ref string errorMassage)
    {
        int minimalValueBar = 0;

        if (valueBar > maxValueBar)
        {
            errorMassage = $"Размер превышает допустимую норму {maxValueBar}";
            return false;
        }
        else if (valueBar < minimalValueBar)
        {
            errorMassage = $"Размер бара не может быть меньше{minimalValueBar}";
            return false;
        }
        else return true;
    }
}
