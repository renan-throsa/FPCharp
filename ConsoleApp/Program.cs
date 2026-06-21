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

            new NameValueCollection()
                .Lookup("green")
                .ForEach(WriteLine);

            new Dictionary<string, string>()
                .Lookup("blue")
                .ForEach(WriteLine);


            var greet = (string name) => $"hello, {name}";

            Option<string> notEmpty = "Dean";

            notEmpty.Map(greet).ForEach(WriteLine);

            Some("John").ForEach(name => WriteLine($"Hello {name}"));

        }

    }
}
