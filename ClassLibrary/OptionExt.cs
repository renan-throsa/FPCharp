namespace ClassLibrary
{
    public static class OptionExt
    {
        public static T Match<T>(this Option<T> opt, Func<T> None, Func<T, T> Some) => opt switch
        {
            None<T> => None(),
            Some<T>(var t) => Some(t),
            _ => throw new ArgumentException("Option must be None or Some")
        };

    }
}
