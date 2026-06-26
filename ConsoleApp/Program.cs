using ClassLibrary;
using ClassLibrary.Extentions;
using ClassLibrary.Utils;
using System.Collections.Specialized;
using static ClassLibrary.Utils.F;
using static System.Console;

namespace ConsoleApp
{
    internal class Program
    {


        static void Main(string[] args)
        {


            WriteLine("\n Looking up data in a collection \n");
            new NameValueCollection()
                .Lookup("green")
                .ForEach(WriteLine);

            new Dictionary<string, string>()
                .Lookup("blue")
                .ForEach(WriteLine);


            var greet = (string name) => $"hello, {name}";
            Option<string> notEmpty = "Dean";
            notEmpty.Map(greet).ForEach(WriteLine);


            WriteLine("\n Performing side effects with ForEach \n");
            Some("John").ForEach(name => WriteLine($"Hello {name}"));
            IEnumerable<string> names = new[] { "Constance", "Albert" };
            var toUpper = (string s) => s.ToUpper();
            names.Map(toUpper).ForEach(WriteLine);


            WriteLine("\n Combining Option-returning functions \n");
            Func<string, Option<Age>> parseAge = s => Int.Parse(s).Bind(Age.Create);
            parseAge("26").ForEach(WriteLine);
            parseAge("notAnAge").ForEach(WriteLine);
            parseAge("180").ForEach(WriteLine);

            WriteLine("\n Flattening nested lists with Bind \n");
            var nested = new List<List<string>> {
                new List<string> { "Hi", "How are you?" },
                new List<string> { "Hope this finds you well" },
                new List<string> { "ok?" }
            };

            nested.Bind(x => x).ForEach(WriteLine);


            WriteLine("\n Filtering values with Where \n");
            bool IsNatural(int i) => i >= 0;
            Option<int> ToNatural(string s) => Int.Parse(s).Where(IsNatural);

            ToNatural("2").ForEach(WriteLine);
            ToNatural("-2").ForEach(WriteLine);

            WriteLine("\n Combining Option and IEnumerable with Bind \n");
            IEnumerable<Option<Age>> ages = new[] { Age.Create(33), Age.Create(19), Age.Create(119), Age.Create(-1), Age.Create(150) };

            // Bind takes IEnumerable<Option<Age>> and returns un IEnumerable<Age>. Map returns un IEnumerable<int> 
            ages.Bind(x => x).Map(x => x.Value).Average();


        }

    }
}
