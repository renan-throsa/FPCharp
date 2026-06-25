using System.Collections.Specialized;
using Unit = System.ValueTuple;
using System.Collections.Immutable;
using static ClassLibrary.Utils.F;

namespace ClassLibrary.Extentions
{
    public static class CollectionExt
    {
        public static Option<string> Lookup(this NameValueCollection collection, string key) => collection[key];

        public static Option<T> Lookup<K, T>(this IDictionary<K, T> dict, K key)
            => dict.TryGetValue(key, out T value) ? Some(value) : None;

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> f)
            => ts.Select(f);

        public static IEnumerable<Unit> ForEach<T>(this IEnumerable<T> ts, Action<T> action)
            => ts.Map(action.ToFunc()).ToImmutableList();

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> ts, Func<T, IEnumerable<R>> f)
        {
            foreach (var t in ts)
                foreach (var r in f(t))
                    yield return r;
        }

        /// <summary>
        /// Takes un IEnumerable&#60;Option&#60;T&#62;&#62; and return IEnumerable&#60;T&#62; 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="ts"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> ts, Func<T, Option<R>> func)
            => ts.Bind((t) => { return func(t).AsEnumerable(); });

        public static IEnumerable<R> Bind<T, R>(this Option<T> opt, Func<T, IEnumerable<R>> func) => opt.AsEnumerable().Bind(func);

    }
}
