using System;
using System.Collections.Generic;

namespace BuilderPrototypeSingleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Builder

            Console.WriteLine("Builder Creational Pattern\n");

            ACategoryCarDirector director = new ACategoryCarDirector(new CarManualBuilder());
            Console.WriteLine(director.Make());

            Console.WriteLine('\n');

            // Prototype

            Console.WriteLine("Prototype Creational Pattern\n");

            var prototype = new Human("Ramazan", "Mustafazade", 16);

            Console.WriteLine($"Prototype - {prototype}\n");

            const int count = 3;
            var clones = new List<Human>(count);

            Console.WriteLine("Clones:\n");

            for (int i = 0; i < count; i++)
            {
                var clone = prototype.Clone() as Human;

                clones.Add(clone);
                Console.WriteLine(clone);
            }

            Console.WriteLine('\n');

            // Singleton

            Console.WriteLine("Singleton Creational Pattern\n");

            var site = WebSite.GetInstance();
            site = WebSite.GetInstance();

            Console.WriteLine(site);

            Console.WriteLine('\n');
        }
    }
}
