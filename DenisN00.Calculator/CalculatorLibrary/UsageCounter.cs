using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using static System.Console;

namespace CalculatorLibrary
{
    public class Usages
    {
        public int Counter
        { get; set; }
    }


    public static class UsageCounter
    {

        public static string filePath = "UsageCounter.json";
        // public static string jsonData = File.ReadAllText(filePath);

        public static void Increment()
        {
            string jsonData = File.ReadAllText(filePath);

            Usages deserialized = JsonConvert.DeserializeObject<Usages>(jsonData);
            
            deserialized.Counter++;

            WriteLine($"The Calculator has been used: {deserialized.Counter} times.");
            
            string updatedJsonData = JsonConvert.SerializeObject(deserialized, Formatting.Indented);

            File.WriteAllText(filePath, updatedJsonData);
        }

        public static void Print()
        {
            string jsonData = File.ReadAllText(filePath);

            Usages deserialized = JsonConvert.DeserializeObject<Usages>(jsonData);

            WriteLine($"The Calculator has been used: {deserialized.Counter} times.");
            
            string updatedJsonData = JsonConvert.SerializeObject(deserialized, Formatting.Indented);

            File.WriteAllText(filePath, updatedJsonData);
        }

    }
}
