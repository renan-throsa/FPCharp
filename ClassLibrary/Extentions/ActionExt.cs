namespace ClassLibrary.Extentions
{
    public static class ActionExt
    {
        public static Func<NoneType> ToFunc(this Action action) => () => { action(); return default; };
        public static Func<T, NoneType> ToFunc<T>(this Action<T> action) => (t) => { action(t); return default; };
    }
}
