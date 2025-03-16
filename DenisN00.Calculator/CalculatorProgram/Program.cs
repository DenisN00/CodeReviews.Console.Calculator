// Program.cs
using CalculatorLibrary;
using Spectre.Console;
using static System.Console;

namespace CalculatorProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            while (!endApp)
            {
                Clear();

                string menuSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Console Calculator in C#")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to choose a menu option.)[/]")
                .AddChoices(new[] {
                "Start Calculator", "List recent Calculations",
                "Calculator usage count", "Exit",
                }));

                switch (menuSelection)
                {
                    case "Start Calculator":
                        {
                            Calculating newCalculation = new Calculating();
                            newCalculation.StartCalculation();
                        }
                        break;
                    case "List recent Calculations":
                        {
                            CalculationList.HandleCalculationList();
                        }
                        break;
                    case "Calculator usage count":
                        {
                            UsageCounter.Print();
                            ReadKey();
                        }
                        break;
                    case "Exit":
                        {
                            endApp = true;
                        }
                        break;
                }
            }
        }
    }
}
