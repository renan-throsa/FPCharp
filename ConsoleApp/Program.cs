using ClassLibrary;
using ClassLibrary.Extentions;
using System.Collections.Specialized;
using static System.Console;
using static ClassLibrary.Utils.F;
using static ClassLibrary.Utils.Int;

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


        }

    }
}
