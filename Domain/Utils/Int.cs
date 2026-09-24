using Domain.Models;
using static Domain.Utils.F;

namespace Domain.Utils
{
    public static class Int
    {
        public static Option<int> Parse(string s) => int.TryParse(s, out int result) ? Some(result) : None;
    }
}
