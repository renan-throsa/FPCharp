using System;
using static ClassLibrary.Utils.F;

namespace ClassLibrary
{
    public struct NoneType { }

    public struct Option<T>
    {
        readonly T value;
        readonly bool isSome;
        internal Option(T value)
        {
            this.value = value ?? throw new ArgumentNullException();
            this.isSome = true;
        }

        /// <summary>
        /// This effectively tells the runtime that an instance of NoneType can be used where an
        /// Option<T>  is  expected and  instructs the  runtime to  convert the  NoneType to a
        /// None<T>.
        /// </summary>
        /// <param name="_"></param>
        public static implicit operator Option<T>(NoneType _) => default;

        /// <summary>
        /// Implicit conversion from T to Option<T>. This means that a T can be used where an Option<T> is expected 
        /// and will automatically be wrapped into a Some<T>—unless it’s null, in which case it will be a None<T>.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Option<T>(T value)
            => value is null ? None : Some(value);

        /// <summary>
        /// Once an Option is constructed, the only way to interact with it is with Match.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="None"></param>
        /// <param name="Some"></param>
        /// <returns></returns>
        public R Match<R>(Func<R> None, Func<T, R> Some) => isSome ? Some(value!) : None();

    }

}
