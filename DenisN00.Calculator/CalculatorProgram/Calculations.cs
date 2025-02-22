using System.Diagnostics;

namespace CalculatorProgram;

public class Calculations
{
    public double FirstNumber
    { get; set;}

    public double SecondNumber
    { get; set;}

    public string Operat
    { get; set;}

    public double Result
    { get; set;}

    public Calculations(double firstNumber, double secondNumber, string operat, double result) 
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
        switch (operat)
        {
            case "a": 
                Operat = "+"; 
                break;	
            case "s": 
                Operat = "-"; 
                break;	
            case "m": 
                Operat = "*"; 
                break;	
            case "d": 
                Operat = "/"; 
                break;	
        }
        Result = result;
    }
}