using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] fruits = new string[] { "apple", "banana", "grape" }; // 定義一個字串陣列
        var jstring = new
        {
            fruit = from f in fruits select f,
            /*
            color = new
            {
                apple = "red",
                banana = "yellow",
                grape = "purple"
            }, // 定義color這個物件
            */
            restaurant = new
            {
                apple = new { left = "5", price = "10" },
                banana = new { left = "10", price = "15" },
                grape = new { left = "12", price = "20" }
            },
            /*
            info = new[]
            {
                new { food = "apple", left = "5", price = "10" },
                new { food = "banana", left = "10", price = "15" }
            } // 定義陣列中的物件
            */
        };

        // Serialize to JSON without formatting
        string result = JsonConvert.SerializeObject(jstring); //字串轉JSON格式
        Console.WriteLine(result);
        Console.WriteLine();

        // Deserialize to JObject
        JObject take = JObject.Parse(result);

        // Accessing and printing elements
        Console.WriteLine(take["fruit"][0].ToString());       // apple
        Console.WriteLine(take["color"]["apple"].ToString()); // red
        Console.WriteLine(take["restaurant"]["apple"].ToString());
        Console.WriteLine(take["info"][1]["price"].ToString()); // 15
    }
}
