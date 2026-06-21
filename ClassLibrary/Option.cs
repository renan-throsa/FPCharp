using ClassLibrary.Extentions;
using System;
using System.Xml.Linq;
using static ClassLibrary.Utils.F;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary
{
    public struct NoneType {
        public override string ToString() => "None";
    }

    public struct Option<T>
    {
        private readonly T value;
        private readonly bool isSome;

        public Option(T value)
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
        /// <returns>Returns the type parameterized &#60;R&#62;</returns>
        private R Match<R>(Func<R> None, Func<T, R> Some) => isSome ? Some(value!) : None();

        public Option<R> Map<R>(Func<T, R> f) => this.Match(None: () => None, Some: (t) => Some(f(t)));

        public Option<NoneType> ForEach(Action<T> action)=> Map(action.ToFunc());

    }

}
