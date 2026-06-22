using Unit = System.ValueTuple;

namespace ClassLibrary.Utils
{
    public static class F
    {
        public static Option<T> Some<T>(T value) => new Option<T>(value);
        public static Unit None => default;

    }
}
