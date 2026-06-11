using static ClassLibrary.Utils.F;

namespace ClassLibrary.Utils
{
    public static class Int
    {
        public static Option<int> Parse(string s) => int.TryParse(s, out int result) ? Some(result) : None;
    }
}
