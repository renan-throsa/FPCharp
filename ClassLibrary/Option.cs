namespace ClassLibrary
{
    public interface Option<T> { }
    public record None<T> : Option<T>;
    public record Some<T>(T Value) : Option<T>;


}
