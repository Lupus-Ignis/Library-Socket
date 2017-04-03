using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Socket_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = Server.Instance;
            KlientForbindelse k = new KlientForbindelse(s.OpretForbindelse());
            Console.WriteLine("Server har fået forbindelse");
            Console.WriteLine("sender string");
            k.SendString("Gnøf sendt som string");

            Console.WriteLine("sender json");
            k.SendJsonData("Gnøf sendt som Json");

            Console.WriteLine("Modtager string...");
            Console.WriteLine(k.LytEfterString());

            Console.WriteLine("Modtager json...");
            Console.WriteLine(k.LytEfterJson());

            Console.WriteLine();
            Console.WriteLine("Færdig");
            Console.ReadLine();
        }
    }
}
