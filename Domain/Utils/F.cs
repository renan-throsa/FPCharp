using Domain.Models;
using Unit = System.ValueTuple;

namespace Domain.Utils
{
    public static class F
    {
        public static Option<V> Some<V>(V value) => new Option<V>(value);
        public static Right<V> Right<V>(V value) => new Right<V>(value);
        public static Left<E> Left<E>(E error) => new Left<E>(error);
        public static Either<E, V> Either<E, V>(E error) => new Either<E, V>(error);
        public static Either<E, V> Either<E, V>(V value) => new Either<E, V>(value);
        public static Unit None => default;

    }
}
