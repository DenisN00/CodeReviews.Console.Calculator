namespace CalculatorProgram
{
    public class Calculations
    {
        public double FirstNumber
        { get; set; }

        public double? SecondNumber // Made this nullable for single-number operations
        { get; set; }

        public string Operator
        { get; set; }

        public double Result
        { get; set; }

        // Constructor for operations with two numbers (standard calculations)
        public Calculations(double firstNumber, double secondNumber, string op, double result)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operator = GetOperatorSymbol(op);
            Result = result;
        }

        // Constructor for operations with only one number (e.g., sqrt, multiply by 10)
        public Calculations(double firstNumber, string op, double result)
        {
            FirstNumber = firstNumber;
            SecondNumber = null; // No second number for these operations
            Operator = GetOperatorSymbol(op);
            Result = result;
        }

        private string GetOperatorSymbol(string op)
        {
            switch (op)
            {
                case "a": return "+";
                case "s": return "-";
                case "m": return "*";
                case "d": return "/";
                case "r": return "SquareRoot";
                case "p": return "Power";
                case "x": return "MultiplyByTen";
                case "triS": return "Sine";
                case "triC": return "Cosine";
                case "triT": return "Tangent";
                default: return "";
            }
        }
    }
}