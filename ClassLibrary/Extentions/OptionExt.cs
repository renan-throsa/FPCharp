using static ClassLibrary.Utils.F;
using Unit = System.ValueTuple;

namespace ClassLibrary.Extentions
{
    public static class OptionExt
    {
        /// <summary>
        /// Map takes a function T → R and returns Option&#60;R&#62;
        /// It is supposed to change the inner value of Option, although.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public static Option<R> Map<T, R>(this Option<T> opt, Func<T, R> f) => opt.Match(None: () => None, Some: (t) => Some(f(t)));


        /// <summary>
        /// Bind takes a function T → Option&#60;R&#62; and returns Option&#60;R&#62;. 
        /// In other words, Bind takes an Option-returning function f and aplys f to the inner value of Option.
        /// It does not change the inner value of Option, although.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="opt"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Option<R> Bind<T, R>(this Option<T> opt, Func<T, Option<R>> f) => opt.Match(() => None, f);

        public static Option<Unit> ForEach<T>(this Option<T> opt, Action<T> action) => opt.Map(action.ToFunc());

        public static Option<T> Where<T>(this Option<T> opt, Func<T, bool> pred) => opt.Match(() => None, (t) => pred(t) ? Some(t) : None);



    }
}
