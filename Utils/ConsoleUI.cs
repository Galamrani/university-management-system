namespace GalAmrani;

public static class ConsoleUI
{
    public static UserAction PromptForUserAction()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("====================");
        Console.WriteLine("    MAIN MENU      ");
        Console.WriteLine("====================");

        Console.ResetColor();

        Console.WriteLine("Select an action:");
        Console.WriteLine("0. Quit");
        Console.WriteLine("1. Add a student");
        Console.WriteLine("2. Add a professor");
        Console.WriteLine("3. Enroll student in a course");
        Console.WriteLine("4. Assign a subject to a professor");
        Console.WriteLine("5. Display all people");
        Console.WriteLine("6. Check for Graduate Students?");
        Console.WriteLine("====================");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        int actionsCount = Enum.GetValues(typeof(UserAction)).Length;
        int action = ReadInt("Enter your choice: ");
        Console.ResetColor();
        return (UserAction)action;
    }

    public static void ClearConsole()
    {
        Console.Clear();
    }

    public static string PromptForId()
    {
        return ReadNonEmptyString("Enter ID: ");
    }

    public static string PromptForSubject()
    {
        return ReadNonEmptyString("Enter subject: ");
    }

    public static string PromptForCourse()
    {
        return ReadNonEmptyString("Enter course: ");
    }

    public static int PromptForCourseGrade()
    {
        return ReadInt("Enter course grade (0-100): ");
    }

    public static string PromptForName()
    {
        return ReadNonEmptyString("Enter name: ");
    }

    public static int PromptForAge()
    {
        return ReadInt("Enter age (16-120): ");
    }

    public static decimal PromptForSalary()
    {
        return ReadDecimal("Enter salary: ");
    }

    public static void PrintQuitMessage()
    {
        Console.WriteLine("Management System Stops...");
    }

    public static void PrintGraduationMessage(Student student)
    {
        Console.WriteLine($"Congratulations!");
        Console.WriteLine($"Student: {student.Name} (ID: {student.Id})");
        Console.WriteLine($"GPA: {student.GPA:F2} - Status: Graduated\n");
    }

    public static void PrintNoGraduationMessage()
    {
        Console.WriteLine("No students graduated.");
    }


    public static void PrintPersonInfo(string info)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(info);
        Console.WriteLine("--------------------------------------------------");
    }


    public static void PrintErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static int ReadInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value))
            {
                Console.ResetColor();
                return value;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid input. Please enter a valid integer.");
            Console.ResetColor();
        }
    }

    private static decimal ReadDecimal(string prompt)
    {
        decimal value;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.ResetColor();
                return value;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid input. Please enter a valid number.");
            Console.ResetColor();
        }
    }

    private static string ReadNonEmptyString(string prompt)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(input));
        Console.ResetColor();
        return input;
    }
}
