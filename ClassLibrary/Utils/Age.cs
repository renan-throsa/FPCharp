using static ClassLibrary.Utils.F;

namespace ClassLibrary.Utils
{
    public class Age
    {
        private int Value { get; }
        public static bool operator <(Age l, Age r) => l.Value < r.Value;
        public static bool operator >(Age l, Age r) => l.Value > r.Value;
        public static bool operator <(Age l, int r) => l < new Age(r);
        public static bool operator >(Age l, int r) => l > new Age(r);

        public static Option<Age> Create(int age) => IsValid(age) ? Some(new Age(age)) : None;

        public override string ToString() => Value.ToString();

        private Age(int value) => Value = value;

        private static bool IsValid(int age) => 0 <= age && age < 120;


    }
}
