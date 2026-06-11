using ClassLibrary;
using System.Collections.Specialized;

using static ClassLibrary.Utils.F;
using static ClassLibrary.Utils.Int;

namespace ConsoleApp
{
    internal class Program
    {       

        static string Greet(Option<string> greetee)
            => greetee.Match(None: () => "Sorry, who?", Some: (name) => $"Hello, {name}");      


        static void Main(string[] args)
        {
            Console.WriteLine(Greet(None));
            Console.WriteLine(Greet(Some("John")));

            var empty = new NameValueCollection();
            Option<string> green = empty["green"];
            Console.WriteLine(green);

            Console.WriteLine(Parse("10"));
        }

    }
}
