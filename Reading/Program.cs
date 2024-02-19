using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writing;
using System.IO;
using System.Text.Json;
namespace Reading
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }

            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxProduct = products[0];
            foreach(Product product in products)
            {
                if (product.Price > maxProduct.Price)
                {
                    maxProduct = product;
                }
            }
            Console.WriteLine($"Самый дорогой товар: id = {maxProduct.Id}, имя - {maxProduct.Name}, цена - {maxProduct.Price}");
            Console.ReadKey();
        }
    }
}
