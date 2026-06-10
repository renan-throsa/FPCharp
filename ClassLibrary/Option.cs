using System;

namespace ClassLibrary
{
    public struct NoneType { }
    public record None<T> : Option<T> { }
    public abstract record Option<T>
    {
        /// <summary>
        /// This effectively tells the runtime that an instance of NoneType can be used where an
        /// Option<T>  is  expected and  instructs the  runtime to  convert the  NoneType to a
        /// None<T>.
        /// </summary>
        /// <param name="_"></param>
        public static implicit operator Option<T>(NoneType _)
            => new None<T>();

        /// <summary>
        /// Implicit conversion from T to Option<T>. This means that a T can be used where an Option<T> is expected 
        /// and will automatically be wrapped into a Some<T>—unless it’s null, in which case it will be a None<T>.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Option<T>(T value)
            => value is null ? new None<T>() : new Some<T>(value);

    }

    public record Some<T> : Option<T>
    {
        private T Value { get; }

        public Some(T value) => Value = value ?? throw new ArgumentNullException();

        public void Deconstruct(out T value) => value = Value;

    }

}
