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

        public static IEnumerable<Unit> ForEach<T>(this IEnumerable<T> ts, Action<T> action) 
            => ts.Select(action.ToFunc()).ToImmutableList();

    }
}
