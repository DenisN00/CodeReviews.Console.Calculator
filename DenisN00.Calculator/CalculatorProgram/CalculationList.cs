using CalculatorProgram;
using Spectre.Console;
using static System.Console;

namespace CalculatorProgram
{
    public static class CalculationList
    {
        public static List<Calculations> calculations = new List<Calculations>();
        public static List<string> allCalculations = new List<string>();
        public static double? forwardResult = null;

        public static void StoreCalculation(Calculations calculation)
        {
            calculations.Add(calculation);
        }

        public static List<string> PrintStoredCalculations()
        {
            // Clear the allCalculations list before adding new calculations
            allCalculations.Clear();

            int index = 0;

            foreach (object calculation in calculations)
            {
                if (calculation is Calculations calc)
                {
                    // Add calculation to the allCalculations list without printing to console
                    allCalculations.Add($"{index}: {calc.FirstNumber} {calc.Operator} {calc.SecondNumber} = {calc.Result}");
                    index++;
                }
                else
                {
                    // If there's an invalid object, handle it accordingly
                    WriteLine("Invalid object in list.");
                }
            }

            return allCalculations;
        }


        public static void HandleCalculationList()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Clear();

                // Ensure all calculations are cleared before adding new choices
                List<string> calculationStrings = PrintStoredCalculations();

                bool backToListMenu = false;

                if (calculationStrings.Count == 0)
                {
                    AnsiConsole.MarkupLine("[red]No stored calculations found.[/]");
                    ReadKey();
                    return; // Exit if no calculations are available
                }

                // Display calculations
                string menuSelection = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                   .Title("Recent calculations")
                   .PageSize(10)
                   .MoreChoicesText("[grey](Move up and down to choose a calculation.)[/]")
                   .AddChoices(calculationStrings)
                   .AddChoices("Return"));

                if (menuSelection == "Return")
                {
                    return;
                }

                while (!backToListMenu)
                {
                    string menuSelection2 = AnsiConsole.Prompt(
                       new SelectionPrompt<string>()
                       .Title($"You selected: [green]{menuSelection}[/]")
                       .PageSize(10)
                       .MoreChoicesText("[grey](Move up and down to choose a calculation.)[/]")
                       .AddChoices("Delete Calculation", "Use Result for another calculation", "Return"));

                    if (menuSelection2 == "Delete Calculation")
                    {
                        // Extract index from the selected string
                        int selectedIndex = int.Parse(menuSelection.Split(':')[0]);

                        // Remove the corresponding calculation
                        if (selectedIndex >= 0 && selectedIndex < calculations.Count)
                        {
                            calculations.RemoveAt(selectedIndex);
                            backToListMenu = true;
                        }
                    }

                    if (menuSelection2 == "Use Result for another calculation")
                    {
                        forwardResult = CalculateWithRecentResult(menuSelection, backToListMenu);
                        Calculating newCalculation = new Calculating();
                        newCalculation.StartCalculation();

                        backToListMenu = true;
                        backToMainMenu = true;
                    }

                    if (menuSelection2 == "Return")
                    {
                        backToListMenu = true;
                    }
                }
            }
        }
        public static double? CalculateWithRecentResult(string menuSelection, bool backToListMenu)
        {
            // Extract index from the selected string
            int selectedIndex = int.Parse(menuSelection.Split(':')[0]);

            if (selectedIndex >= 0 && selectedIndex < calculations.Count)
            {
                double result = calculations[selectedIndex].Result;
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}