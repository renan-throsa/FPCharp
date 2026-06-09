using ClassLibrary;

namespace ConsoleApp
{
    internal class Program
    {
#pragma warning disable CS8509 // A expressão switch não manipula todos os valores possíveis de seu tipo de entrada (não é exaustiva).
        static string Greet(Option<string> greetee) => greetee switch
        {
            None<string> => "Sorry, who?",
            Some<string>(var name) => $"Hello, {name}",
        };
#pragma warning restore CS8509 


        static void Main(string[] args)
        {
            Option<string> doe = new None<string>();
            Option<string> john = new Some<string>("John");
            Console.WriteLine(Greet(john));
            Console.WriteLine(Greet(doe));
        }
    }
}
