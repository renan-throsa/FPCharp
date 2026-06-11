namespace ClassLibrary.Utils
{
    public static class F
    {
        public static Option<T> Some<T>(T value) => new Option<T>(value);
        public static NoneType None => default;

    }
}
