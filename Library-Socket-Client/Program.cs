using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Socket_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Klient k = new Klient();
            Console.WriteLine("Åbn Server før du fortsætter");
            Console.ReadLine();
            k.OpretForbindelse();
            Console.WriteLine("Klient har fundet server.");
            Console.WriteLine("Venter på input");

            Console.WriteLine("Henter string...");
            Console.WriteLine(k.LytEfterString());

            Console.WriteLine("Henter json...");
            Console.WriteLine(k.LytEfterJson());

            Console.WriteLine("Sender string...");
            k.SendString("Spløf sendt som string");

            Console.WriteLine("Sender json...");
            k.SendJsonData("Spløf sendt som json");

            Console.WriteLine();
            Console.WriteLine("Færdig");
            Console.ReadLine();
        }
    }
}
