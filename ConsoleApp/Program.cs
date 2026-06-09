using ClassLibrary;

namespace ConsoleApp
{
    internal class Program
    {
        static string Greet(Option<string> greetee)
            => greetee.Match(None: () => "Sorry, who?", Some: (name) => $"Hello, {name}");


        static void Main(string[] args)
        {
            Console.WriteLine(Greet(new None<string>()));
            Console.WriteLine(Greet(new Some<string>("John")));
        }
    }
}
