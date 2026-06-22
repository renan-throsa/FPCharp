using ClassLibrary;
using ClassLibrary.Extentions;
using ClassLibrary.Utils;
using System.Collections.Specialized;
using static ClassLibrary.Utils.F;
using static ClassLibrary.Utils.Int;
using static System.Console;

namespace ConsoleApp
{
    internal class Program
    {


        static void Main(string[] args)
        {

            //Looking up data in a collection
            new NameValueCollection()
                .Lookup("green")
                .ForEach(WriteLine);

            new Dictionary<string, string>()
                .Lookup("blue")
                .ForEach(WriteLine);


            var greet = (string name) => $"hello, {name}";
            Option<string> notEmpty = "Dean";
            notEmpty.Map(greet).ForEach(WriteLine);

            // Performing side effects with ForEach
            Some("John").ForEach(name => WriteLine($"Hello {name}"));
            IEnumerable<string> names = new[] { "Constance", "Albert" };
            var toUpper = (string s) => s.ToUpper();
            names.Map(toUpper).ForEach(WriteLine);

            // Combining Option-returning functions
            Func<string, Option<Age>> parseAge = s => Int.Parse(s).Bind(Age.Create);
            parseAge("26").ForEach(WriteLine);
            parseAge("notAnAge").ForEach(WriteLine);
            parseAge("180").ForEach(WriteLine);

            // Flattening nested lists with Bind

            var name = new List<List<string>> {
                new List<string> { "Hi", "How are you?" },
                new List<string> { "Hope this was helpful" }
            };

            var nested = name.Map(x => x).Bind(y => y).ForEach(WriteLine);

        }

    }
}
