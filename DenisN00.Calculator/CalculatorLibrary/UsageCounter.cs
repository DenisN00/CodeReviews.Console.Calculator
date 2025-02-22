using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

        public static void Incrementation()
        {
            string jsonData = File.ReadAllText(filePath);

            Usages deserialized = JsonConvert.DeserializeObject<Usages>(jsonData);
            
            deserialized.Counter++;

            Console.WriteLine($"The Calculator has been used: {deserialized.Counter} times.");
            
            string updatedJsonData = JsonConvert.SerializeObject(deserialized, Formatting.Indented);

            File.WriteAllText(filePath, updatedJsonData);
        }
    }
}
