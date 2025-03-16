using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        private string logFilePath = "calculatorlog.json";

        public double DoOperation(double num2, string op, double num1 = 999999)
        {
            double result = double.NaN;

            // Log in JSON
            using (StreamWriter logFile = File.AppendText(logFilePath))
            using (JsonTextWriter writer = new JsonTextWriter(logFile))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("Operand1");
                writer.WriteValue(num1);
                writer.WritePropertyName("Operand2");
                writer.WriteValue(num2);
                writer.WritePropertyName("Operation");

                // Calculation process
                switch (op)
                {
                    case "a":
                        result = num1 + num2;
                        writer.WriteValue("Add");
                        break;
                    case "s":
                        result = num1 - num2;
                        writer.WriteValue("Subtract");
                        break;
                    case "m":
                        result = num1 * num2;
                        writer.WriteValue("Multiply");
                        break;
                    case "d":
                        result = (num2 != 0) ? num1 / num2 : double.NaN;
                        writer.WriteValue("Divide");
                        break;
                    case "r":
                        result = Math.Sqrt(num2); ;
                        writer.WriteValue("Square root");
                        break;
                    case "p":
                        result = Math.Pow(num1, num2);
                        writer.WriteValue("Power");
                        break;
                    case "x":
                        result = num2 * 10;
                        writer.WriteValue("Multiply by 10");
                        break;
                    case "triS":
                        result = Math.Sin(num2 * (Math.PI / 180.0));
                        writer.WriteValue("Sine");
                        break;
                    case "triC":
                        result = Math.Cos(num2 * (Math.PI / 180.0));
                        writer.WriteValue("Cosine");
                        break;
                    case "triT":
                        result = Math.Tan(num2 * (Math.PI / 180.0));
                        writer.WriteValue("Tangent");
                        break;
                    default:
                        writer.WriteValue("Unknown");
                        break;
                }
                writer.WritePropertyName("Result");
                writer.WriteValue(result);
                writer.WriteEndObject();

                return result;
            }
        }
    }
}
