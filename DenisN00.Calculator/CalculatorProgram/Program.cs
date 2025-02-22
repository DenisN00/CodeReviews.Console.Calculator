// Program.cs
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using CalculatorLibrary;
using Spectre.Console;

namespace CalculatorProgram
{

    class Program
    {
        static void Main(string[] args)
        {

            bool endApp = false;
            bool exitCalculator = false;

            Calculator calculator = new Calculator();


            while (!endApp)
            {
                Console.Clear();

                string menuSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Console Calculator in C#")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .AddChoices(new[] {
                "Start Calculator", "List recent Calculations",
                "Calculator usage count", "Exit",
                }));

                switch (menuSelection)
                {
                    case "Start Calculator":
                        {
                            Calculating();
                        }
                        break;
                    case "List recent Calculations":
                        {
                            CalculationList.PrintStoredCalculations();
                            Console.ReadKey();
                        }
                        break;
                    case "Calculator usage count":
                        {
                            UsageCounter.Incrementation();
                        }
                        break;
                    case "Exit":
                        {
                            endApp = true;
                        }
                        break;
                }
            }

            void Calculating()
            {
                while (!exitCalculator)
                {
                    // Declare variables and set to empty.
                    // Use Nullable types (with ?) to match type of System.Console.ReadLine
                    string? numInput1 = "";
                    string? numInput2 = "";
                    double result = 0;

                    // Ask the user to type the first number.
                    Console.Write("Type a number, and then press Enter: ");
                    numInput1 = Console.ReadLine();

                    double cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Ask the user to type the second number.
                    Console.Write("Type another number, and then press Enter: ");
                    numInput2 = Console.ReadLine();

                    double cleanNum2 = 0;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput2 = Console.ReadLine();
                    }

                    // Ask the user to choose an operator.
                    Console.WriteLine("Choose an operator from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.Write("Your option? ");

                    string? op = Console.ReadLine();

                    // Validate input is not null, and matches the pattern
                    if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                    {
                        Console.WriteLine("Error: Unrecognized input.");
                    }
                    else
                    {
                        try
                        {
                            result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                            if (double.IsNaN(result))
                            {
                                Console.WriteLine("This operation will result in a mathematical error.\n");
                            }
                            else
                                Console.WriteLine("Your result: {0:0.##}\n", result);

                            // Counts how often the Calculator was used.
                            UsageCounter.Incrementation();

                            // Stores the recent calculation into a list.
                            CalculationList.StoreCalculation(new Calculations(cleanNum1, cleanNum2, op, result));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                        }
                    }
                    Console.WriteLine("------------------------\n");

                    // Wait for the user to respond before closing.
                    Console.Write("Press 'n' and Enter to exit to menu, or press any other key and Enter to continue: ");

                    string? userChoice = Console.ReadLine();

                    if (userChoice == "n") exitCalculator = true;
                    else if (userChoice.ToLower() == "l")
                    {
                        CalculationList.PrintStoredCalculations();
                    }

                    Console.WriteLine("\n"); // Friendly linespacing.
                }
                calculator.Finish();
                return;
            }
        }
    }
}

// test