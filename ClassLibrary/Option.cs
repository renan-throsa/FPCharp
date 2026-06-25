using ClassLibrary.Extentions;
using static ClassLibrary.Utils.F;
using Unit = System.ValueTuple;


namespace ClassLibrary
{

    public struct Option<T>
    {
        private readonly T? value;
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
        public static implicit operator Option<T>(Unit _) => default;

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
        /// <returns>Returns the inner value parameterized &#60;R&#62; of the Option.</returns>
        public R Match<R>(Func<R> None, Func<T, R> Some) => isSome ? Some(value!) : None();

        /// <summary>
        /// Map takes a function T → R and returns Option&#60;R&#62;
        /// It is supposed to change the inner value of Option, although.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public Option<R> Map<R>(Func<T, R> f) => Match(() => None, (t) => Some(f(t)));

        public Option<Unit> ForEach(Action<T> action) => Map(action.ToFunc());

        /// <summary>
        /// Bind takes a function T → Option&#60;R&#62; and returns Option&#60;R&#62;. 
        /// In other words, Bind takes an Option-returning function f and aplys f to the inner value of Option.
        /// It does not change the inner value of Option, although.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="opt"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public Option<R> Bind<R>(Func<T, Option<R>> f) => Match(() => None, f);

        public Option<T> Where(Func<T, bool> pred) => Match(() => None, (t) => pred(t) ? Some(t) : None);

        /// <summary>
        /// returns the inner value as un IEnumerable &#60;T&#62;
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> AsEnumerable()
        {
            if (isSome) yield return value!;
        }

        public override string ToString() => isSome ? value.ToString() : "None";



    }

}
