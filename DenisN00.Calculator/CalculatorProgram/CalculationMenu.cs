using System.Text.RegularExpressions;
using CalculatorLibrary;
using static System.Console;

namespace CalculatorProgram
{
    public class Calculating
    {
        bool exitCalculator = false;

        Calculator calculator = new Calculator();

        public void StartCalculation()
        {
            while (!exitCalculator)
            {
                double result = 0;

                double cleanNum1 = 0;
                double cleanNum2 = 0;

                Clear();

                WriteLine("Choose an operator from the following list:");
                WriteLine("\ta - Add");
                WriteLine("\ts - Subtract");
                WriteLine("\tm - Multiply");
                WriteLine("\td - Divide");
                WriteLine("\tr = Square Root");
                WriteLine("\tp = Power");
                WriteLine("\tx = Multiply by 10");
                WriteLine("\tt = Trigonometric Functions");
                Write("Your option? ");

                string? op = ReadLine();

                WriteLine("------------------------\n");

                // Validate input is not null, and matches the pattern
                if (op != null && Regex.IsMatch(op, "[a|s|m|d|p]"))
                {
                    // Checks if user wanted to use a result from an old calculation as first number. 
                    // If not, then it asks user to input the first number.
                    cleanNum1 = GetUserInputNumber("Type a number, and then press Enter: ");

                    // Asks for second number.
                    cleanNum2 = GetUserInputNumber("Type another number, and then press Enter: ");

                    try
                    {
                        result = calculator.DoOperation(cleanNum2, op, cleanNum1);
                        if (double.IsNaN(result))
                        {
                            WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else
                            WriteLine("Your result: {0:0.##}\n", result);

                        // Increments the UsageCounter.json file by 1.
                        UsageCounter.Increment();

                        // Stores the recent calculation into a list.
                        CalculationList.StoreCalculation(new Calculations(cleanNum1, cleanNum2, op, result));
                    }
                    catch (Exception e)
                    {
                        WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }
                }
                else if (op != null && Regex.IsMatch(op, "[r|x|t]"))
                {
                    if (op != null && Regex.IsMatch(op, "[t]"))
                    {
                        WriteLine("Choose an operator from the following list:");
                        WriteLine("\ttriS = Sine");
                        WriteLine("\ttriC = Cosine");
                        WriteLine("\ttriT = Tangent");
                        Write("Your option? ");
                        op = ReadLine();
                    }
                    cleanNum1 = GetUserInputNumber("Type a number, and then press Enter: ");

                    try
                    {
                        result = calculator.DoOperation(cleanNum1, op);
                        if (double.IsNaN(result))
                        {
                            WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else
                            WriteLine("Your result: {0:0.##}\n", result);

                        // Increments the UsageCounter.json file by 1.
                        UsageCounter.Increment();

                        // Stores the recent calculation into a list.
                        CalculationList.StoreCalculation(new Calculations(cleanNum1, op, result));
                    }
                    catch (Exception e)
                    {
                        WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }
                }
                else
                {
                    WriteLine("Error: Unrecognized input.");
                }

                // Wait for the user to respond before closing.
                Write("Press 'n' and Enter to exit to menu, or press any other key and Enter to continue: ");

                string? userChoice = ReadLine();

                if (userChoice == "n") exitCalculator = true;

                WriteLine("\n");
            }
            return;
        }

        public double GetUserInputNumber(string askForInput)
        {
            string? numInput = "";
            double result = 0;

            if (CalculationList.forwardResult == null)
            {
                // Ask the user to type the first number.
                Write(askForInput);
                numInput = ReadLine();

                while (!double.TryParse(numInput, out result))
                {
                    Write("This is not valid input. Please enter an integer value: ");
                    numInput = ReadLine();
                }

                return result;
            }
            else
            {
                result = CalculationList.forwardResult.Value;
                CalculationList.forwardResult = null;

                WriteLine($"Using result from previous calculation: {result}");

                return result;
            }
        }
    }
}