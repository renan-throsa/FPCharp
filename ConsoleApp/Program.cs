using ClassLibrary;
using System.Collections.Specialized;


namespace ConsoleApp
{
    internal class Program
    {
        public static readonly NoneType None = default;

        static string Greet(Option<string> greetee)
            => greetee.Match(None: () => "Sorry, who?", Some: (name) => $"Hello, {name}");

        public static Option<T> Some<T>(T t) => new Some<T>(t);


        static void Main(string[] args)
        {
            Console.WriteLine(Greet(None));
            Console.WriteLine(Greet("John"));

            var empty = new NameValueCollection();
            Option<string> green = empty["green"];
            Console.WriteLine(green);  // => None

        }

    }
}
