using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> peopleList = new Dictionary<string, Person>();
            Dictionary<string, Product> productsList = new Dictionary<string, Product>();
            string[] people = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < people.Length; i += 2)
                {
                    var person = new Person(people[i], decimal.Parse(people[i + 1]));
                    peopleList.Add(person.Name, person);
                }

                for (int i = 0; i < products.Length; i += 2)
                {
                    var product = new Product(products[i], decimal.Parse(products[i + 1]));
                    productsList.Add(product.Name, product);
                }

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] info = input.Split();
                    string personName = info[0];
                    string productName = info[1];
                    if (peopleList[personName].BuyProduct(productsList[productName]))
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    
                    input = Console.ReadLine();
                }

                foreach (var person in peopleList.Values)
                {
                    if (person.Products.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
