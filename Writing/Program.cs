using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Writing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];

            for (int i = 0; i < n; i++)
            {
                int id;
                string name;
                int price;

                Console.WriteLine("Введите идентификатор продукта");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название продукта");
                name = Console.ReadLine();
                Console.WriteLine("Введите цену продукта");
                price = Convert.ToInt32(Console.ReadLine());

                products[i] = new Product { Id = id, Name = name, Price = price };
            }

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(products, jsonSerializerOptions);

            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
