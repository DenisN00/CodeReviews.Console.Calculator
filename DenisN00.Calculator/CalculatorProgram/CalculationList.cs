using CalculatorProgram;

namespace CalculatorProgram;

static public class CalculationList
{
    static public List<Calculations> calculations = new List<Calculations>();

    static public void StoreCalculation(Calculations calculation)
    {
        calculations.Add(calculation);
    }

    static public void PrintStoredCalculations()
    {
        int index = 0;
        foreach (object calculation in calculations)
        {
            if (calculation is Calculations calc)
            {
                Console.WriteLine($"{index}: {calc.FirstNumber} {calc.Operat} {calc.SecondNumber} = {calc.Result}");
                index++;
            }
            else
            {
                Console.WriteLine("Invalid object in list.");
            }
        }
    }
}