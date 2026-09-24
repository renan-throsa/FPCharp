using static Domain.Utils.F;
using Unit = System.ValueTuple;


namespace Domain.Models
{
    public struct Option<V>
    {
        private readonly V? _value;
        private readonly bool _isSome;

        public Option(V value)
        {
            _value = value ?? throw new ArgumentNullException();
            _isSome = true;
        }

        /// <summary>
        /// This effectively tells the runtime that an instance of NoneType can be used where an
        /// Option<V>  is  expected and  instructs the  runtime to  convert the  NoneType to a
        /// None<V>.
        /// </summary>
        /// <param name="_"></param>
        public static implicit operator Option<V>(Unit _) => default;

        /// <summary>
        /// Implicit conversion from V to Option<V>. This means that a V can be used where an Option<V> is expected 
        /// and will automatically be wrapped into a Some<V> — unless it’s null, in which case it will be a None<V>.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Option<V>(V value) => value is null ? None : Some(value);

        /// <summary>
        /// Once an Option is constructed, the only way to interact with it is with Match.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="None"></param>
        /// <param name="Some"></param>
        /// <returns>Returns the inner value parameterized &#60;R&#62; of the Option.</returns>
        public R Match<R>(Func<R> None, Func<V, R> Some) => _isSome ? Some(_value!) : None();


        /// <summary>
        /// returns the inner value as un IEnumerable &#60;V&#62;
        /// </summary>
        /// <returns></returns>
        public IEnumerable<V> AsEnumerable()
        {
            if (_isSome) yield return _value!;
        }

#pragma warning disable CS8603 // Possível retorno de referência nula.
        public override string ToString() => _isSome ? _value!.ToString() : "None";
#pragma warning restore CS8603 // Possível retorno de referência nula.

    }

}
