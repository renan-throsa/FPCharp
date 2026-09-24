namespace Domain.Models
{
    public struct Left<E>
    {
        public readonly E _error;

        public Left(E error)
        {
            _error = error ?? throw new ArgumentNullException();
        }


    }

    public struct Right<V>
    {
        public readonly V _value;

        public Right(V value)
        {
            _value = value ?? throw new ArgumentNullException();
        }
    }
    public struct Either<E, V>
    {
        private readonly E? _error;
        private readonly V? _value;
        private readonly bool _hasValue;

        public Either(V value)
        {
            _value = value ?? throw new ArgumentNullException();
            _hasValue = true;
        }

        public Either(E error)
        {
            _error = error ?? throw new ArgumentNullException();
            _hasValue = false;
        }

        public static implicit operator Either<E, V>(Left<E> left)
            => new Either<E, V>(left._error);

        public static implicit operator Either<E, V>(Right<V> right)
            => new Either<E, V>(right._value);

        public string Match(Func<E, string> Left, Func<V, string> Right)
            => _hasValue ? Right(_value!) : Left(_error!);

    }
}
