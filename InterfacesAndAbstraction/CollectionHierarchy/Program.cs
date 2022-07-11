using System;

namespace CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            var add = new AddCollection();
            var addRemove = new AddRemoveCollection();
            var myList = new MyList();

            foreach (var item in strings)
            {
                Console.Write(add.Add(item) + " ");
            }
            Console.WriteLine();
            foreach (var item in strings)
            {
                Console.Write(addRemove.Add(item) + " ");
            }
            Console.WriteLine();
            foreach (var item in strings)
            {
                Console.Write(myList.Add(item) + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(addRemove.Remove() + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
        }
    }
}
